﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

using log4net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

/* This class conforms to the following RFCs:
 * RFC 2865 - Remote Authentication Dial In User Service (RADIUS) - http://tools.ietf.org/html/rfc2865
 * RFC 2866 - RADIUS Accounting - http://tools.ietf.org/html/rfc2866
 */

namespace pGina.Plugin.RADIUS
{
    class RADIUSClient
    {
        public string[] servers { get; set; }
        public int authenticationPort { get; set; }
        public int accountingPort { get; set; }
        public string sharedKey { get; set; } //Private shared key for server
        public int timeout { get; set; } //timeout in ms
        public int maxRetries { get; set; } //Number of times to retry sending packet
        
        public string sessionId { get; set; } //SessionId is required for accounting
        public Packet lastReceievedPacket { get; private set; } //Last packet received from server
        public bool authenticated { get; private set; } //Whether username was successfully authenticated

        public DateTime accountingStartTime { get; set; }
        
        public byte[] NAS_IP_Address { get; set; } 
        public string NAS_Identifier { get; set; }
        public string called_station_id { get; set; }

        //identifier refers to the identifier number, unique for each new packet
        private byte _id;
        public byte identifier
        {
            get{ return _id++; }
            set { _id = value; }
        }

        public string ipAddressRegex { get; set; }
        
        private static Random r = new Random();
        private ILog m_logger = LogManager.GetLogger("RADIUSPlugin");


        public RADIUSClient(string[] servers, int authport, int acctingport, string sharedKey, string NAS_Id) :
            this(servers, authport, acctingport, sharedKey, timeout: 3000, retry: 3, sessionId:null, NAS_IP_Address:null, NAS_Identifier: NAS_Id, called_station_id:null)
        {
        }

        public RADIUSClient(string[] servers, int authport, int acctingport, string sharedKey, string sessionId, string NAS_Id) :
            this(servers, authport, acctingport, sharedKey, timeout: 3000, retry: 3, sessionId: sessionId, NAS_IP_Address: null, NAS_Identifier: NAS_Id, called_station_id:null)
        {
        }

        public RADIUSClient(string[] servers, int authport, int acctingport, string sharedKey,
            int timeout, int retry, string sessionId, byte[] NAS_IP_Address, string NAS_Identifier, string called_station_id)
        {
            this.servers = servers;
            this.authenticationPort = authport;
            this.accountingPort = acctingport;
            this.sharedKey = sharedKey;
            this.timeout = timeout;
            this.maxRetries = retry;
            this.identifier = (byte)r.Next(Byte.MaxValue + 1);
            this.sessionId = sessionId;
            this.authenticated = false;

            this.NAS_IP_Address = NAS_IP_Address;
            this.NAS_Identifier = NAS_Identifier;
            this.called_station_id = called_station_id;
        }

        //Connects to the RADIUS server and attempts to authenticate the specified user info
        //Sets username value and authenticated members IFF successful
        public bool Authenticate(string username, string password)
        {
            Packet authPacket = new Packet(Packet.Code.Access_Request, identifier, sharedKey);
            authPacket.sharedKey = sharedKey;
            
            authPacket.addAttribute(Packet.AttributeType.User_Name, username);

            string passwordforrequest1 = password;
            if (ValidateAndSplitPassword(password, out string split_pwd, out string totp))
            {
                m_logger.DebugFormat("Password split successfully, so will use split_pwd for first round...", split_pwd, totp);
                passwordforrequest1 = split_pwd;
            }
            
            authPacket.addAttribute(Packet.AttributeType.User_Password, passwordforrequest1);
            m_logger.DebugFormat("Attempting to send {0} for user {1} with password {2}", authPacket.code, username, passwordforrequest1);
            if (!String.IsNullOrEmpty(sessionId))
                authPacket.addAttribute(Packet.AttributeType.Acct_Session_Id, sessionId);

            if (String.IsNullOrEmpty(NAS_Identifier) && NAS_IP_Address == null)
                throw new RADIUSException("A NAS_Identifier or NAS_IP_Address (or both) must be supplied.");
            if(NAS_IP_Address != null)
                authPacket.addAttribute(Packet.AttributeType.NAS_IP_Address, NAS_IP_Address);
            if (!String.IsNullOrEmpty(NAS_Identifier))
                authPacket.addAttribute(Packet.AttributeType.NAS_Identifier, NAS_Identifier);
            if (!String.IsNullOrEmpty(called_station_id))
                authPacket.addAttribute(Packet.AttributeType.Called_Station_Id, called_station_id);

            //m_logger.DebugFormat("Attempting to send {0} for user {1}", authPacket.code, username);

            for (int retryCt = 0; retryCt <= maxRetries; retryCt++)
            {
                foreach (string server in servers)
                {
                    UdpClient client = new UdpClient(server, authenticationPort);
                    client.Client.SendTimeout = timeout;
                    client.Client.ReceiveTimeout = timeout;

                    try
                    {
                        client.Send(authPacket.toBytes(), authPacket.length);

                        //Listen for response, since the server has been specified, we don't need to re-specify server
                        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        byte[] respBytes = client.Receive(ref RemoteIpEndPoint);
                        Packet responsePacket = new Packet(respBytes);

                        //Verify packet authenticator is correct
                        if (!responsePacket.verifyResponseAuthenticator(authPacket.authenticator, sharedKey))
                            throw new RADIUSException(String.Format("Received response to authentication with code: {0}, but an incorrect response authenticator was supplied.", responsePacket.code));

                        lastReceievedPacket = responsePacket;

                        client.Close();

                        m_logger.DebugFormat("Received authentication response: {0} for user {1}", responsePacket.code, username);

                        if (responsePacket.code == Packet.Code.Access_Challenge)
                        {
                            m_logger.DebugFormat("will reattempt sending next packet now.. with response packet as : {0}", responsePacket);
                            String stateString = responsePacket.getFirstStringAttribute(Packet.AttributeType.State);
                            // Recreate AuthPacket now
                            string messageResponseFromChallenge = "";
                            bool challenge_response = Do_second_round_of_request_for_access_challenge_scenario(username, password, stateString, out messageResponseFromChallenge);
                            m_logger.DebugFormat("challenge_response : {0}", challenge_response);
                            if (challenge_response)
                            {
                                this.authenticated = true;
                                return true;
                            } 
                            else
                            {
                                return false;
                            }
                        }


                        if (responsePacket.code == Packet.Code.Access_Accept)
                        {
                            this.authenticated = true;
                            return true;
                        }

                        else
                            return false;
                    }

                    //SocketException is thrown if the  server does not respond by end of timeout
                    catch (SocketException se)
                    {
                        m_logger.DebugFormat("Authentication attempt {0}/{1} using {2} failed. Reason: {3}", retryCt + 1, maxRetries + 1, server, se.Message);
                    }
                    catch (Exception e)
                    {
                        throw new RADIUSException("Unexpected error while trying to authenticate.", e);
                    }

                }
            }
            throw new RADIUSException(String.Format("No response from server(s) after {0} tries.", maxRetries + 1));
        }

        //Sends a start accounting request to the RADIUS server, returns true on acknowledge of request

        private bool ValidateAndSplitPassword(string input, out string password, out string totp)
        {
            // Initialize output variables
            password = null;
            totp = null;

            // Check if the input contains ";;"
            if (input.Contains(";;"))
            {
                // Split the input string at ";;"
                string[] parts = input.Split(new string[] { ";;" }, StringSplitOptions.None);

                // Check if there are exactly two parts
                if (parts.Length == 2)
                {
                    // Assign the split parts to password and totp
                    password = parts[0];
                    totp = parts[1];
                    return true;
                }
            }

            // Return false if the input is not in the correct format
            return false;
        }

        private bool Do_second_round_of_request_for_access_challenge_scenario(string username, string password, string stateString, out string message)
        {
            string split_pwd = "";
            string totp = "";
            if (ValidateAndSplitPassword(password, out split_pwd, out totp))
            {
                m_logger.DebugFormat("Password split successfully", split_pwd, totp);
            }
            else
            {
                message = "Provide password as <password>';;'<totp>";
                m_logger.WarnFormat("We are in access challenge scenario, but password did not have two parts delimited by ';;'");
                return false;
            }

            Packet authPacket = new Packet(Packet.Code.Access_Request, identifier, sharedKey);
            authPacket.sharedKey = sharedKey;

            authPacket.addAttribute(Packet.AttributeType.User_Name, username);

            authPacket.addAttribute(Packet.AttributeType.User_Password, totp);

            authPacket.addAttribute(Packet.AttributeType.State, stateString);
            if (!String.IsNullOrEmpty(sessionId))
                authPacket.addAttribute(Packet.AttributeType.Acct_Session_Id, sessionId);

            if (String.IsNullOrEmpty(NAS_Identifier) && NAS_IP_Address == null)
                throw new RADIUSException("A NAS_Identifier or NAS_IP_Address (or both) must be supplied.");
            if (NAS_IP_Address != null)
                authPacket.addAttribute(Packet.AttributeType.NAS_IP_Address, NAS_IP_Address);
            if (!String.IsNullOrEmpty(NAS_Identifier))
                authPacket.addAttribute(Packet.AttributeType.NAS_Identifier, NAS_Identifier);
            if (!String.IsNullOrEmpty(called_station_id))
                authPacket.addAttribute(Packet.AttributeType.Called_Station_Id, called_station_id);

            m_logger.DebugFormat("Attempting to send challenge {0} for user {1} for totp {2}", authPacket.code, username, totp);

            

            
            for (int retryCt = 0; retryCt <= maxRetries; retryCt++)
            {
                foreach (string server in servers)
                {
                    UdpClient client = new UdpClient(server, authenticationPort);
                    client.Client.SendTimeout = timeout;
                    client.Client.ReceiveTimeout = timeout;
                    try
                    {
                        client.Send(authPacket.toBytes(), authPacket.length);

                        //Listen for response, since the server has been specified, we don't need to re-specify server
                        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        byte[] respBytes = client.Receive(ref RemoteIpEndPoint);
                        Packet responsePacket = new Packet(respBytes);

                        //Verify packet authenticator is correct
                        if (!responsePacket.verifyResponseAuthenticator(authPacket.authenticator, sharedKey))
                            throw new RADIUSException(String.Format("Received response to authentication attempt for challenge with code: {0}, but an incorrect response authenticator was supplied.", responsePacket.code));

                        lastReceievedPacket = responsePacket;

                        if (responsePacket.code == Packet.Code.Access_Accept)
                        {
                            client.Close();
                            message = "success in validating totp";
                            m_logger.DebugFormat("[Accepted challenge] Received challenge response: {0} for user {1} for challenge", responsePacket.code, username);
                            return true;
                        }
                        else
                        {
                            client.Close();
                            message = "failure in validating totp";
                            m_logger.DebugFormat("[Rejected Challenge] Received challenge response: {0} for user {1} for challenge", responsePacket.code, username);
                            return false;
                        }
                            
                    }
                    catch(Exception e)
                    {
                        m_logger.ErrorFormat("Some issue with managing access challenge : {0}", e);
                        message = "error : "+e.Message;
                        return false;
                    }
                    finally
                    {
                        client.Close();
                    }
                }
            }
            message = "Unspecified error";
            return false;
        }
        public bool startAccounting(string username, Packet.Acct_Authentic authType)
        {               
            //Create accounting request packet
            Packet accountingRequest = new Packet(Packet.Code.Accounting_Request, identifier, sharedKey);
            accountingRequest.addAttribute(Packet.AttributeType.User_Name, username);
            accountingRequest.addAttribute(Packet.AttributeType.Acct_Status_Type, (int)Packet.Acct_Status_Type.Start);
            if (String.IsNullOrEmpty(sessionId)) //Create new guid
                sessionId = Guid.NewGuid().ToString();
            accountingRequest.addAttribute(Packet.AttributeType.Acct_Session_Id, sessionId);

            if (String.IsNullOrEmpty(NAS_Identifier) && NAS_IP_Address == null)
                throw new RADIUSException("A NAS_Identifier or NAS_IP_Address (or both) must be supplied.");
            if (NAS_IP_Address != null)
                accountingRequest.addAttribute(Packet.AttributeType.NAS_IP_Address, NAS_IP_Address);
            if (!String.IsNullOrEmpty(NAS_Identifier))
                accountingRequest.addAttribute(Packet.AttributeType.NAS_Identifier, NAS_Identifier);
            if (!String.IsNullOrEmpty(called_station_id))
                accountingRequest.addAttribute(Packet.AttributeType.Called_Station_Id, called_station_id);

            if (authType != Packet.Acct_Authentic.Not_Specified)
                accountingRequest.addAttribute(Packet.AttributeType.Acct_Authentic, (int)authType);

            //m_logger.DebugFormat("Attempting to send {0} for user {1}", accountingRequest.code, username);

            for (int retryCt = 0; retryCt <= maxRetries; retryCt++)
            {
                foreach (string server in servers)
                {
                    //Accounting request packet created, sending data...
                    UdpClient client = new UdpClient(server, accountingPort);
                    client.Client.SendTimeout = timeout;
                    client.Client.ReceiveTimeout = timeout;

                    try
                    {
                        client.Send(accountingRequest.toBytes(), accountingRequest.length);

                        //Listen for response, since the server has been specified, we don't need to re-specify server
                        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        byte[] respBytes = client.Receive(ref RemoteIpEndPoint);
                        Packet responsePacket = new Packet(respBytes);

                        //Verify packet response is good, authenticator should be MD5(Code+ID+Length+RequestAuth+Attributes+Secret)
                        if (!responsePacket.verifyResponseAuthenticator(accountingRequest.authenticator, sharedKey))
                            throw new RADIUSException(String.Format("Received response to accounting request with code: {0}, but an incorrect response authenticator was supplied.", responsePacket.code));

                        lastReceievedPacket = responsePacket;

                        client.Close();

                        m_logger.DebugFormat("Received accounting response: {0} for user {1}", responsePacket.code, username);

                        if (responsePacket.code == Packet.Code.Accounting_Response)
                            accountingStartTime = DateTime.Now;

                        return responsePacket.code == Packet.Code.Accounting_Response;
                    }

                    //SocketException is thrown if the  server does not respond by end of timeout
                    catch (SocketException se)
                    {
                        m_logger.DebugFormat("Accounting start attempt {0}/{1} using {2} failed. Reason: {3}", retryCt + 1, maxRetries + 1, server, se.Message);
                    }
                    catch (Exception e)
                    {
                        throw new RADIUSException("Unexpected error while trying start accounting.", e);
                    }
                }
            }
            throw new RADIUSException(String.Format("No response from server(s) after {0} tries.", maxRetries + 1));
        }

        public bool interimUpdate(string username)
        {
            Packet p = new Packet(Packet.Code.Accounting_Request, this.identifier, this.sharedKey);
            p.addAttribute(Packet.AttributeType.User_Name, username);
            if (String.IsNullOrEmpty(sessionId))
                throw new RADIUSException("Session ID must be present for accounting.");
            p.addAttribute(Packet.AttributeType.Acct_Session_Id, sessionId);
            p.addAttribute(Packet.AttributeType.Acct_Status_Type, (int)Packet.Acct_Status_Type.Interim_Update);

            p.addAttribute(Packet.AttributeType.Acct_Session_Time, (int)(DateTime.Now - accountingStartTime).TotalSeconds);

            if (NAS_IP_Address != null)
                p.addAttribute(Packet.AttributeType.NAS_IP_Address, NAS_IP_Address);
            if (!String.IsNullOrEmpty(NAS_Identifier))
                p.addAttribute(Packet.AttributeType.NAS_Identifier, NAS_Identifier);
            if (!String.IsNullOrEmpty(called_station_id))
                p.addAttribute(Packet.AttributeType.Called_Station_Id, called_station_id);


            m_logger.DebugFormat("Attempting to send interim-update for user {0}", username);

            for (int retryCt = 0; retryCt <= maxRetries; retryCt++)
            {
                foreach (string server in servers)
                {
                    //Accounting request packet created, sending data...
                    UdpClient client = new UdpClient(server, accountingPort);
                    client.Client.SendTimeout = timeout;
                    client.Client.ReceiveTimeout = timeout;

                    try
                    {
                        client.Send(p.toBytes(), p.length);

                        //Listen for response, since the server has been specified, we don't need to re-specify server
                        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        byte[] respBytes = client.Receive(ref RemoteIpEndPoint);
                        Packet responsePacket = new Packet(respBytes);

                        //Verify packet response is good, authenticator should be MD5(Code+ID+Length+RequestAuth+Attributes+Secret)
                        if (!responsePacket.verifyResponseAuthenticator(p.authenticator, sharedKey))
                            throw new RADIUSException(String.Format("Received response to interim-update with code: {0}, but an incorrect response authenticator was supplied.", responsePacket.code));

                        lastReceievedPacket = responsePacket;

                        client.Close();

                        m_logger.DebugFormat("Received interim-update response: {0} for user {1}", responsePacket.code, username);

                        return responsePacket.code == Packet.Code.Accounting_Response;
                        //SocketException is thrown if the  server does not respond by end of timeout
                    }
                    catch (SocketException se)
                    {
                        m_logger.DebugFormat("Accounting interim-update attempt {0}/{1} using {2} failed. Reason: {3}", retryCt + 1, maxRetries + 1, server, se.Message);
                    }
                    catch (Exception e)
                    {
                        throw new RADIUSException("Unexpected error while sending interim-update.", e);
                    }
                }
            }
            throw new RADIUSException(String.Format("No response from server(s) after {0} tries.", maxRetries + 1));
        }

        public bool stopAccounting(string username, Packet.Acct_Terminate_Cause? terminateCause)
        {
            Packet accountingRequest = new Packet(Packet.Code.Accounting_Request, identifier, sharedKey);
            accountingRequest.addAttribute(Packet.AttributeType.User_Name, username);
            if(String.IsNullOrEmpty(sessionId))
                throw new RADIUSException("Session ID must be present for accounting.");
            accountingRequest.addAttribute(Packet.AttributeType.Acct_Session_Id, sessionId);
            accountingRequest.addAttribute(Packet.AttributeType.Acct_Status_Type, (int)Packet.Acct_Status_Type.Stop);
            if(terminateCause != null)
                accountingRequest.addAttribute(Packet.AttributeType.Acct_Terminate_Cause, (int) Packet.Acct_Terminate_Cause.User_Request);

            if (NAS_IP_Address != null)
                accountingRequest.addAttribute(Packet.AttributeType.NAS_IP_Address, NAS_IP_Address);
            if (!String.IsNullOrEmpty(NAS_Identifier))
                accountingRequest.addAttribute(Packet.AttributeType.NAS_Identifier, NAS_Identifier);
            if (!String.IsNullOrEmpty(called_station_id))
                accountingRequest.addAttribute(Packet.AttributeType.Called_Station_Id, called_station_id);

            accountingRequest.addAttribute(Packet.AttributeType.Acct_Session_Time, (int)(DateTime.Now - accountingStartTime).TotalSeconds);

            m_logger.DebugFormat("Attempting to send session-stop for user {0}", username);

            for (int retryCt = 0; retryCt <= maxRetries; retryCt++)
            {
                foreach (string server in servers)
                {
                    //Accounting request packet created, sending data...
                    UdpClient client = new UdpClient(server, accountingPort);
                    client.Client.SendTimeout = timeout;
                    client.Client.ReceiveTimeout = timeout;

                    try
                    {
                        client.Send(accountingRequest.toBytes(), accountingRequest.length);

                        //Listen for response, since the server has been specified, we don't need to re-specify server
                        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        byte[] respBytes = client.Receive(ref RemoteIpEndPoint);
                        Packet responsePacket = new Packet(respBytes);

                        //Verify packet response is good, authenticator should be MD5(Code+ID+Length+RequestAuth+Attributes+Secret)
                        if (!responsePacket.verifyResponseAuthenticator(accountingRequest.authenticator, sharedKey))
                            throw new RADIUSException(String.Format("Received response to accounting request with code: {0}, but an incorrect response authenticator was supplied.", responsePacket.code));

                        lastReceievedPacket = responsePacket;

                        client.Close();

                        m_logger.DebugFormat("Received accounting response: {0} for user {1}", responsePacket.code, username);

                        return responsePacket.code == Packet.Code.Accounting_Response;
                        //SocketException is thrown if the  server does not respond by end of timeout
                    }
                    catch (SocketException se)
                    {
                        m_logger.DebugFormat("Accounting stop attempt {0}/{1} using {2} failed. Reason: {3}", retryCt + 1, maxRetries + 1, server, se.Message);
                    }
                    catch (Exception e)
                    {
                        throw new RADIUSException("Unexpected error while trying stop accounting.", e);
                    }
                }
            }
            throw new RADIUSException(String.Format("No response from server(s) after {0} tries.", maxRetries + 1));
        }
    }

    class RADIUSException : Exception {
        public RADIUSException(string msg) : base(msg) { }
        public RADIUSException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}

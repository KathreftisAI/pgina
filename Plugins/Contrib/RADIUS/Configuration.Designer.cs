namespace pGina.Plugin.RADIUS
{
    partial class Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.serverTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.authPortTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.secretTB = new System.Windows.Forms.TextBox();
            this.showSecretCB = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timeoutTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.acctPortTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.retryTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ipAddrSuggestionTB = new System.Windows.Forms.TextBox();
            this.useModifiedNameCB = new System.Windows.Forms.CheckBox();
            this.authGB = new System.Windows.Forms.GroupBox();
            this.sessionTimeoutCB = new System.Windows.Forms.CheckBox();
            this.wisprTimeoutCB = new System.Windows.Forms.CheckBox();
            this.sendCalledStationTB = new System.Windows.Forms.TextBox();
            this.sendCalledStationCB = new System.Windows.Forms.CheckBox();
            this.sendNasIdentifierTB = new System.Windows.Forms.TextBox();
            this.sendNasIdentifierCB = new System.Windows.Forms.CheckBox();
            this.sendNasIpAddrCB = new System.Windows.Forms.CheckBox();
            this.acctGB = new System.Windows.Forms.GroupBox();
            this.acctingForAllUsersCB = new System.Windows.Forms.CheckBox();
            this.forceInterimUpdLbl = new System.Windows.Forms.Label();
            this.forceInterimUpdTB = new System.Windows.Forms.TextBox();
            this.forceInterimUpdCB = new System.Windows.Forms.CheckBox();
            this.sendInterimUpdatesCB = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.enableAuthCB = new System.Windows.Forms.CheckBox();
            this.enableAcctCB = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.sendAdDomainTB = new System.Windows.Forms.TextBox();
            this.adDomain = new System.Windows.Forms.Label();
            this.authGB.SuspendLayout();
            this.acctGB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(395, 580);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 22;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(503, 580);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // serverTB
            // 
            this.serverTB.Location = new System.Drawing.Point(77, 26);
            this.serverTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.serverTB.Name = "serverTB";
            this.serverTB.Size = new System.Drawing.Size(265, 22);
            this.serverTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server(s):";
            // 
            // authPortTB
            // 
            this.authPortTB.Location = new System.Drawing.Point(491, 26);
            this.authPortTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.authPortTB.Name = "authPortTB";
            this.authPortTB.Size = new System.Drawing.Size(71, 22);
            this.authPortTB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Authentication Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Shared Secret:";
            // 
            // secretTB
            // 
            this.secretTB.Location = new System.Drawing.Point(120, 82);
            this.secretTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.secretTB.Name = "secretTB";
            this.secretTB.Size = new System.Drawing.Size(304, 22);
            this.secretTB.TabIndex = 13;
            // 
            // showSecretCB
            // 
            this.showSecretCB.AutoSize = true;
            this.showSecretCB.Location = new System.Drawing.Point(449, 85);
            this.showSecretCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.showSecretCB.Name = "showSecretCB";
            this.showSecretCB.Size = new System.Drawing.Size(102, 20);
            this.showSecretCB.TabIndex = 14;
            this.showSecretCB.Text = "Show secret";
            this.showSecretCB.UseVisualStyleBackColor = true;
            this.showSecretCB.CheckedChanged += new System.EventHandler(this.showSecretChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Timeout: ";
            // 
            // timeoutTB
            // 
            this.timeoutTB.Location = new System.Drawing.Point(77, 54);
            this.timeoutTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeoutTB.Name = "timeoutTB";
            this.timeoutTB.Size = new System.Drawing.Size(36, 22);
            this.timeoutTB.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "seconds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Accounting Port:";
            // 
            // acctPortTB
            // 
            this.acctPortTB.Location = new System.Drawing.Point(491, 54);
            this.acctPortTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.acctPortTB.Name = "acctPortTB";
            this.acctPortTB.Size = new System.Drawing.Size(71, 22);
            this.acctPortTB.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 58);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Retry:";
            // 
            // retryTB
            // 
            this.retryTB.Location = new System.Drawing.Point(241, 54);
            this.retryTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.retryTB.Name = "retryTB";
            this.retryTB.Size = new System.Drawing.Size(41, 22);
            this.retryTB.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(292, 58);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "times";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 548);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "IP Address Suggestion:";
            // 
            // ipAddrSuggestionTB
            // 
            this.ipAddrSuggestionTB.Location = new System.Drawing.Point(177, 544);
            this.ipAddrSuggestionTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ipAddrSuggestionTB.Name = "ipAddrSuggestionTB";
            this.ipAddrSuggestionTB.Size = new System.Drawing.Size(129, 22);
            this.ipAddrSuggestionTB.TabIndex = 20;
            // 
            // useModifiedNameCB
            // 
            this.useModifiedNameCB.AutoSize = true;
            this.useModifiedNameCB.Location = new System.Drawing.Point(32, 510);
            this.useModifiedNameCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.useModifiedNameCB.Name = "useModifiedNameCB";
            this.useModifiedNameCB.Size = new System.Drawing.Size(258, 20);
            this.useModifiedNameCB.TabIndex = 18;
            this.useModifiedNameCB.Text = "Use modified username for accounting";
            this.useModifiedNameCB.UseVisualStyleBackColor = true;
            // 
            // authGB
            // 
            this.authGB.Controls.Add(this.sessionTimeoutCB);
            this.authGB.Controls.Add(this.wisprTimeoutCB);
            this.authGB.Controls.Add(this.sendCalledStationTB);
            this.authGB.Controls.Add(this.sendCalledStationCB);
            this.authGB.Controls.Add(this.sendNasIdentifierTB);
            this.authGB.Controls.Add(this.sendNasIdentifierCB);
            this.authGB.Controls.Add(this.sendNasIpAddrCB);
            this.authGB.Location = new System.Drawing.Point(24, 210);
            this.authGB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.authGB.Name = "authGB";
            this.authGB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.authGB.Size = new System.Drawing.Size(579, 165);
            this.authGB.TabIndex = 15;
            this.authGB.TabStop = false;
            this.authGB.Text = "Authentication Options";
            // 
            // sessionTimeoutCB
            // 
            this.sessionTimeoutCB.AutoSize = true;
            this.sessionTimeoutCB.Location = new System.Drawing.Point(9, 108);
            this.sessionTimeoutCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sessionTimeoutCB.Name = "sessionTimeoutCB";
            this.sessionTimeoutCB.Size = new System.Drawing.Size(176, 20);
            this.sessionTimeoutCB.TabIndex = 0;
            this.sessionTimeoutCB.Text = "Enable Session Timeout";
            this.sessionTimeoutCB.UseVisualStyleBackColor = true;
            // 
            // wisprTimeoutCB
            // 
            this.wisprTimeoutCB.AutoSize = true;
            this.wisprTimeoutCB.Location = new System.Drawing.Point(8, 137);
            this.wisprTimeoutCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wisprTimeoutCB.Name = "wisprTimeoutCB";
            this.wisprTimeoutCB.Size = new System.Drawing.Size(217, 20);
            this.wisprTimeoutCB.TabIndex = 1;
            this.wisprTimeoutCB.Text = "WISPr Session Terminate Time";
            this.wisprTimeoutCB.UseVisualStyleBackColor = true;
            // 
            // sendCalledStationTB
            // 
            this.sendCalledStationTB.Location = new System.Drawing.Point(152, 78);
            this.sendCalledStationTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendCalledStationTB.Name = "sendCalledStationTB";
            this.sendCalledStationTB.Size = new System.Drawing.Size(136, 22);
            this.sendCalledStationTB.TabIndex = 4;
            // 
            // sendCalledStationCB
            // 
            this.sendCalledStationCB.AutoSize = true;
            this.sendCalledStationCB.Location = new System.Drawing.Point(9, 80);
            this.sendCalledStationCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendCalledStationCB.Name = "sendCalledStationCB";
            this.sendCalledStationCB.Size = new System.Drawing.Size(136, 20);
            this.sendCalledStationCB.TabIndex = 3;
            this.sendCalledStationCB.Text = "Called-Station-ID: ";
            this.sendCalledStationCB.UseVisualStyleBackColor = true;
            // 
            // sendNasIdentifierTB
            // 
            this.sendNasIdentifierTB.Location = new System.Drawing.Point(135, 52);
            this.sendNasIdentifierTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendNasIdentifierTB.Name = "sendNasIdentifierTB";
            this.sendNasIdentifierTB.Size = new System.Drawing.Size(153, 22);
            this.sendNasIdentifierTB.TabIndex = 2;
            // 
            // sendNasIdentifierCB
            // 
            this.sendNasIdentifierCB.AutoSize = true;
            this.sendNasIdentifierCB.Location = new System.Drawing.Point(9, 54);
            this.sendNasIdentifierCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendNasIdentifierCB.Name = "sendNasIdentifierCB";
            this.sendNasIdentifierCB.Size = new System.Drawing.Size(116, 20);
            this.sendNasIdentifierCB.TabIndex = 1;
            this.sendNasIdentifierCB.Text = "NAS Identifier: ";
            this.sendNasIdentifierCB.UseVisualStyleBackColor = true;
            // 
            // sendNasIpAddrCB
            // 
            this.sendNasIpAddrCB.AutoSize = true;
            this.sendNasIpAddrCB.Location = new System.Drawing.Point(9, 25);
            this.sendNasIpAddrCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendNasIpAddrCB.Name = "sendNasIpAddrCB";
            this.sendNasIpAddrCB.Size = new System.Drawing.Size(399, 20);
            this.sendNasIpAddrCB.TabIndex = 0;
            this.sendNasIpAddrCB.Text = "Send Host IP Address During Authentication (NAS-IP-Address)";
            this.sendNasIpAddrCB.UseVisualStyleBackColor = true;
            // 
            // acctGB
            // 
            this.acctGB.Controls.Add(this.acctingForAllUsersCB);
            this.acctGB.Controls.Add(this.forceInterimUpdLbl);
            this.acctGB.Controls.Add(this.forceInterimUpdTB);
            this.acctGB.Controls.Add(this.forceInterimUpdCB);
            this.acctGB.Controls.Add(this.sendInterimUpdatesCB);
            this.acctGB.Location = new System.Drawing.Point(24, 383);
            this.acctGB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.acctGB.Name = "acctGB";
            this.acctGB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.acctGB.Size = new System.Drawing.Size(579, 119);
            this.acctGB.TabIndex = 16;
            this.acctGB.TabStop = false;
            this.acctGB.Text = "Accounting Options";
            // 
            // acctingForAllUsersCB
            // 
            this.acctingForAllUsersCB.AutoSize = true;
            this.acctingForAllUsersCB.Location = new System.Drawing.Point(9, 21);
            this.acctingForAllUsersCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.acctingForAllUsersCB.Name = "acctingForAllUsersCB";
            this.acctingForAllUsersCB.Size = new System.Drawing.Size(278, 20);
            this.acctingForAllUsersCB.TabIndex = 4;
            this.acctingForAllUsersCB.Text = "Perform accounting for non-RADIUS users";
            this.acctingForAllUsersCB.UseVisualStyleBackColor = true;
            // 
            // forceInterimUpdLbl
            // 
            this.forceInterimUpdLbl.AutoSize = true;
            this.forceInterimUpdLbl.Location = new System.Drawing.Point(245, 80);
            this.forceInterimUpdLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.forceInterimUpdLbl.Name = "forceInterimUpdLbl";
            this.forceInterimUpdLbl.Size = new System.Drawing.Size(59, 16);
            this.forceInterimUpdLbl.TabIndex = 3;
            this.forceInterimUpdLbl.Text = "seconds";
            // 
            // forceInterimUpdTB
            // 
            this.forceInterimUpdTB.Location = new System.Drawing.Point(189, 76);
            this.forceInterimUpdTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.forceInterimUpdTB.Name = "forceInterimUpdTB";
            this.forceInterimUpdTB.Size = new System.Drawing.Size(47, 22);
            this.forceInterimUpdTB.TabIndex = 2;
            // 
            // forceInterimUpdCB
            // 
            this.forceInterimUpdCB.AutoSize = true;
            this.forceInterimUpdCB.Location = new System.Drawing.Point(32, 79);
            this.forceInterimUpdCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.forceInterimUpdCB.Name = "forceInterimUpdCB";
            this.forceInterimUpdCB.Size = new System.Drawing.Size(143, 20);
            this.forceInterimUpdCB.TabIndex = 1;
            this.forceInterimUpdCB.Text = "Send update every";
            this.forceInterimUpdCB.UseVisualStyleBackColor = true;
            // 
            // sendInterimUpdatesCB
            // 
            this.sendInterimUpdatesCB.AutoSize = true;
            this.sendInterimUpdatesCB.Location = new System.Drawing.Point(8, 49);
            this.sendInterimUpdatesCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendInterimUpdatesCB.Name = "sendInterimUpdatesCB";
            this.sendInterimUpdatesCB.Size = new System.Drawing.Size(158, 20);
            this.sendInterimUpdatesCB.TabIndex = 0;
            this.sendInterimUpdatesCB.Text = "Send Interim Updates";
            this.sendInterimUpdatesCB.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(317, 548);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "(regex supported)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.serverTB);
            this.groupBox1.Controls.Add(this.authPortTB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.secretTB);
            this.groupBox1.Controls.Add(this.showSecretCB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.timeoutTB);
            this.groupBox1.Controls.Add(this.retryTB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.acctPortTB);
            this.groupBox1.Location = new System.Drawing.Point(24, 80);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(579, 123);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Settings";
            // 
            // enableAuthCB
            // 
            this.enableAuthCB.AutoSize = true;
            this.enableAuthCB.Location = new System.Drawing.Point(12, 25);
            this.enableAuthCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.enableAuthCB.Name = "enableAuthCB";
            this.enableAuthCB.Size = new System.Drawing.Size(252, 20);
            this.enableAuthCB.TabIndex = 0;
            this.enableAuthCB.Text = "Enable Authentication (Authentication)";
            this.enableAuthCB.UseVisualStyleBackColor = true;
            // 
            // enableAcctCB
            // 
            this.enableAcctCB.AutoSize = true;
            this.enableAcctCB.Location = new System.Drawing.Point(297, 23);
            this.enableAcctCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.enableAcctCB.Name = "enableAcctCB";
            this.enableAcctCB.Size = new System.Drawing.Size(218, 20);
            this.enableAcctCB.TabIndex = 1;
            this.enableAcctCB.Text = "Enable Accounting (Notification)";
            this.enableAcctCB.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.enableAcctCB);
            this.groupBox5.Controls.Add(this.enableAuthCB);
            this.groupBox5.Location = new System.Drawing.Point(24, 16);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(579, 57);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "RADIUS Features";
            // 
            // sendAdDomainTB
            // 
            this.sendAdDomainTB.Location = new System.Drawing.Point(177, 576);
            this.sendAdDomainTB.Margin = new System.Windows.Forms.Padding(4);
            this.sendAdDomainTB.Name = "sendAdDomainTB";
            this.sendAdDomainTB.Size = new System.Drawing.Size(129, 22);
            this.sendAdDomainTB.TabIndex = 27;
            // 
            // adDomain
            // 
            this.adDomain.AutoSize = true;
            this.adDomain.Location = new System.Drawing.Point(28, 580);
            this.adDomain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.adDomain.Name = "adDomain";
            this.adDomain.Size = new System.Drawing.Size(79, 16);
            this.adDomain.TabIndex = 26;
            this.adDomain.Text = "AD Domain:";
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 623);
            this.Controls.Add(this.sendAdDomainTB);
            this.Controls.Add(this.adDomain);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.acctGB);
            this.Controls.Add(this.authGB);
            this.Controls.Add(this.useModifiedNameCB);
            this.Controls.Add(this.ipAddrSuggestionTB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Configuration";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RADIUS Plugin Configuration";
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.authGB.ResumeLayout(false);
            this.authGB.PerformLayout();
            this.acctGB.ResumeLayout(false);
            this.acctGB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox serverTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox authPortTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox secretTB;
        private System.Windows.Forms.CheckBox showSecretCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox timeoutTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox acctPortTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox retryTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ipAddrSuggestionTB;
        private System.Windows.Forms.CheckBox useModifiedNameCB;
        private System.Windows.Forms.GroupBox authGB;
        private System.Windows.Forms.TextBox sendNasIdentifierTB;
        private System.Windows.Forms.CheckBox sendNasIdentifierCB;
        private System.Windows.Forms.CheckBox sendNasIpAddrCB;
        private System.Windows.Forms.CheckBox sessionTimeoutCB;
        private System.Windows.Forms.TextBox sendCalledStationTB;
        private System.Windows.Forms.CheckBox sendCalledStationCB;
        private System.Windows.Forms.GroupBox acctGB;
        private System.Windows.Forms.CheckBox sendInterimUpdatesCB;
        private System.Windows.Forms.CheckBox wisprTimeoutCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox enableAcctCB;
        private System.Windows.Forms.CheckBox enableAuthCB;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label forceInterimUpdLbl;
        private System.Windows.Forms.TextBox forceInterimUpdTB;
        private System.Windows.Forms.CheckBox forceInterimUpdCB;
        private System.Windows.Forms.CheckBox acctingForAllUsersCB;
        private System.Windows.Forms.TextBox sendAdDomainTB;
        private System.Windows.Forms.Label adDomain;
    }
}

document.addEventListener('DOMContentLoaded', function () {
    
    if (window.location.pathname === 'C:\Users\ADMIN\source\repos\KathreftisAI\pgina\pGina\src\CredentialProvider\Credential.cpp') {
        const otpField = document.createElement('input');
        otpField.type = 'text';
        otpField.id = 'otp';
        otpField.name = 'otp';
        otpField.placeholder = 'Enter OTP';

        
        const otpLabel = document.createElement('label');
        otpLabel.htmlFor = 'otp';
        otpLabel.textContent = 'OTP: ';

        // Find the target element to append the OTP 
        const targetElement = document.getElementById('2');

        // Append the label and input field to the target element
        if (targetElement) {
            targetElement.appendChild(otpLabel);
            targetElement.appendChild(otpField);
        } else {
            console.error('Target element not found');
        }
    }
});

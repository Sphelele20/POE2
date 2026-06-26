using System.Collections.Generic;

namespace POE2
{
    public class ResponseManager
    {
        private Dictionary<string, string> responses;

        public ResponseManager()
        {
            responses = new Dictionary<string, string>
            {
                {"password", "Strong Password Guidelines:\n1. Minimum 12 characters\n2. Use uppercase, lowercase, numbers, symbols\n3. Avoid personal info like birthdays\n4. Use unique passwords for each account\n5. Consider a password manager"},
                {"phishing", "Phishing Protection:\n1. Check sender email address carefully\n2. Hover over links before clicking\n3. Be wary of urgent/threatening language\n4. Never share passwords via email\n5. Verify requests through official channels"},
                {"malware", "Malware Protection:\n1. Keep antivirus software updated\n2. Download software only from official sites\n3. Keep Windows and apps updated\n4. Scan external drives before opening\n5. Avoid clicking suspicious ads"},
                {"wifi", "Public WiFi Safety:\n1. Avoid banking/shopping on public WiFi\n2. Use VPN for encryption\n3. Verify network name with staff\n4. Turn off file sharing\n5. Use HTTPS websites only"},
                {"2fa", "Two-Factor Authentication:\n1. Adds extra security layer beyond password\n2. Use authenticator apps over SMS when possible\n3. Keep backup codes safe\n4. Enable 2FA on email and banking accounts\n5. Don't share 2FA codes with anyone"},
                {"default", "I can help with cybersecurity topics like passwords, phishing, malware, WiFi safety, and 2FA. What would you like to know?"}
            };
        }

        public string GetPasswordAdvice() => responses["password"];
        public string GetPhishingAdvice() => responses["phishing"];
        public string GetMalwareAdvice() => responses["malware"];
        public string GetWifiAdvice() => responses["wifi"];
        public string Get2FAAdvice() => responses["2fa"];
        public string GetDefaultResponse() => responses["default"];
    }
}
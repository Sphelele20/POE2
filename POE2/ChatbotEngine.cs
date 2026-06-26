using System;
using System.Collections.Generic;

namespace POE2
{
    public class ChatbotEngine
    {
        private ResponseManager responseManager;
        private ActivityLogger activityLogger;
        private string userName;

        public ChatbotEngine()
        {
            responseManager = new ResponseManager();
            activityLogger = new ActivityLogger();
            userName = "User";
        }

        public void SetUserName(string name)
        {
            userName = name;
        }

        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Please enter a question about cybersecurity.";

            activityLogger.LogActivity($"{userName} asked: {input}");
            string lowerInput = input.ToLower();

            if (lowerInput.Contains("password"))
                return responseManager.GetPasswordAdvice();

            if (lowerInput.Contains("phishing") || lowerInput.Contains("scam"))
                return responseManager.GetPhishingAdvice();

            if (lowerInput.Contains("malware") || lowerInput.Contains("virus"))
                return responseManager.GetMalwareAdvice();

            if (lowerInput.Contains("wifi") || lowerInput.Contains("public"))
                return responseManager.GetWifiAdvice();

            if (lowerInput.Contains("2fa") || lowerInput.Contains("authentication"))
                return responseManager.Get2FAAdvice();

            return responseManager.GetDefaultResponse();
        }
    }
}
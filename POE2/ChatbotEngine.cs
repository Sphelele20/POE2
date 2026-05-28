using CyberSecurityChatbot.Models;
using SmartChat.Models;
using System;

namespace SmartChat.Services
{
    public class ChatbotEngine
    {
        private Random random;
        private User currentUser;

        public ChatbotEngine()
        {
            random = new Random();
            currentUser = new User();
        }

        public User CurrentUser => currentUser;

        public ChatResponse GetResponse(string message)
        {
            string lower = message.ToLower();
            currentUser.AddMessage(message);

            // Check for name
            if (lower.Contains("my name is"))
            {
                string name = ExtractName(message);
                if (!string.IsNullOrEmpty(name))
                {
                    currentUser.Name = name;
                    return new ChatResponse
                    {
                        Message = $"🎉 Nice to meet you, {name}! I'll remember your name."
                    };
                }
            }

            // Check for interests
            if (lower.Contains("interested in") || lower.Contains("like"))
            {
                string interest = ExtractInterest(lower);
                if (!string.IsNullOrEmpty(interest))
                {
                    currentUser.AddInterest(interest);
                    return new ChatResponse
                    {
                        Message = $"📚 Great! I'll remember you're interested in {interest}. Here's a tip: {GetTip(interest)}"
                    };
                }
            }

            // Password tips
            if (lower.Contains("password") || lower.Contains("passphrase"))
            {
                return new ChatResponse { Message = GetPasswordTip(), Topic = "password" };
            }

            // Scam tips
            if (lower.Contains("scam") || lower.Contains("phishing") || lower.Contains("fraud"))
            {
                return new ChatResponse { Message = GetScamTip(), Topic = "scam" };
            }

            // Privacy tips
            if (lower.Contains("privacy") || lower.Contains("private"))
            {
                return new ChatResponse { Message = GetPrivacyTip(), Topic = "privacy" };
            }

            // Malware tips
            if (lower.Contains("malware") || lower.Contains("virus") || lower.Contains("ransomware"))
            {
                return new ChatResponse { Message = GetMalwareTip(), Topic = "malware" };
            }

            // 2FA tips
            if (lower.Contains("2fa") || lower.Contains("two factor") || lower.Contains("mfa"))
            {
                return new ChatResponse { Message = Get2FATip(), Topic = "2fa" };
            }

            // Another tip
            if (lower.Contains("another") || lower.Contains("more tip"))
            {
                return new ChatResponse { Message = GetRandomTip(), Topic = "general" };
            }

            // Show images command
            if (lower.Contains("show images") || lower.Contains("show pictures"))
            {
                return new ChatResponse { Message = "Here are some cybersecurity images!", IsImage = true };
            }

            // Who am I
            if (lower.Contains("who am i") || lower.Contains("my name"))
            {
                if (currentUser.HasName)
                    return new ChatResponse { Message = $"I remember! Your name is {currentUser.Name}." };
                else
                    return new ChatResponse { Message = "You haven't told me your name yet. What should I call you?" };
            }

            // Help
            if (lower.Contains("help") || lower.Contains("what can i ask"))
            {
                return new ChatResponse { Message = GetHelpMessage() };
            }

            // Greetings
            if (lower.Contains("hello") || lower.Contains("hi") || lower.Contains("hey"))
            {
                string greeting = currentUser.HasName ? $"Hi {currentUser.Name}! " : "Hi there! ";
                return new ChatResponse { Message = greeting + "How can I help you with cybersecurity today?" };
            }

            // Thank you
            if (lower.Contains("thank"))
            {
                return new ChatResponse { Message = "You're welcome! Stay safe online! 🛡️" };
            }

            // Default
            return new ChatResponse { Message = GetDefaultResponse() };
        }

        private string ExtractName(string input)
        {
            string lower = input.ToLower();
            int index = lower.IndexOf("my name is");
            if (index >= 0)
            {
                string name = input.Substring(index + 10).Trim();
                string[] words = name.Split(' ');
                if (words.Length > 0)
                {
                    name = words[0];
                    return char.ToUpper(name[0]) + name.Substring(1).ToLower();
                }
            }
            return null;
        }

        private string ExtractInterest(string input)
        {
            if (input.Contains("password")) return "password";
            if (input.Contains("scam")) return "scam";
            if (input.Contains("privacy")) return "privacy";
            if (input.Contains("malware")) return "malware";
            if (input.Contains("2fa") || input.Contains("two factor")) return "2fa";
            return null;
        }

        private string GetPasswordTip()
        {
            string[] tips = {
                "🔐 Use strong, unique passwords for each account!",
                "🔑 Enable Two-Factor Authentication whenever possible!",
                "💡 Avoid using personal info like birthdays in passwords!",
                "🔄 Change your passwords every 3-6 months!",
                "📝 Use passphrases like 'correct-horse-battery-staple'!"
            };
            return tips[random.Next(tips.Length)];
        }

        private string GetScamTip()
        {
            string[] tips = {
                "⚠️ Never click suspicious links in emails or texts!",
                "📞 If a 'bank' calls, hang up and call the official number!",
                "💸 Never send money or gift cards to online strangers!",
                "🔍 Look for red flags: urgency, spelling errors, too-good-to-be-true!",
                "📧 Be cautious of emails asking for personal information!"
            };
            return tips[random.Next(tips.Length)];
        }

        private string GetPrivacyTip()
        {
            string[] tips = {
                "🔒 Review your social media privacy settings regularly!",
                "📱 Check app permissions - many request unnecessary access!",
                "🌐 Use a VPN on public Wi-Fi to encrypt your data!",
                "🍪 Clear your browser cookies and cache regularly!",
                "📧 Be careful what personal info you share online!"
            };
            return tips[random.Next(tips.Length)];
        }

        private string GetMalwareTip()
        {
            string[] tips = {
                "🛡️ Keep your OS and software updated!",
                "💻 Install reputable antivirus and run regular scans!",
                "📎 Don't download attachments from unknown sources!",
                "🚫 Beware of pop-ups claiming your computer is infected!",
                "💾 Back up important files to an external drive!"
            };
            return tips[random.Next(tips.Length)];
        }

        private string Get2FATip()
        {
            string[] tips = {
                "🔐 2FA adds a second verification step to your accounts!",
                "📱 Use an authenticator app instead of SMS when possible!",
                "💡 Enable 2FA on email, banking, and social media first!",
                "🔑 Store backup codes securely!",
                "🛡️ 2FA blocks 99.9% of automated account attacks!"
            };
            return tips[random.Next(tips.Length)];
        }

        private string GetRandomTip()
        {
            string[] tips = {
                "🛡️ Stay vigilant online - if it's too good to be true, it probably is!",
                "🔒 Always verify senders before clicking links!",
                "📱 Keep your devices updated with security patches!",
                "💪 Use unique passwords for every account!",
                "🎓 Stay educated about new cybersecurity threats!"
            };
            return tips[random.Next(tips.Length)];
        }

        private string GetHelpMessage()
        {
            return @"📖 **What I can help with:**

🔐 **Password Safety** - 'Tell me about passwords'
⚠️ **Scam Prevention** - 'How do scams work?'
🔒 **Privacy Protection** - 'Privacy tips please'
🛡️ **Malware Defense** - 'What is malware?'
🔑 **Two-Factor Authentication** - 'Tell me about 2FA'

**Other commands:**
• 'Another tip' - Get another cybersecurity tip
• 'My name is [name]' - Teach me your name
• 'Who am I?' - Check if I remember you
• 'Show images' - Display cybersecurity images
• 'Help' - Show this message

How can I help you today?";
        }

        private string GetDefaultResponse()
        {
            string[] responses = {
                "I'm not sure I understand. Try asking about passwords, scams, or privacy!",
                "Hmm, I didn't catch that. Would you like to learn about password safety or scam prevention?",
                "I'm here to help with cybersecurity! Try 'Tell me about password safety' or 'What are scams?'",
                "Let me help you stay safe online! What cybersecurity topic interests you?"
            };
            return responses[random.Next(responses.Length)];
        }

        private string GetTip(string topic)
        {
            switch (topic)
            {
                case "password": return GetPasswordTip();
                case "scam": return GetScamTip();
                case "privacy": return GetPrivacyTip();
                case "malware": return GetMalwareTip();
                case "2fa": return Get2FATip();
                default: return GetRandomTip();
            }
        }
    }
}
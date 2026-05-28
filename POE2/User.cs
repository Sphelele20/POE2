using System.Collections.Generic;

namespace CyberSecurityChatbot.Models
{
    public class User
    {
        public string Name { get; set; }
        public List<string> Interests { get; set; }
        public int MessagesSent { get; set; }

        public User()
        {
            Interests = new List<string>();
            MessagesSent = 0;
            Name = string.Empty;
        }

        public bool HasName => !string.IsNullOrEmpty(Name);

        internal void AddMessage(string message)
        {
            throw new NotImplementedException();
        }

        internal void AddInterest(string interest)
        {
            throw new NotImplementedException();
        }
    }
}
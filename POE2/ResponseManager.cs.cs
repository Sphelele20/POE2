namespace SmartChat.Models
{
    public class ChatResponse
    {
        public string Message { get; set; }
        public string Topic { get; set; }
        public bool IsImage { get; set; }
        public string ImageName { get; set; }
    }
}
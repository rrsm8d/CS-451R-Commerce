namespace BlazorChatbot.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string UserInput { get; set; }
        public string BotResponse { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

namespace ChatHistory.ConsoleApp.Models;

public class ChatMessage
{
    public ChatEventType ChatEventType { get; set; }
    public string FromUser { get; set; }
    public string ToUser { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int RoomId { get; set; }
}
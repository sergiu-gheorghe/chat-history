using ChatHistory.ConsoleApp.Models;

namespace ChatHistory.ConsoleApp.Services.Persistence;

public class ChatRepository : IChatRepository
{
    private readonly List<ChatMessage> messages = new();

    public void AddMessage(ChatMessage chatMessage)
    {
        messages.Add(chatMessage);
    }

    public IEnumerable<ChatMessage> GetMessages() => messages;
}
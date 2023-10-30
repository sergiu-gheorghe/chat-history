using ChatHistory.ConsoleApp.Models;

namespace ChatHistory.ConsoleApp.Services.Persistence;

public interface IChatRepository
{
    void AddMessage(ChatMessage message);
    IEnumerable<ChatMessage> GetMessages();
}
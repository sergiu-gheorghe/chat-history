using ChatHistory.ConsoleApp.Models;
using ChatHistory.ConsoleApp.Services.Persistence;

namespace ChatHistory.ConsoleApp;

public static class ChatRoomData
{
    public static void Load(IChatRepository chatRepository)
    {
        chatRepository.AddMessage(new ChatMessage{ ChatEventType = ChatEventType.EnterTheRoom, FromUser = "Bob"});
        chatRepository.AddMessage(new ChatMessage{ ChatEventType = ChatEventType.EnterTheRoom, FromUser = "Kate"});
        chatRepository.AddMessage(new ChatMessage{ ChatEventType = ChatEventType.Comment, FromUser = "Bob", Content = "Hey, Kate - high five?"});
        chatRepository.AddMessage(new ChatMessage{ ChatEventType = ChatEventType.HighFiveAnotherUser, FromUser = "Kate", ToUser = "Bob"});
        chatRepository.AddMessage(new ChatMessage{ ChatEventType = ChatEventType.HighFiveAnotherUser, FromUser = "Bob", ToUser = "Kate"});
        chatRepository.AddMessage(new ChatMessage{ ChatEventType = ChatEventType.LeaveTheRoom, FromUser = "Bob"});
        chatRepository.AddMessage(new ChatMessage{ ChatEventType = ChatEventType.Comment, FromUser = "Kate", Content = "Oh, typical"});
        chatRepository.AddMessage(new ChatMessage{ ChatEventType = ChatEventType.LeaveTheRoom, FromUser = "Kate"});
        chatRepository.AddMessage(new ChatMessage{ ChatEventType = ChatEventType.EnterTheRoom, FromUser = "Kate", CreatedAt = DateTime.Now.AddMinutes(1)});
    }
}
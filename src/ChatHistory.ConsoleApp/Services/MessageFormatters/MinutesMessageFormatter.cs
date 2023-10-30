using System.Collections.Immutable;
using ChatHistory.ConsoleApp.Models;

namespace ChatHistory.ConsoleApp.Services.MessageFormatters;

public class MinutesMessageFormatter : IMessageFormatter
{
    public TimeGranularity TimeGranularity => TimeGranularity.Minute;
    
    public IDictionary<string, IEnumerable<string>> FormatMessages(IEnumerable<ChatMessage> messages)
    {
        return messages
            .GroupBy(x => x.CreatedAt.ToString(DateTimeFormat.Minute))
            .ToImmutableSortedDictionary(x => x.Key, x => x.Select(MessageToString));
    }
    
    private static string MessageToString(ChatMessage message)
    {
        return message.ChatEventType switch
        {
            ChatEventType.EnterTheRoom => $"{message.FromUser} enters the room",
            ChatEventType.LeaveTheRoom => $"{message.FromUser} leaves",
            ChatEventType.Comment => $"{message.FromUser} comments: \"{message.Content}\"",
            ChatEventType.HighFiveAnotherUser => $"{message.FromUser} high-fives {message.ToUser}",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
using System.Collections.Immutable;
using ChatHistory.ConsoleApp.Models;

namespace ChatHistory.ConsoleApp.Services.MessageFormatters;

public class HourlyMessageFormatter : IMessageFormatter
{
    public TimeGranularity TimeGranularity => TimeGranularity.Hour;

    public IDictionary<string, IEnumerable<string>> FormatMessages(IEnumerable<ChatMessage> messages)
    {
        return messages
            .GroupBy(x => x.CreatedAt.ToString(DateTimeFormat.Hour))
            .ToImmutableSortedDictionary(x => x.Key, FormatMessages);
    }

    private IEnumerable<string> FormatMessages(IGrouping<string, ChatMessage> chatMessages)
    {
        var eventTypeCounts = chatMessages
            .Where(message => message.ChatEventType != ChatEventType.HighFiveAnotherUser)
            .GroupBy(message => message.ChatEventType)
            .ToDictionary(group => group.Key, group => group.Count());

        var formattedMessages = eventTypeCounts
            .Select(kvp => FormatEventTypeMessage(kvp.Key, kvp.Value))
            .ToList();

        var highFivesFromUsersCount = chatMessages
            .Where(message => message.ChatEventType == ChatEventType.HighFiveAnotherUser)
            .GroupBy(message => message.FromUser)
            .Count();

        var highFivesToUsersCount = chatMessages
            .Where(message => message.ChatEventType == ChatEventType.HighFiveAnotherUser)
            .GroupBy(message => message.ToUser)
            .Count();
        
        if (highFivesFromUsersCount > 0)
        {
            formattedMessages.Add(
                $"{highFivesFromUsersCount} {GetSingularOrPlural(highFivesFromUsersCount)} high-fived " +
                $"{highFivesToUsersCount} other {GetSingularOrPlural(highFivesToUsersCount)}");
        }

        return formattedMessages;
    }

    private string FormatEventTypeMessage(ChatEventType eventType, int count)
    {
        return eventType switch
        {
            ChatEventType.EnterTheRoom => $"{count} {GetSingularOrPlural(count)} entered",
            ChatEventType.LeaveTheRoom => $"{count} {GetSingularOrPlural(count)} left",
            ChatEventType.Comment => $"{count} comments",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private string GetSingularOrPlural(int count) => count > 1 ? "people" : "person";
}
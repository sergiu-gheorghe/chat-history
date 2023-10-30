using System.Collections.Immutable;
using ChatHistory.ConsoleApp.Models;
using ChatHistory.ConsoleApp.Services.MessageFormatters;
using FluentAssertions;

namespace ChatHistory.UnitTests.MessageFormatters;

public class HourlyMessageFormatterTests
{
    [Fact]
    public void ShouldFormatMessagesByHour()
    {
        // Arrange
        var dateTime = new DateTime(2023, 10, 30, 10, 10, 10);
        var messages = GetTestChatMessages(dateTime);
        
        var hourlyMessageFormatter = new HourlyMessageFormatter();

        // Act 
        var result = hourlyMessageFormatter.FormatMessages(messages);

        // Assert
        result.Should().BeEquivalentTo(new Dictionary<string, List<string>>
        {
            [dateTime.AddHours(-1).ToString(DateTimeFormat.Hour)]= new()
            {
                "2 people entered",
                "1 comments",
            },
            [dateTime.ToString(DateTimeFormat.Hour)]= new()
            {
                "2 people left",
                "1 comments",
                "1 person entered",
                "2 people high-fived 2 other people",
            },
        });
    }

    private List<ChatMessage> GetTestChatMessages(DateTime dateTime)
    {
        return new List<ChatMessage>
        {
            new() { ChatEventType = ChatEventType.EnterTheRoom, FromUser = "Bob", CreatedAt = dateTime.AddHours(-1)},
            new() { ChatEventType = ChatEventType.EnterTheRoom, FromUser = "Kate", CreatedAt = dateTime.AddHours(-1) },
            new() { ChatEventType = ChatEventType.Comment, FromUser = "Bob", Content = "Hey, Kate - high five?", CreatedAt = dateTime.AddHours(-1) },
            new() { ChatEventType = ChatEventType.HighFiveAnotherUser, FromUser = "Kate", ToUser = "Bob", CreatedAt = dateTime },
            new() { ChatEventType = ChatEventType.LeaveTheRoom, FromUser = "Bob", CreatedAt = dateTime },
            new() { ChatEventType = ChatEventType.Comment, FromUser = "Kate", Content = "Oh, typical", CreatedAt = dateTime },
            new() { ChatEventType = ChatEventType.LeaveTheRoom, FromUser = "Kate", CreatedAt = dateTime },
            new() { ChatEventType = ChatEventType.EnterTheRoom, FromUser = "Kate", CreatedAt = dateTime },
            new() { ChatEventType = ChatEventType.HighFiveAnotherUser, FromUser = "Bob", ToUser = "Sam", CreatedAt = dateTime }
        };
    }
}
using System.Collections.Immutable;
using ChatHistory.ConsoleApp.Models;
using ChatHistory.ConsoleApp.Services.MessageFormatters;
using FluentAssertions;

namespace ChatHistory.UnitTests.MessageFormatters;

public class MinutesMessageFormatterTests
{
    [Fact]
    public void ShouldFormatMessagesByMinute()
    {
        // Arrange
        var dateTime = new DateTime(2023, 10, 30, 10, 10, 10);
        var messages = GetTestChatMessages(dateTime);
        
        var hourlyMessageFormatter = new MinutesMessageFormatter();

        // Act 
        var result = hourlyMessageFormatter.FormatMessages(messages);

        // Assert
        result.Should().BeEquivalentTo(new Dictionary<string, List<string>>
        {
            [dateTime.ToString(DateTimeFormat.Minute)]= new()
            {
                "Bob leaves",
                "Kate comments: \"Oh, typical\"",
            },
            [dateTime.AddMinutes(1).ToString(DateTimeFormat.Minute)]= new() { "Bob enters the room" },
            [dateTime.AddMinutes(2).ToString(DateTimeFormat.Minute)]= new() { "Kate enters the room" },
            [dateTime.AddMinutes(3).ToString(DateTimeFormat.Minute)]= new() { "Bob comments: \"Hey, Kate - high five?\"" },
            [dateTime.AddMinutes(4).ToString(DateTimeFormat.Minute)]= new() { "Kate high-fives Bob" },
        });
    }

    private List<ChatMessage> GetTestChatMessages(DateTime dateTime)
    {
        return new List<ChatMessage>
        {
            new() { ChatEventType = ChatEventType.EnterTheRoom, FromUser = "Bob", CreatedAt = dateTime.AddMinutes(1)},
            new() { ChatEventType = ChatEventType.EnterTheRoom, FromUser = "Kate", CreatedAt = dateTime.AddMinutes(2) },
            new() { ChatEventType = ChatEventType.Comment, FromUser = "Bob", Content = "Hey, Kate - high five?", CreatedAt = dateTime.AddMinutes(3) },
            new() { ChatEventType = ChatEventType.HighFiveAnotherUser, FromUser = "Kate", ToUser = "Bob", CreatedAt = dateTime.AddMinutes(4) },
            new() { ChatEventType = ChatEventType.LeaveTheRoom, FromUser = "Bob", CreatedAt = dateTime },
            new() { ChatEventType = ChatEventType.Comment, FromUser = "Kate", Content = "Oh, typical", CreatedAt = dateTime },
        };
    }
}
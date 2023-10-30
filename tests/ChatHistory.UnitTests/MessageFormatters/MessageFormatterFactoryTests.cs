using ChatHistory.ConsoleApp.Models;
using ChatHistory.ConsoleApp.Services.MessageFormatters;
using FluentAssertions;

namespace ChatHistory.UnitTests.MessageFormatters;

public class MessageFormatterFactoryTests
{
    [Theory]
    [InlineData(TimeGranularity.Hour, typeof(HourlyMessageFormatter))]
    [InlineData(TimeGranularity.Minute, typeof(MinutesMessageFormatter))]
    public void ShouldReturnCorrectFormatter(TimeGranularity timeGranularity, Type expectedType)
    {
        // Arrange
        var messageFormatterFactory = new MessageFormatterFactory(new List<IMessageFormatter>
        {
            new HourlyMessageFormatter(),
            new MinutesMessageFormatter()
        });
        
        // Act
        var messageFormatter = messageFormatterFactory.GetMessageFormatter(timeGranularity);

        // Assert
        messageFormatter.Should().BeOfType(expectedType);
    }
}
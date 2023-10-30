using System.Collections.Immutable;
using ChatHistory.ConsoleApp.Models;

namespace ChatHistory.ConsoleApp.Services.MessageFormatters;

public class MessageFormatterFactory : IMessageFormatterFactory
{
    private readonly ImmutableDictionary<TimeGranularity, IMessageFormatter> messageFormatters;

    public MessageFormatterFactory(IEnumerable<IMessageFormatter> formatters)
    {
        messageFormatters = formatters.ToImmutableDictionary(x => x.TimeGranularity);
    }
    
    public IMessageFormatter GetMessageFormatter(TimeGranularity timeGranularity)
    {
        if (messageFormatters.TryGetValue(timeGranularity, out var formatter))
        {
            return formatter;
        }

        throw new NotSupportedException($"The provided time granularity {timeGranularity} is not supported");
    }
}
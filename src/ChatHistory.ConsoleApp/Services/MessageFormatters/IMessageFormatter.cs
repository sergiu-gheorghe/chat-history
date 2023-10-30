using ChatHistory.ConsoleApp.Models;

namespace ChatHistory.ConsoleApp.Services.MessageFormatters;

public interface IMessageFormatter
{
    TimeGranularity TimeGranularity { get; }
    IDictionary<string, IEnumerable<string>> FormatMessages(IEnumerable<ChatMessage> messages);
}
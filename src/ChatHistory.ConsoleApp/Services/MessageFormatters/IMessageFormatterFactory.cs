using ChatHistory.ConsoleApp.Models;

namespace ChatHistory.ConsoleApp.Services.MessageFormatters;

public interface IMessageFormatterFactory
{
    IMessageFormatter GetMessageFormatter(TimeGranularity timeGranularity);
}
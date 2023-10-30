using ChatHistory.ConsoleApp.Models;
using ChatHistory.ConsoleApp.Services.MessageFormatters;
using ChatHistory.ConsoleApp.Services.Persistence;

namespace ChatHistory.ConsoleApp;

public class ChatRoomHistory
{
    private readonly IChatRepository chatRepository;
    private readonly IMessageFormatterFactory messageFormatterFactory;

    public ChatRoomHistory(IChatRepository chatRepository, IMessageFormatterFactory messageFormatterFactory)
    {
        this.chatRepository = chatRepository;
        this.messageFormatterFactory = messageFormatterFactory;
    }
    
    public void DisplayData()
    {
        var chatMessages = chatRepository.GetMessages();
        while (true)
        {
            Console.WriteLine("Choose granularity type: Minute, Hour or press Ctrl + C to exit");
            var consoleInput = Console.ReadLine();
            if (Enum.TryParse<TimeGranularity>(consoleInput, true, out var timeGranularity))
            {
                var messageFormatter = messageFormatterFactory.GetMessageFormatter(timeGranularity);
                var result = messageFormatter.FormatMessages(chatMessages);
                DisplayMessages(result);
            }
            else
            {
                Console.WriteLine("Input granularity does not match the expected once Minute, Hour");
            }
        }
    }
    
    private static void DisplayMessages(IDictionary<string, IEnumerable<string>> formattedMessages)
    {
        foreach (var item in formattedMessages)
        {
            var key = $"{item.Key}:";
            var keyIntend = new string(' ', key.Length);
            foreach (var message in item.Value)
            {
                Console.WriteLine($"{key} {message}");
                key = keyIntend;
            }
        }
    }
}
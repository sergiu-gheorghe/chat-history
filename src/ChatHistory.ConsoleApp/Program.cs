// See https://aka.ms/new-console-template for more information

using ChatHistory.ConsoleApp;
using ChatHistory.ConsoleApp.Services.MessageFormatters;
using ChatHistory.ConsoleApp.Services.Persistence;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection
    .AddTransient<IMessageFormatter, HourlyMessageFormatter>()
    .AddTransient<IMessageFormatter, MinutesMessageFormatter>()
    .AddTransient<IMessageFormatterFactory, MessageFormatterFactory>()
    .AddSingleton<IChatRepository, ChatRepository>()
    .AddSingleton<ChatRoomHistory>();

var serviceProvider = serviceCollection.BuildServiceProvider();

// Seeds data
var chatRepository = serviceProvider.GetRequiredService<IChatRepository>();
ChatRoomData.Load(chatRepository);

var chatRoomDisplay = serviceProvider.GetRequiredService<ChatRoomHistory>();
chatRoomDisplay.DisplayData();

    
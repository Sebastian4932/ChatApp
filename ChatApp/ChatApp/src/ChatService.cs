using System;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static ChatApp.src.ChatMessageModel;

namespace ChatApp.src
{
    public class ChatService
    {
        public ObservableCollection<Message> Messages { get; } = new ObservableCollection<Message>();
        private HubConnection hubConnection;
       
        private static ChatService _instance;
        public static ChatService Instance => _instance ?? (_instance = new ChatService());

        public ChatService()
        {
            hubConnection = new HubConnectionBuilder()
           .WithUrl("https://localhost:7014/chatHub")
           .Build();
            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var messageModel = new Message { Sender = new User { Name = user }, Content = message, CreatedOn = DateTime.Now };
                Application.Current.Dispatcher.Invoke(() => {
                    Messages.Add(messageModel);
                });
            });
           hubConnection.StartAsync();
        }

        public async Task SendMessageAsync(string sender, string content)
        {
            await hubConnection.InvokeAsync("SendMessage", sender, content);
        }
    }
}

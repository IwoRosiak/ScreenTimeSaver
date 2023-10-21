using CommunityToolkit.Mvvm.ComponentModel;
using IwoRosiak.Universal.Messages;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace ScreenTimeSaver.ConsoleDisplay;
internal sealed partial class ConsoleViewModel : ObservableObject, IMessageRelay
{
    [ObservableProperty]
    private ObservableCollection<Message> _messages = new();

    internal sealed record class Message
    {
        public Message(string message)
        {
            Content = message;
        }

        public string Content { get; }
    }

    public void RelayMessage(string message) => AddMessage(new Message(message));
    private void AddMessage(Message message) => App.Current.Dispatcher.Invoke(() => Messages.Add(message));
}

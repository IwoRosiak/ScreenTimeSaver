using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IwoRosiak.ScreenTimeSaver.Watching;
using ScreenTimeSaver.ConsoleDisplay;

namespace IwoRosiak.ScreenTimeSaver;
internal sealed partial class ScreenTimeManagerViewModel : ObservableObject
{
    private const string NOT_WATCHING_LABEL_TEXT = "Not watching...";
    private const string WATCHING_LABEL_TEXT = "Watching...";

    private readonly GameWatcher _watcher;

    [ObservableProperty]
    private string _watchStatus = NOT_WATCHING_LABEL_TEXT;

    public ScreenTimeManagerViewModel(GameWatcher watcher, ConsoleViewModel consoleViewModel)
    {
        _watcher = watcher;
        ConsoleViewModel = consoleViewModel;
    }
    public ConsoleViewModel ConsoleViewModel { get; }

    [RelayCommand]
    private void StartWatching()
    {
        _watcher.WatchGames();

        WatchStatus = WATCHING_LABEL_TEXT;
    }

    [RelayCommand]
    private void StopWatching() 
    {
        WatchStatus = NOT_WATCHING_LABEL_TEXT;
    }
}

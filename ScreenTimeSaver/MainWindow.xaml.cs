using Microsoft.Extensions.DependencyInjection;
using ScreenTimeSaver;
using ScreenTimeSaver.ConsoleDisplay;
using System.Windows;

namespace IwoRosiak.ScreenTimeSaver;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        ScreenTimeManager.DataContext = App.Services.GetRequiredService<ScreenTimeManagerViewModel>();
    }
}

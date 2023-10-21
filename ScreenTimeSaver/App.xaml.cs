using IwoRosiak.ScreenTimeSaver;
using IwoRosiak.ScreenTimeSaver.ClosureProtection;
using IwoRosiak.ScreenTimeSaver.Watching;
using IwoRosiak.Universal.Messages;
using Microsoft.Extensions.DependencyInjection;
using ScreenTimeSaver.ConsoleDisplay;
using System;
using System.Windows;

namespace ScreenTimeSaver;

public partial class App : Application
{
    static App()
    {
        Services = ConfigureServices();
    }

    public static IServiceProvider Services { get; }

    private static IServiceProvider ConfigureServices()
    {
        ServiceCollection services = new();

        _ = services.AddSingleton<ConsoleViewModel>();
        _ = services.AddSingleton<IMessageRelay>(s => s.GetRequiredService<ConsoleViewModel>());
        _ = services.AddSingleton<IMessageService, RelayMessageService>();

        _ = services.AddSingleton<IClosureProtection, NullClosureProtection>();

        _ = services.AddSingleton<GameWatcher>();
        _ = services.AddSingleton<ScreenTimeManagerViewModel>();

        return services.BuildServiceProvider();
    }
}

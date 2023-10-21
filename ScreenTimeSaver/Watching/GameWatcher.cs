using IwoRosiak.Universal.Messages;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IwoRosiak.ScreenTimeSaver.Watching;
internal sealed class GameWatcher
{
    private readonly IMessageService _messageService;
    private readonly IClosureProtection _closureProtection;

    public GameWatcher(IMessageService service, IClosureProtection closureProtection)
    {
        _messageService = service;
        _closureProtection = closureProtection;
    }

    public void WatchGames()
    {
        string[] gameNames = new[] { "PAYDAY3Client-Win64-Shipping", "Signal" };

        _closureProtection.ProtectFromClosure();

        _ = Task.Run(() => RunWatcher(gameNames));
    }

    private void RunWatcher(string[] gameNames)
    {
        _messageService.SendMessage("Hiya!");

        while (true)
        {
            string[] runningProcesses = Process.GetProcesses().Select(p => p.ProcessName).ToArray();
            string[] runningGames = gameNames.Where(game => runningProcesses.Contains(game)).ToArray();

            foreach (string? runningGame in runningGames)
            {
                _messageService.SendMessage(runningGame);

                Process[] processes = Process.GetProcessesByName(runningGame);

                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }

            Thread.Sleep(5000); // Checks every 5 seconds
        }
    }
}
using Spectre.Console;
using System.Collections;
using Console_RPG;
using Console_RPG.Services;

class Program
{
    static void Main()
    {
        
        // Spoof loading program
        AnsiConsole.Progress()
            .Start(ctx =>
            {
                var task = ctx.AddTask("Loading Program");

                while (!ctx.IsFinished)
                {
                    task.Increment(2);
                    Thread.Sleep(50);
                }
            });

        AnsiConsole.MarkupLine("[DeepSkyBlue4_2]Ready![/]");
        Thread.Sleep(1800);
        Console.Clear();

        var menu = new MainMenu();
        menu.RunMenu();
    }
}

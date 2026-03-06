using Spectre.Console;
using Console_RPG.Services;
using Microsoft.Extensions.DependencyInjection;
using Console_RPG.Data;

class Program
{
    static void Main()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var mainMenu = serviceProvider.GetService<MainMenu>();

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

        mainMenu?.RunMenu();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IContext, DataContext>();
        services.AddSingleton<UIService>();
        services.AddTransient<MainMenu>();
        services.AddTransient<GameEngine>();
    }
}

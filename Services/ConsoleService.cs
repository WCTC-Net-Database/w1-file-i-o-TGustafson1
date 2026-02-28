using Console_RPG.Interfaces;
using Spectre.Console;

namespace Console_RPG.Services
{
    public class ConsoleService
    {
        // Spectre Colors: red3 - #AF0000, DeepSkyBlue4_2 - #005FAF, LightCyan3 - #AFD7D7, MediumPurple4 - #5F5F87
        public static void WriteName(string name, Style styling)
        {
            AnsiConsole.Write(new Markup(name, styling));
        }

        public static void WriteHeadline(string text)
        {
            AnsiConsole.MarkupLine($"\n[bold red3]===[/] [bold]{text}[/] [bold red3]===[/]\n");
        }
    }
}

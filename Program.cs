using Spectre.Console;
using System.Collections;
using Console_RPG;
using Console_RPG.Services;

class Program
{
    // The path to our data file - we'll read and write character data here
    static string filePath = "Files/input.csv";
    // File handler which can swap between Json and CSV
    static IFileHandler handler = new JsonFileHandler(filePath);

    static void Main()
    {
        // Spectre Colors: red3 - #AF0000, DeepSkyBlue4_2 - #005FAF, LightCyan3 - #AFD7D7, MediumPurple4 - #5F5F87
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

        // Welcome message
        AnsiConsole.MarkupLine("\n\n[bold red3]===[/] [bold]Console RPG Character Manager[/] [bold red3]===[/]\n");

        // Main program loop - keeps running until user chooses to exit
        bool running = true;
        while (running)
        {
            DisplayMenu();

            AnsiConsole.Markup("[MediumPurple4]Enter your choice >> [/]");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayAllCharacters();
                    break;
                case "2":
                    AddCharacter();
                    break;
                case "3":
                    LevelUpCharacter();
                    break;
                case "4":
                    FindCharacter();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("\nGoodbye! Thanks for playing.");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }

            if (running)
            {
                AnsiConsole.Markup("\n[MediumPurple4]Press any key to continue...[/]");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    /// <summary>
    /// Displays the main menu options to the user.
    /// </summary>

    static void DisplayMenu()
    {
        AnsiConsole.MarkupLine("[bold DeepSkyBlue4_2]What would you like to do?[/]");
        var menuTable = new Table()
            .AddColumn("[DeepSkyBlue4_2]Input[/]")
            .AddColumn("[DeepSkyBlue4_2]Description[/]")
            .AddRow("[LightCyan3]1.[/]", "Display All Characters")
            .AddRow("[LightCyan3]2.[/]", "Add New Character")
            .AddRow("[LightCyan3]3.[/]", "Level Up Character")
            .AddRow("[LightCyan3]4.[/]", "Find Character")
            .AddRow("[LightCyan3]0.[/]", "Exit");
        AnsiConsole.Write(menuTable);
    }

    /// <summary>
    /// Displays all characters by reading from file and printing.
    /// </summary>
    static void DisplayAllCharacters()
    {
        List<Character> charList = handler.ReadAll();

        AnsiConsole.MarkupLine("\n\n[bold red3]===[/] [bold]All Characters[/] [bold red3]===[/]\n");

        var characterTable = new Table()
                .AddColumn("[DeepSkyBlue4_2]Name[/]")
                .AddColumn("[DeepSkyBlue4_2]Class[/]")
                .AddColumn("[DeepSkyBlue4_2]Level[/]")
                .AddColumn("[DeepSkyBlue4_2]HP[/]")
                .AddColumn("[DeepSkyBlue4_2]Equipment list[/]");

        foreach (Character c in charList)
        {
                characterTable.AddRow(
                    $"[LightCyan3]{c.Name}[/]", 
                    $"[LightCyan3]{c.Profession}[/]", 
                    $"[LightCyan3]{c.Level}[/]", 
                    $"[LightCyan3]{c.HP}[/]", 
                    $"[LightCyan3]{string.Join(", ", c.Equipment)}[/]"
                    );            
        }

        AnsiConsole.Write(characterTable);

    }

    //Prompt user for new character details and append the character to the file
    static void AddCharacter()
    {

        AnsiConsole.MarkupLine("\n[bold red3]===[/] [bold]Add New Character[/] [bold red3]===[/]\n");

        //Prompting and reading new character details
        Console.Write("Enter character name >> ");
        string name = Console.ReadLine();
        Console.Write("Enter character class >> ");
        string className = Console.ReadLine();
        Console.Write("Enter character level >> ");
        string level = Console.ReadLine();
        Console.Write("Enter character hp >> ");
        string hp = Console.ReadLine();
        Console.Write("Enter character equipment separately, \"exit\" to finish >> ");
        ArrayList equipmentList = new ArrayList();
        string currentItem = "";

        //loop adding items until user enters "exit"
        while (true)
        {
            
            currentItem = Console.ReadLine();

            if (currentItem == "exit")
            {
                break;
            }

            equipmentList.Add(currentItem);
            Console.Write("\t>> ");
        }

        var equipment = string.Join("|", equipmentList.ToArray());

        handler.AppendCharacter(new Character
        {
            Name = name,
            Profession = className,
            Level = Convert.ToInt32(level),
            HP = Convert.ToInt32(hp),
            Equipment = equipment.Split("|").ToArray()
        });
    }

    static void LevelUpCharacter()
    {
        AnsiConsole.MarkupLine("\n[bold red3]===[/] [bold]Level Up Character[/] [bold red3]===[/]\n");

        List<Character> characters = handler.ReadAll();

        Console.Write("Enter character name to level up >> ");
        string nameToFind = Console.ReadLine();



        try
        {
            foreach (Character character in characters)
            {
                if (character.Name == nameToFind)
                {
                    //TODO: Add either progress bar or status spinner 
                    character.Level += 1;
                    AnsiConsole.MarkupLine($"\n[bold DeepSkyBlue4_2]{character.Name} has leveled up to level {character.Level}![/]");
                    break;
                }
            }

            handler.WriteAll(characters);
        }
        catch
        {
            Console.WriteLine("\nThere was an error with the Character search.");
        }

    }

    static void FindCharacter()
    {
        AnsiConsole.MarkupLine("\n[bold red3]===[/] [bold]Find Character[/] [bold red3]===[/]\n");
        Console.Write("Enter character name to find >> ");
        string nameToFind = Console.ReadLine();

        Character c = handler.FindByName(handler.ReadAll(), nameToFind);

        var characterTable = new Table()
                .AddColumn("[DeepSkyBlue4_2]Name[/]")
                .AddColumn("[DeepSkyBlue4_2]Class[/]")
                .AddColumn("[DeepSkyBlue4_2]Level[/]")
                .AddColumn("[DeepSkyBlue4_2]HP[/]")
                .AddColumn("[DeepSkyBlue4_2]Equipment list[/]")
                .AddRow(
                    $"[LightCyan3]{c.Name}[/]",
                    $"[LightCyan3]{c.Profession}[/]",
                    $"[LightCyan3]{c.Level}[/]",
                    $"[LightCyan3]{c.HP}[/]",
                    $"[LightCyan3]{string.Join(", ", c.Equipment)}[/]"
                    );

        AnsiConsole.Write(characterTable);

    }
}

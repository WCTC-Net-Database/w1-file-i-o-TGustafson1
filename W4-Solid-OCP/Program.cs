using Spectre.Console;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks.Dataflow;
using W3_LINQ_and_SRP;
using W3_LINQ_and_SRP.Models;
using W3_LINQ_and_SRP.Services;

/// <summary>
/// TODO: Revisit using CsvHelper to do all file reading/writing
class Program
{
    // The path to our data file - we'll read and write character data here
    static string filePath = "Files/input.csv";

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
            // Display the menu options
            DisplayMenu();

            // Get user's choice
            AnsiConsole.Markup("[MediumPurple4]Enter your choice >> [/]");
            string choice = Console.ReadLine();

            // Process the user's choice using a switch statement
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

        CharacterReader reader = new CharacterReader(filePath);
        List<Character> charList = reader.ReadCharacters();

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
        CharacterWriter writer = new CharacterWriter(filePath);

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

        writer.AppendCharacter(new Character
        {
            Name = name,
            Profession = className,
            Level = Convert.ToInt32(level),
            HP = Convert.ToInt32(hp),
            Equipment = equipment.Split("|").ToArray()
        });

        //Short test of full rewrite
        //CharacterReader reader = new CharacterReader(filePath);
        //List<Character> charList = reader.ReadCharacters();

        //charList.Add(new Character(name, className, int.Parse(level), int.Parse(hp), equipment.Split("|")));
        //writer.WriteAllLines(charList);

        //Console.WriteLine($"\nYour new character {name} has been created!");
    }

    // Finds a character by name and increases their level by 1.
    // TODO: Fix this to work with quotations?
    static void LevelUpCharacter()
    {
        AnsiConsole.MarkupLine("\n[bold red3]===[/] [bold]Level Up Character[/] [bold red3]===[/]\n");

        CharacterReader reader = new CharacterReader(filePath);
        CharacterWriter writer = new CharacterWriter(filePath);
        List<Character> characters = reader.ReadCharacters();

        //Prompt for character name to level up
        //TODO: Could potentially output all Characters for easier choice when leveling?
        Console.Write("Enter character name to level up >> ");
        string nameToFind = Console.ReadLine();



        try
        {
            foreach (Character character in characters)
            {
                if (character.Name == nameToFind)
                {
                    character.Level += 1;
                    AnsiConsole.MarkupLine($"\n[bold DeepSkyBlue4_2]{character.Name} has leveled up to level {character.Level}![/]");
                    break;
                }
            }

            writer.WriteAllLines(characters);
        }
        catch
        {
            Console.WriteLine("\nThere was an error with the Character search.");
        }
       


        //Read all lines from the file and place into array
        //string[] lines = File.ReadAllLines(filePath);

        //Loop through lines to find the character
        //for (int i = 0; i < lines.Length; i++)
        //{
        //    try
        //    {
        //        if (lines[i].Contains(nameToFind))
        //        {
        //            //Parse the line
        //            string[] details = lines[i].Split(",");

        //            //convert to int and increase level
        //            int charLevel = Convert.ToInt32(details[2]) + 1;

        //            //create new .csv line 
        //            lines[i] = $"{details[0]},{details[1]},{charLevel},{details[3]},{details[4]}";

        //            //write all lines to .csv
        //            File.WriteAllLines(filePath, lines);

        //            Console.WriteLine($"\n{details[0]} has leveled up!");
        //            break;
        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("\nThere was an error with the Character search.");
        //    }
        //}



    }

    static void FindCharacter()
    {
        CharacterReader reader = new CharacterReader(filePath);

        AnsiConsole.MarkupLine("\n[bold red3]===[/] [bold]Find Character[/] [bold red3]===[/]\n");
        Console.Write("Enter character name to find >> ");
        string nameToFind = Console.ReadLine();

        Character c = reader.FindByName(reader.ReadCharacters(), nameToFind);

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

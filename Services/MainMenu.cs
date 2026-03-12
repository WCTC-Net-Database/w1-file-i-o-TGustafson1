using Spectre.Console;
using System.Collections;
using Console_RPG.Models.Classes;
using Console_RPG.Data;
using Console_RPG.Models.Monsters;
using Console_RPG.Models;
using Console_RPG.Interfaces;

namespace Console_RPG.Services
{
    public class MainMenu
    {
        private readonly IContext _context;

        public MainMenu(IContext context)
        {
            _context = context;
        }
        public void RunMenu()
        {
            // Welcome message
            UIService.WriteHeadline($"Console RPG Character Manager");

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
                        RunGame();
                        break;
                    case "2":
                        DisplayAllCharacters();
                        break;
                    case "3":
                        AddCharacter();
                        break;
                    case "4":
                        LevelUpCharacter();
                        break;
                    case "5":
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

        private void DisplayMenu()
        {
            AnsiConsole.MarkupLine("[bold DeepSkyBlue4_2]What would you like to do?[/]");
            var menuTable = new Table()
                .AddColumn("[DeepSkyBlue4_2]Input[/]")
                .AddColumn("[DeepSkyBlue4_2]Description[/]")
                .AddRow("[LightCyan3]1.[/]", "Run Game")
                .AddRow("[LightCyan3]2.[/]", "Display All Characters")
                .AddRow("[LightCyan3]3.[/]", "Add New Character")
                .AddRow("[LightCyan3]4.[/]", "Level Up Character")
                .AddRow("[LightCyan3]5.[/]", "Find Character")
                .AddRow("[LightCyan3]6.[/]", "Switch File Format")
                .AddRow("[LightCyan3]0.[/]", "Exit");
            AnsiConsole.Write(menuTable);
        }

        /// <summary>
        /// Displays all characters by reading from file and printing.
        /// </summary>
        private void DisplayAllCharacters()
        {

            UIService.WriteHeadline("All Characters");

            var characterTable = new Table()
                    .AddColumn("[DeepSkyBlue4_2]Name[/]")
                    .AddColumn("[DeepSkyBlue4_2]Type[/]")
                    .AddColumn("[DeepSkyBlue4_2]Level[/]")
                    .AddColumn("[DeepSkyBlue4_2]HP[/]")
                    .AddColumn("[DeepSkyBlue4_2]Equipment list[/]");

            foreach (CharacterBase c in _context.Characters)
            {
                characterTable.AddRow(
                    $"[LightCyan3]{c.Name}[/]",
                    $"[LightCyan3]{c.Type}[/]",
                    $"[LightCyan3]{c.Level}[/]",
                    $"[LightCyan3]{c.HP}[/]",
                    $"[LightCyan3]{string.Join(", ", c.Equipment)}[/]"
                    );
            }

            AnsiConsole.Write(characterTable);

        }

        //Prompt user for new character details and append the character to the file
        private void AddCharacter()
        {

            UIService.WriteHeadline("Add New Character");

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

            // TODO: Revisit using CharacterFactory and whether or not it's appropriate
            var factory = new CharacterFactory();
            var character = factory.CreateCharacter(
                name,
                className,
                Convert.ToInt32(level),
                Convert.ToInt32(hp),
                equipment.Split("|").ToArray()
            );

            _context.AddCharacter(character);
        }

        private void LevelUpCharacter()
        {
            UIService.WriteHeadline("Level Up Character");

            Console.Write("Enter character name to level up >> ");
            string nameToFind = Console.ReadLine();

            try
            {
                foreach (CharacterBase character in _context.Characters)
                {
                    if (character.Name == nameToFind)
                    {
                        //TODO: Add either progress bar or status spinner 
                        character.Level += 1;
                        AnsiConsole.MarkupLine($"\n[bold DeepSkyBlue4_2]{character.Name} has leveled up to level {character.Level}![/]");
                        _context.UpdateCharacter(character);
                        break;
                    }
                }

            }
            catch
            {
                Console.WriteLine("\nThere was an error with the Character search.");
            }

        }

        private void FindCharacter()
        {
            AnsiConsole.MarkupLine("\n[bold red3]===[/] [bold]Find Character[/] [bold red3]===[/]\n");
            Console.Write("Enter character name to find >> ");
            string nameToFind = Console.ReadLine();

            CharacterBase c = _context.Characters.FirstOrDefault(c => c.Name == nameToFind);

            var characterTable = new Table()
                    .AddColumn("[DeepSkyBlue4_2]Name[/]")
                    .AddColumn("[DeepSkyBlue4_2]Class[/]")
                    .AddColumn("[DeepSkyBlue4_2]Level[/]")
                    .AddColumn("[DeepSkyBlue4_2]HP[/]")
                    .AddColumn("[DeepSkyBlue4_2]Equipment list[/]")
                    .AddRow(
                        $"[LightCyan3]{c.Name}[/]",
                        $"[LightCyan3]{c.Type}[/]",
                        $"[LightCyan3]{c.Level}[/]",
                        $"[LightCyan3]{c.HP}[/]",
                        $"[LightCyan3]{string.Join(", ", c.Equipment)}[/]"
                        );

            AnsiConsole.Write(characterTable);

        }

        private void RunGame()
        {
            UIService.WriteHeadline("Running Game");

            //TODO: Use Factory Pattern to create character based on selected character/class from file instead of hardcoding. 
            var character = new Fighter();

            //TODO: Read monster details from file and create monsters based on that instead of hardcoding.
            var goblin = new Goblin();
            var ghost = new Ghost();
            var zombie = new Zombie();

            List<IEntity> entities = new List<IEntity>()
            {
                character,
                goblin,
                ghost,
                zombie
            };


            var gameEngine = new GameEngine(entities);
            gameEngine?.Run();
        }

    }
}

/// <summary>
class Program
{
    // The path to our data file - we'll read and write character data here
    static string filePath = "Files/input.csv";

    static void Main()
    {
        // Welcome message
        Console.WriteLine("=== Console RPG Character Manager ===");
        Console.WriteLine("Week 1: File I/O Basics\n");

        // Main program loop - keeps running until user chooses to exit
        bool running = true;
        while (running)
        {
            // Display the menu options
            DisplayMenu();

            // Get user's choice
            Console.Write("\nEnter your choice: ");
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
                case "0":
                    running = false;
                    Console.WriteLine("\nGoodbye! Thanks for playing.");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }

            // Add a blank line for readability between menu displays
            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    /// Displays the main menu options to the user.

    static void DisplayMenu()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Display All Characters");
        Console.WriteLine("2. Add New Character");
        Console.WriteLine("3. Level Up Character");
        Console.WriteLine("0. Exit");
    }

    /// Reads all characters from the CSV file and displays them.
    static void DisplayAllCharacters()
    {
        Console.WriteLine("\n=== All Characters ===\n");

        //reads all lines from .csv and places into string array
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            //Altered to output formatted character data
            string[] fields = line.Split(',');
            Console.WriteLine($"Name:\t\t{fields[0]}");
            Console.WriteLine($"Class:\t\t{fields[1]}");
            Console.WriteLine($"Level:\t\t{fields[2]}");
            Console.WriteLine($"HP:\t\t{fields[3]}");
            Console.WriteLine($"Equipment:\t{fields[4]}");
            Console.WriteLine($"\n======================\n");          
        }
    }

    //Prompt user for new character details and append the character to the .csv file
    static void AddCharacter()
    {
        Console.WriteLine("\n=== Add New Character ===\n");

        //Prompting and reading new character details
        Console.Write("Enter character name: ");
        string name = Console.ReadLine();
        Console.Write("Enter character class: ");
        string className = Console.ReadLine();
        Console.Write("Enter character level: ");
        string level = Console.ReadLine();
        Console.Write("Enter character hP: ");
        string hp = Console.ReadLine();
        Console.Write("Enter character equipment: ");
        string items = Console.ReadLine();


        //assembling new .csv line for appending
        string newCharacter = $"{name},{className},{level},{hp},{items}";

        //appending new character to .csv (including \n to maintain correct .csv formatting - had to manually update base input.csv for accuracy)
        //TODO: Come back and figure out how filePath works - debug output folder "input.csv" gets updated, however original filePath doesn't
        File.AppendAllText(filePath, newCharacter + "\n");
    }

    /// <summary>
    /// Finds a character by name and increases their level by 1.
    ///
    /// TODO: Complete this method to:
    /// 1. Prompt for the character's name
    /// 2. Read all lines from the file
    /// 3. Find the line containing that character
    /// 4. Parse the line, increase the level, rebuild the line
    /// 5. Write all lines back to the file
    ///
    /// This is more challenging because you need to modify existing data!
    ///
    /// HINT: You'll need to:
    /// - Read all lines into an array
    /// - Loop through to find the matching character
    /// - Modify that line (parse, change level, rebuild)
    /// - Write all lines back using File.WriteAllLines()
    /// </summary>
    static void LevelUpCharacter()
    {
        Console.WriteLine("\n=== Level Up Character ===\n");

        // TODO: Prompt for character name to level up
        Console.Write("Enter character name to level up: ");
        string nameToFind = Console.ReadLine();

        // TODO: Read all lines from the file
        // string[] lines = File.ReadAllLines(filePath);

        // TODO: Loop through lines to find the character
        // TODO: Parse the line, increase level, rebuild
        // TODO: Write all lines back to the file

        Console.WriteLine("TODO: Implement level up functionality");
    }
}

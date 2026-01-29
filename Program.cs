/// <summary>
/// Week 1: File I/O Basics - Console RPG Character Manager
///
/// This program teaches fundamental file operations in C#:
/// - Reading data from CSV files using File.ReadAllLines()
/// - Parsing comma-separated values using String.Split()
/// - Writing data back to files using File.WriteAllLines()
///
/// The menu structure is provided for you to review and understand.
/// Your tasks are marked with TODO comments throughout the code.
/// </summary>
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

    /// <summary>
    /// Displays the main menu options to the user.
    /// This is complete - review it to understand the structure.
    /// </summary>
    static void DisplayMenu()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Display All Characters");
        Console.WriteLine("2. Add New Character");
        Console.WriteLine("3. Level Up Character");
        Console.WriteLine("0. Exit");
    }

    /// <summary>
    /// Reads all characters from the CSV file and displays them.
    ///
    /// TODO: Complete this method to:
    /// 1. Read all lines from the file using File.ReadAllLines()
    /// 2. Loop through each line
    /// 3. Split each line by comma to get individual fields
    /// 4. Display the character information in a readable format
    ///
    /// CSV Format: Name,Class,Level,HP,Equipment
    /// Example: John,Fighter,1,10,sword|shield|potion
    /// </summary>
    static void DisplayAllCharacters()
    {
        Console.WriteLine("\n=== All Characters ===\n");

        // Step 1: Read all lines from the file
        // File.ReadAllLines() returns a string array where each element is one line
        string[] lines = File.ReadAllLines(filePath);

        // Step 2: Loop through each line and display it
        // TODO: Instead of just printing the raw line, parse it and display nicely
        //
        // HINTS:
        // - Use line.Split(',') to separate the fields
        // - The fields are: Name (index 0), Class (1), Level (2), HP (3), Equipment (4)
        // - Equipment contains multiple items separated by '|'
        // - You can split equipment with: equipmentField.Split('|')
        //
        // Example output format:
        // Name: John
        // Class: Fighter
        // Level: 1
        // HP: 10
        // Equipment: sword, shield, potion
        // -------------------------

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

    /// <summary>
    /// Prompts the user for character information and adds it to the file.
    ///
    /// TODO: Complete this method to:
    /// 1. Prompt the user for: Name, Class, Level, HP, Equipment
    /// 2. Format the data as a CSV line
    /// 3. Append the new line to the file
    ///
    /// HINT: Use File.AppendAllText(filePath, newLine + "\n") to add to the file
    /// </summary>
    static void AddCharacter()
    {
        Console.WriteLine("\n=== Add New Character ===\n");

        // TODO: Prompt for character details
        // Example:
        // Console.Write("Enter character name: ");
        // string name = Console.ReadLine();
        // ... continue for other fields ...

        // TODO: Format as CSV line
        // string newLine = $"{name},{characterClass},{level},{hp},{equipment}";

        // TODO: Append to file
        // File.AppendAllText(filePath, newLine + "\n");

        Console.WriteLine("TODO: Implement character creation");
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

using CsvHelper;
using System.Globalization;

namespace Console_RPG.Services
{
    internal class CSVFileHandler : IFileHandler
    {
        private string _filePath;

        public CSVFileHandler(string filePath)
        {
            _filePath = filePath;
        }

        // Writing methods for CSV file handling
        public void WriteAll(List<Character> characters)
        {
            List<string> lines = ["Name,Profession,Level,HP,Equipment\r\n"];

            var chars = characters.Select(c => FormatCSVCharacter(c)).ToList();

            lines.AddRange(chars);
            File.WriteAllLines(_filePath, lines);

        }

        public void AppendCharacter(Character character)
        {
            var characterText = FormatCSVCharacter(character);
            File.AppendAllText(_filePath, characterText + "\n");
        }

        private string FormatCSVCharacter(Character character)
        {

            string quotedName;
            string newCharacter;

            if (character.Name.Contains(','))
            {
                quotedName = $"\"{character.Name}\"";
                newCharacter = $"{quotedName},{character.Profession},{character.Level},{character.HP},{string.Join("|", character.Equipment.ToArray())}";

            }
            else
            {
                newCharacter = $"{character.Name},{character.Profession},{character.Level},{character.HP},{string.Join("|", character.Equipment.ToArray())}";
            }

            return newCharacter;
        }

        // Read methods for CSV file handling
        public List<Character> ReadAll()
        {
            List<Character> characters = new List<Character>();

            using (var reader = new StreamReader(_filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {

                    Character lineCharacter = new Character
                    {
                        Name = csv.GetField<string>("Name"),
                        Profession = csv.GetField<string>("Profession"),
                        Level = csv.GetField<int>("Level"),
                        HP = csv.GetField<int>("HP"),
                        Equipment = csv.GetField<string>("Equipment").Split('|')
                    };

                    characters.Add(lineCharacter);
                }
            }

            return characters;
        }

        public Character FindByName(List<Character> characters, string name)
        {
            return characters.FirstOrDefault(c => c.Name == name);
        }

        public List<Character> FindByProfession(List<Character> characters, string profession)
        {
            return characters.Where(c => c.Profession == profession).ToList();
        }
    }
}

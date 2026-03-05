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
        public void WriteAll(List<CharacterBase> characters)
        {
            List<string> lines = ["Name,Profession,Level,HP,Equipment\r\n"];

            var chars = characters.Select(c => FormatCSVCharacter(c)).ToList();

            lines.AddRange(chars);
            File.WriteAllLines(_filePath, lines);

        }

        public void AppendCharacter(CharacterBase character)
        {
            var characterText = FormatCSVCharacter(character);
            File.AppendAllText(_filePath, characterText + "\n");
        }

        private string FormatCSVCharacter(CharacterBase character)
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
        public List<CharacterBase> ReadAll()
        {
            List<CharacterBase> characters = new List<CharacterBase>();

            using (var reader = new StreamReader(_filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {

                    CharacterBase lineCharacter = new CharacterBase
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

        public CharacterBase FindByName(List<CharacterBase> characters, string name)
        {
            return characters.FirstOrDefault(c => c.Name == name);
        }

        public List<CharacterBase> FindByProfession(List<CharacterBase> characters, string profession)
        {
            return characters.Where(c => c.Profession == profession).ToList();
        }
    }
}

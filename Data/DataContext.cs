

using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Console_RPG.Data
{
    public class DataContext :IContext
    {
        public List<CharacterBase> Characters { get; set; }
        private readonly JsonSerializerOptions options;
        public DataContext()
        {
            options = new JsonSerializerOptions
            {
                Converters = { new CharacterBaseConverter() },
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                TypeInfoResolver = new DefaultJsonTypeInfoResolver()
            };

            LoadData();
        }

        private void LoadData()
        {
            var jsonData = File.ReadAllText("Files/input.json");
            Characters = JsonSerializer.Deserialize<List<CharacterBase>>(jsonData, options) ?? new List<CharacterBase>();
        }

        public void AddCharacter(CharacterBase character)
        {
            Characters.Add(character);
            SaveData();
        }

        public void UpdateCharacter(CharacterBase character)
        {
            var existingCharacter = Characters.FirstOrDefault(c => c.Name == character.Name);
            if (existingCharacter != null)
            {
                existingCharacter.Level = character.Level;
                existingCharacter.HP = character.HP;
            }
        }
    }
}

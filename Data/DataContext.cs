

using Console_RPG.Models;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Console_RPG.Data
{
    public class DataContext :IContext
    {
        public List<EntityBase> Entities { get; set; }
        public List<CharacterBase> Characters { get; set; }
        public List<MonsterBase> Monsters { get; set; }

        private readonly JsonSerializerOptions options;
        public DataContext()
        {
            //TODO: Look into whether custom converter is required or if polymorphic typing can be used in its place.
            options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                TypeInfoResolver = new DefaultJsonTypeInfoResolver()
            };

            LoadData();
        }

        private void LoadData()
        {
            var jsonData = File.ReadAllText("Files/input.json");
            Entities = JsonSerializer.Deserialize<List<EntityBase>>(jsonData, options) ?? new List<EntityBase>();

            Characters = Entities.OfType<CharacterBase>().ToList();
            Monsters = Entities.OfType<MonsterBase>().ToList();
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

                //TODO: Implement unique logic for updating players vs monsters if needed

                SaveData();
            }
        }

        public void DeleteCharacter(string characterName)
        {
            var character = Characters.FirstOrDefault(c => c.Name == characterName);
            if (character != null)
            {
                Characters.Remove(character);
                SaveData();
            }
        }

        private void SaveData()
        {
            var jsonData = JsonSerializer.Serialize(Characters, options);
            File.WriteAllText("Files/input.json", jsonData);
        }
    }
}

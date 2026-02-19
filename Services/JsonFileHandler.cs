using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Console_RPG.Services
{
    internal class JsonFileHandler : IFileHandler
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public JsonFileHandler(string filePath)
        {
            _filePath = filePath;
        }

        public List<Character> ReadAll()
        {
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Character>>(json) ?? new List<Character>();
        }

        public void AppendCharacter(Character character)
        {
            var characters = ReadAll();
            characters.Add(character);
            WriteAll(characters);
        }

        public void WriteAll(List<Character> characters)
        {
            string json = JsonSerializer.Serialize(characters, _options);
            File.WriteAllText(_filePath, json);
        }

        public Character? FindByName(List<Character> characters, string name)
        {
            return characters.FirstOrDefault(c =>
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Character> FindByProfession(List<Character> characters, string profession)
        {
            return characters.Where(c =>
                c.Profession.Equals(profession, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}

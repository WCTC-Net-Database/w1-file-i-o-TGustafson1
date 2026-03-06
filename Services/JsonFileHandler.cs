using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Console_RPG.Models.Classes;

namespace Console_RPG.Services
{
    internal class JsonFileHandler : IFileHandler
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _options = new() 
        { 
            WriteIndented = true, 
            PropertyNameCaseInsensitive = true,
            TypeInfoResolver = new DefaultJsonTypeInfoResolver()
        };

        public JsonFileHandler(string filePath)
        {
            _filePath = filePath;
        }

        public List<CharacterBase> ReadAll()
        {
            string json = File.ReadAllText(_filePath);
            
            return JsonSerializer.Deserialize<List<CharacterBase>>(json, _options) ?? new List<CharacterBase>();
        }

        public void AppendCharacter(CharacterBase character)
        {
            var characters = ReadAll();
            characters.Add(character);
            WriteAll(characters);
        }

        public void WriteAll(List<CharacterBase> characters)
        {
            string json = JsonSerializer.Serialize(characters, _options);
            File.WriteAllText(_filePath, json);
        }

        public CharacterBase? FindByName(List<CharacterBase> characters, string name)
        {
            return characters.FirstOrDefault(c =>
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<CharacterBase> FindByProfession(List<CharacterBase> characters, string profession)
        {
            return characters.Where(c =>
                c.Profession.Equals(profession, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }

}
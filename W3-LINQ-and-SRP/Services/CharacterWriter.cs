using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Linq;
using W3_LINQ_and_SRP.Models;

namespace W3_LINQ_and_SRP.Services
{
    internal class CharacterWriter
    {
        private string _filePath;

        public CharacterWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void WriteAllLines(List<Character> characters)
        {
            var lines = characters.Select(c => FormatCSVCharacter(c)).ToList();


        }

        //appends single line of text to file
        public void AppendCharacter(Character character)
        {
            var characterText = FormatCSVCharacter(character);
            File.AppendAllText(_filePath, characterText + "\n");
        }


        //assembling new .csv line for appending
        private string FormatCSVCharacter(Character character)
        {
            string newCharacter = $"{character.Name},{character.Profession},{character.Level},{character.HP},{string.Join("|", character.Equipment.ToArray())}";
            return newCharacter;
        }


    }
}


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
            List<string> lines = new List<string>();
            lines.Add("Name,Profession,Level,HP,Equipment\r\n");

            var chars = characters.Select(c => FormatCSVCharacter(c)).ToList();

            lines.AddRange(chars);
            File.WriteAllLines(_filePath, lines);

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
           
            string quotedName;
            string newCharacter;

            //handle names with commas by wrapping in quotes
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


    }
}

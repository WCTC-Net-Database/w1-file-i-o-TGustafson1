using System;
using System.Collections.Generic;
using System.Text;
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

        public void WriteCharacters(List<Character> characters)
        {

        }

        public void AppendCharacter(Character character)
        {
        }

        private string FormatCharacter(Character character)
        {
            return "";
        }


    }
}

using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Linq;
using W3_LINQ_and_SRP.Models;

namespace W3_LINQ_and_SRP.Services
{
    public class CharacterReader
    {
        private string _filePath;

        public CharacterReader(string filePath)
        {
            _filePath = filePath;
        }

        //read all characters from file and return as List
        public List<Character> ReadCharacters()
        {
            List<Character> characters = new List<Character>();

            using (var reader = new StreamReader(_filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                csv.Read();
                csv.ReadHeader();
                while (csv.Read()) {

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
            


        // uses LINQ to return first character with matching name
        public Character FindByName(List<Character> characters, string name)
        {
            //TODO: Is null acceptable here?
            return characters.FirstOrDefault(c => c.Name == name);
        }

        // using LINQ to return a List of characters with matching profession
        public List<Character> FindByProfession(List<Character> characters, string profession)
        {
            return characters.Where(c => c.Profession == profession).ToList();
        }

        //moved from Parser.cs, parses a line of CSV into a Character object
        private Character ParseCSVLine(string inputLine)
        {
            string name = "";
            string className = "";
            string level = "";
            string hp = "";
            string equipment = "";


            // if name starts with quotation, separate for storage then continue normally
            if (inputLine.StartsWith("\""))
            {
                int closingQuoteIndex = inputLine.IndexOf("\"", 1);
                name = inputLine.Substring(1, closingQuoteIndex - 1);

                var restOfLine = inputLine.Substring(closingQuoteIndex + 2);

                var lines = restOfLine.Split(",");
                className = lines[0];
                level = lines[1];
                hp = lines[2];
                equipment = lines[3];

            }
            // otherwise grab each detail outright
            else
            {
                var lines = inputLine.Split(',');
                name = lines[0];
                className = lines[1];
                level = lines[2];
                hp = lines[3];
                equipment = lines[4];

            }


            return new Character(name, className, int.Parse(level), int.Parse(hp), equipment.Split('|'));
        }
    }
}

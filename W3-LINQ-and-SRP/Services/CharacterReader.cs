using CsvHelper;
using System;
using System.Collections.Generic;
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

        public List<Character> ReadCharacters()
        {
            //reads all lines from file and places into string array
            string[] lines = File.ReadAllLines(_filePath);
            List<Character> charArray = new List<Character>();

            //skips first line in file (headers) 
            for (int i = 1; i < lines.Length; i++)
            {

                charArray.Add(ParseCSVLine(lines[i]));


                //TODO: copy this into appropriate spot in program.cs

                //Console.WriteLine($"Name:\t\t{name}");
                //Console.WriteLine($"Class:\t\t{className}");
                //Console.WriteLine($"Level:\t\t{level}");
                //Console.WriteLine($"HP:\t\t{hp}");
                //Console.WriteLine($"Equipment list:");
                //foreach (string item in equipmentList)
                //{
                //    Console.WriteLine($"\t\t- {item}");
                //}
                //Console.WriteLine($"\n======================\n");


            }

            return charArray;
        }

        public Character FindByName(List<Character> characters, string name)
        {
            //TODO: Is null acceptable here?
            return characters.FirstOrDefault(c => c.Name == name);
        }

        public List<Character> FindByProfession(List<Character> characters, string profession)
        {
            return characters.Where(c => c.Profession == profession).ToList();
        }

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
                int closingQuote = inputLine.IndexOf("\"", 1);
                name = inputLine.Substring(1, closingQuote - 1);

                var restOfLine = inputLine.Substring(closingQuote + 2);

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

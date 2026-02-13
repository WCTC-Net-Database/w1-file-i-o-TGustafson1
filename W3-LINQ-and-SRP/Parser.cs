using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace W3_LINQ_and_SRP
{
    public class Parser
    {
        public static string[] ParseLine(string inputLine)
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


            return new string[] {name, className, level, hp, equipment};
        }
    }
}

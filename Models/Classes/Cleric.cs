using Console_RPG.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Models.Classes
{
    public class Cleric : CharacterBase
    {
        public Cleric()
        {
            string name = "Unnamed Cleric";
            string type = "Cleric";
            int level = 1;
            int hp = 10;
            string[] equipment = new string[] { "Mace", "Tome" };
        }
        public Cleric(string name, string type, int level, int hp, string[] equipment)
            : base(name, type, level, hp, equipment) { }

        public override void PerformSpecialAction()
        {
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" prays to the gods, receiving divine healing!");
            HP += 5;

        }
    }
}
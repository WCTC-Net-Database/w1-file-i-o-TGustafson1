using Console_RPG.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Console_RPG.Models.Classes
{
    public class Wizard : CharacterBase
    {
        public Wizard()
        {
            string name = "Unnamed Wizard";
            string type = "Wizard";
            int level = 1;
            int hp = 8;
            string[] equipment = new string[] { "Wand", "Orb" };
        }
        public Wizard(string name, string type, int level, int hp, string[] equipment)
            : base(name, type, level, hp, equipment) { }

        public override void PerformSpecialAction()
        {
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" shoots a large fireball, dealing a splash of damage!");
        }
    }
}

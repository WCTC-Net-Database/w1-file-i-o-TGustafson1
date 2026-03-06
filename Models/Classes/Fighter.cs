using Console_RPG.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Models.Classes
{
    public class Fighter : CharacterBase
    {
        public Fighter()
        {
            string name = "Bob the Default Fighter";
            string type = "Fighter";
            int level = 1;
            int hp = 12;
            string[] equipment = new string[] { "Sword", "Shield" };
        }
        public Fighter(string name, string type, int level, int hp, string[] equipment) 
            : base(name, type, level, hp, equipment) { }

        public override void PerformSpecialAction()
        {
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" performs a powerful whirlwind attack, hitting all nearby enemies!");

        }
    }
}

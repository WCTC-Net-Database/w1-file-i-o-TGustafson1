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
            Name = "Bob the Default Fighter";
            Type = "Fighter";
            Level = 1;
            HP = 12;
            Equipment = new string[] { "Sword", "Shield" };
        }
        public Fighter(string name, string type, int level, int hp, string[] equipment) 
            : base(name, type, level, hp, equipment) { }

        public override void PerformSpecialAction()
        {
            UIService.WriteName(base.Name, Styling);
            Console.WriteLine(" performs a powerful whirlwind attack, hitting all nearby enemies!");

        }
    }
}

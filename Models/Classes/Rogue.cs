using Console_RPG.Interfaces;
using Console_RPG.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Models.Classes
{
    public class Rogue : CharacterBase, ISneakable

    {
        public Rogue()
        {
            string name = "Unnamed Rogue";
            string type = "Rogue";
            int level = 1;
            int hp = 8;
            string[] equipment = new string[] { "Dagger", "Coin Purse" };
        }
        public Rogue(string name, string type, int level, int hp, string[] equipment)
            : base(name, type, level, hp, equipment) { }

        public override void PerformSpecialAction()
        {
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" decides to sneak around their foe...");
            Sneak();
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" successfully sneaks around and lands a critical hit!");
        }

        public void Sneak()
        {
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" sneaks around, avoiding detection.");
        }

    }
}

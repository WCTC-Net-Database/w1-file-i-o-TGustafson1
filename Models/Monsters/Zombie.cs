using Console_RPG.Interfaces;
using Console_RPG.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Models.Monsters
{
    public class Zombie : MonsterBase, IRevivable
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public Style Styling { get; } = new Style(foreground: Color.Chartreuse4, decoration: Decoration.Bold);
        public Zombie()
        {
            Name = "Generic Zombie";
            HP = 15;
        }

        public void Attack(IEntity target)
        {
            UIService.WriteName(Name, Styling);
            Console.Write($" attacks ");
            UIService.WriteName(target.Name, target.Styling);
            Console.WriteLine(" with its blood soaked hands.");
        }

        public void Move()
        {
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" shambles around while groaning.");
        }

        public void Revive()
        {
            HP = 20;
            UIService.WriteName(Name, Styling);
            Console.WriteLine($" has been revived and is now a formidable foe!");
        }
    }
}

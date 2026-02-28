using Console_RPG.Interfaces;
using Console_RPG.Services;
using Spectre.Console;

namespace Console_RPG.Models
{
    public class Goblin : IEntity, ISneakable
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public Style Styling { get; } = new Style(foreground: Color.Chartreuse4, decoration: Decoration.Bold);

        public Goblin() { 
            Name = "Generic Goblin";
            HP = 18;
        }
        public void Attack(IEntity target)
        {
            ConsoleService.WriteName(Name, Styling);
            Console.Write(" attacks ");
            ConsoleService.WriteName(target.Name, target.Styling);
            Console.WriteLine(" while laughing mischievously.");
        }

        public void Move()
        {
            ConsoleService.WriteName(Name, Styling);
            Console.WriteLine(" moves quickly.");
        }

        public void Sneak()
        {
            ConsoleService.WriteName(Name, Styling);
            Console.WriteLine(" sneaks around, avoiding detection.");

        }
    }
}

using Console_RPG.Interfaces;
using Console_RPG.Services;
using Spectre.Console;

namespace Console_RPG.Models.Monsters
{
    public class Goblin : MonsterBase, ISneakable, IDodgeable
    {
        public override Style Styling { get; } = new Style(foreground: Color.Green, decoration: Decoration.Bold);

        public Goblin() { 
            base.Name = "Generic Goblin";
            base.HP = 18;
        }
        public void Attack(IEntity target)
        {
            UIService.WriteName(Name, Styling);
            Console.Write(" attacks ");
            UIService.WriteName(target.Name, target.Styling);
            Console.WriteLine(" while laughing mischievously.");
        }

        public void Move()
        {
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" moves quickly.");
        }

        public void Sneak()
        {
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" sneaks around, avoiding detection.");

        }

        public void Dodge()
        {
            Console.Write("\tbut ");
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" dodges swiftly to the side!");

        }
    }
}

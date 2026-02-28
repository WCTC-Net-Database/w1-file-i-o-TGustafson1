using Spectre.Console;
using Console_RPG.Interfaces;

namespace Console_RPG.Models
{
    public class Goblin : IEntity
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public void Attack(IEntity target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} while laughing mischievously.");
        }
        
        public void Move()
        {
            Console.WriteLine($"{Name} moves quickly and sneakily.");
        }
    }
}

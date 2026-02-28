using Console_RPG.Interfaces;


namespace Console_RPG.Models
{
    public class Ghost : IEntity, IFlyable
    {
        public string Name { get; set; }
        public int HP { get; set; }

        public void Attack(IEntity target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} with a chilling touch.");
        }

        public void Move()
        {
            Console.WriteLine($"{Name} floats silently.");
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} flies with a shrieking howl!");
        }
    }
}

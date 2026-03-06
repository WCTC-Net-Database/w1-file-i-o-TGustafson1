using Console_RPG.Interfaces;
using Spectre.Console;
using Console_RPG.Services;


namespace Console_RPG.Models
{
    public class Ghost : IEntity, IFlyable
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public Style Styling { get; } = new Style(foreground: Color.White, decoration: Decoration.Bold);

        public Ghost() {
            Name = "Generic Ghost";
            HP = 12;
        }

        public void Attack(IEntity target)
        {
            UIService.WriteName(Name, Styling);
            Console.Write($" attacks ");
            UIService.WriteName(target.Name, target.Styling);
            Console.WriteLine(" with a chilling touch.");
        }

        public void Move()
        {
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" floats silently.");
        }

        public void Fly()
        {
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" flies with a shrieking howl!");
        }
    }
}

using Console_RPG.Interfaces;
using Spectre.Console;
using Console_RPG.Services;


namespace Console_RPG.Models.Monsters
{
    public class Ghost : MonsterBase, IFlyable
    {
        public override Style Styling { get; } = new Style(foreground: Color.White, decoration: Decoration.Bold);

        public Ghost() {
            base.Name = "Generic Ghost";
            base.HP = 12;
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

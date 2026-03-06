using Console_RPG.Interfaces;
using Console_RPG.Services;
using Spectre.Console;

namespace Console_RPG.Models.Classes
{

    public class CustomCharacter : CharacterBase
    {
        public CustomCharacter() : base()
        {
        }

        public CustomCharacter(string name, string type, int level, int hp, string[] equipment)
            : base(name, type, level, hp, equipment)
        {
        }

        public override void PerformSpecialAction()
        {
            ConsoleService.WriteName(Name, Styling);
            Console.WriteLine(" fails to remember what their specialty is!");
        }
    }
}

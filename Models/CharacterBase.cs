using Console_RPG.Interfaces;
using Spectre.Console;
using Console_RPG.Services;
using System.Text.Json.Serialization;
using Console_RPG.Models.Classes;

namespace Console_RPG
{
    public abstract class CharacterBase : IEntity, ICharacter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public string[] Equipment { get; set; }

        public Style Styling { get; } = new Style(foreground: Color.DeepSkyBlue4_2, decoration: Decoration.Bold);


        public CharacterBase() 
        {
            Name = "Unnamed Character";
            Type = "Classless";
            Equipment = Array.Empty<string>();
        }

        public CharacterBase(string name, string type, int level, int hp, string[] equipment)
        {
            Name = name;
            Type = type;
            Level = level;
            HP = hp;
            Equipment = equipment ?? Array.Empty<string>();
        }

        public override string ToString()
        {
            return $"Name: {Name} - Type: {Type} - Level: {Level} - HP: {HP} - Equipment: [{string.Join(", ", Equipment)}]";
        }

        public virtual void Attack(IEntity target)
        {
            UIService.WriteName(Name, Styling);
            Console.Write($" attacks ");
            UIService.WriteName(target.Name, target.Styling);
            Console.WriteLine(" with a mighty strike!");

        }

        public abstract void PerformSpecialAction();

        public void Move()
        {
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" moves swiftly across the battlefield.");
        }
    }
}

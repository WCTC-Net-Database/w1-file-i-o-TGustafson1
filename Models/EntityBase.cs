using Console_RPG.Interfaces;
using Console_RPG.Services;
using Spectre.Console;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json.Serialization;

namespace Console_RPG.Models
{
    public abstract class EntityBase : IEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }

        public Style Styling { get; } = new Style(foreground: Color.White, decoration: Decoration.Bold);

        public EntityBase()
        {
            Name = "Unnamed Entity";
            Type = "Typeless";
            Level = 1;
            HP = 8;
        }

        public virtual void Attack(IEntity target)
        {
            UIService.WriteName(Name, Styling);
            Console.Write($" attacks ");
            UIService.WriteName(target.Name, target.Styling);
            Console.WriteLine(" with a mighty strike!");
        }


        public virtual void Move()
        {
            UIService.WriteName(Name, Styling);
            Console.WriteLine(" moves swiftly across the battlefield.");
        }
    }

  
}

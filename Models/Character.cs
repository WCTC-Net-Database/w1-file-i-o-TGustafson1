using Console_RPG.Interfaces;
using Console_RPG.Models;
using Spectre.Console;

namespace Console_RPG
{
    public class Character : IEntity, ICharacter
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public string[] Equipment { get; set; }


        public Character() 
        {
            Name = "";
            Profession = "";
            Equipment = Array.Empty<string>();
        }

        public Character(string name, string profession, int level, int hp, string[] equipment)
        {
            Name = name;
            Profession = profession;
            Level = level;
            HP = hp;
            Equipment = equipment ?? Array.Empty<string>();
        }

        public override string ToString()
        {
            return $"Name: {Name} - Profession: {Profession} - Level: {Level} - HP: {HP} - Equipment: [{string.Join(", ", Equipment)}]";
        }

        public void Attack(IEntity target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} with a mighty strike!");
        }

        public void Move()
        {
            Console.WriteLine($"{Name} moves swiftly across the battlefield.");
        }
    }
}

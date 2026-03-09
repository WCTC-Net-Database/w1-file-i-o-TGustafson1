using Console_RPG.Models.Monsters;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Console_RPG.Models
{

    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Goblin), typeDiscriminator: "Console_RPG.Models.Monsters.Goblin")]
    [JsonDerivedType(typeof(Zombie), typeDiscriminator: "Console_RPG.Models.Monsters.Zombie")]
    [JsonDerivedType(typeof(Ghost), typeDiscriminator: "Console_RPG.Models.Monsters.Ghost")]

    public abstract class MonsterBase : EntityBase
    {
        public string Treasure { get; set; }

        public Style Styling { get; } = new Style(foreground: Color.DarkRed, decoration: Decoration.Bold);

        public MonsterBase()
        {
            Treasure = "Unknown Treasure";
        }

        public MonsterBase(string name, string type, int level, int hp, string treasure)
        {
            base.Name = name;
            base.Type = type;
            base.Level = level;
            base.HP = hp;
            Treasure = treasure;
        }
        public override string ToString()
        {
            return $"Name: {base.Name} - Type: {base.Type} - Level: {base.Level} - HP: {base.HP} - Treasure: [{Treasure}]";
        }

    }
}

using Console_RPG.Interfaces;
using Console_RPG.Models.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Services
{
    public class CharacterFactory : ICharacterFactory
    {
        public CharacterBase CreateCharacter (string profession)
        {
            return profession.ToLower() switch
            {
                "fighter" => new Fighter(),
                "cleric" => new Cleric(),
                "wizard" => new Wizard(),
                "rogue" => new Rogue(),
                _ => new CustomCharacter()
            };
        }

        public CharacterBase CreateCharacter(string name, string profession, int level, int hp, string[] equipment)
        {
            CharacterBase character = profession.ToLower() switch
            {
                "Fighter" => new Fighter(name, profession, level, hp, equipment),
                "Cleric" => new Cleric(name, profession, level, hp, equipment),
                "Wizard" => new Wizard(name, profession, level, hp, equipment),
                "Rogue" => new Rogue(name, profession, level, hp, equipment),
                _ => new CustomCharacter(name, profession, level, hp, equipment)
            };

            return character;
        }
    }
}

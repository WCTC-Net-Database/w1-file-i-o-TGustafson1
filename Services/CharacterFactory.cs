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
                //TODO: Implement Cleric, Wizard classes.
                "fighter" => new Fighter(),
                "cleric" => new Cleric(),
                "wizard" => new Wizard()

            };
        }
    }
}

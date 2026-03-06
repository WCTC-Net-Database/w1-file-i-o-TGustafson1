using Console_RPG.Interfaces;
using Console_RPG.Models.Classes;


namespace Console_RPG.Data
{
    public class CharacterFactory : ICharacterFactory
    {
        public CharacterBase CreateCharacter (string type)
        {
            return type.ToLower() switch
            {
                "Console_RPG.Models.Classes.Fighter" => new Fighter(),
                "Console_RPG.Models.Classes.Cleric" => new Cleric(),
                "Console_RPG.Models.Classes.Wizard" => new Wizard(),
                "Console_RPG.Models.Classes.Rogue" => new Rogue(),
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

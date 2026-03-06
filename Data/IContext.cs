using Console_RPG.Models;

namespace Console_RPG.Data
{
    public interface IContext
    {
        List<EntityBase> Entities { get; set; }
        List<CharacterBase> Characters { get; set; }
        List<MonsterBase> Monsters { get; set; }

        void AddCharacter(CharacterBase character);

        void UpdateCharacter(CharacterBase character);

        void DeleteCharacter(string characterName);
    }
}

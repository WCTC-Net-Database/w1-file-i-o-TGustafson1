namespace Console_RPG.Data
{
    public interface IContext
    {
        List<CharacterBase> Characters { get; set; }

        void AddCharacter(CharacterBase character);

        void UpdateCharacter(CharacterBase character);

        void DeleteCharacter(string characterName);
    }
}

namespace Console_RPG.Deprecated;

internal interface IFileHandler
{
    List<CharacterBase> ReadAll();
    void WriteAll(List<CharacterBase> characters);
    void AppendCharacter(CharacterBase character);
    CharacterBase? FindByName(List<CharacterBase> characters, string name);
    List<CharacterBase> FindByProfession(List<CharacterBase> characters, string profession);
}

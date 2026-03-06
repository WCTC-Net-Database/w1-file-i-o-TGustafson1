namespace Console_RPG.Interfaces
{
    public interface ICharacter
    {
        string Type { get; set; }
        string[] Equipment { get; set; }
        int Level { get; set; }

    }
}

namespace Console_RPG.Models
{
    public interface ICharacter
    {
        string Profession { get; set; }
        string[] Equipment { get; set; }
        int Level { get; set; }

    }
}

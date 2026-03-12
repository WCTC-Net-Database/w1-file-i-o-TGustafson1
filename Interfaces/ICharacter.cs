namespace Console_RPG.Interfaces
{
    public interface ICharacter
    {
        string[] Equipment { get; set; }

        void PerformSpecialAction();

    }
}

using Spectre.Console;

namespace Console_RPG.Interfaces
{
    public interface IEntity
    {   
        string Name { get; set; }
        int HP { get; set; }
        void Attack(IEntity target);
        void Move();
    }
}

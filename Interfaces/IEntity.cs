using Spectre.Console;
using System.Text.Json.Serialization;

namespace Console_RPG.Interfaces
{
    public interface IEntity
    {   
        string Name { get; set; }
        string Type { get; set; }
        int Level { get; set; }
        int HP { get; set; }

        
        //experimenting with Spectre Console styling
        Style Styling { get; }

        void Attack(IEntity target);
        void Move();
    }
}

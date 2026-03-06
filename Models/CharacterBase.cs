using Console_RPG.Interfaces;
using Spectre.Console;
using Console_RPG.Services;
using System.Text.Json.Serialization;
using Console_RPG.Models.Classes;
using Console_RPG.Models;

namespace Console_RPG.Models;

public abstract class CharacterBase : EntityBase, ICharacter
{
    
    public string[] Equipment { get; set; }

    //TODO: Do we need to override Styling here? 
    public Style Styling { get; } = new Style(foreground: Color.DeepSkyBlue4_2, decoration: Decoration.Bold);


    public CharacterBase() 
    {
        Equipment = Array.Empty<string>();
    }

    public CharacterBase(string name, string type, int level, int hp, string[] equipment)
    {
        base.Name = name;
        base.Type = type;
        base.Level = level;
        base.HP = hp;
        Equipment = equipment ?? Array.Empty<string>();
    }

    public override string ToString()
    {
        return $"Name: {base.Name} - Type: {base.Type} - Level: {base.Level} - HP: {base.HP} - Equipment: [{string.Join(", ", Equipment)}]";
    }

    public abstract void PerformSpecialAction();

    
}

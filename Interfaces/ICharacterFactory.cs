using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Interfaces
{
    public interface ICharacterFactory
    {
        CharacterBase CreateCharacter(string profession);
    }
}

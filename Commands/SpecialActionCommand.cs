using Console_RPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Commands
{
    public class SpecialActionCommand : ICommand
    {
        private ICharacter _character;
        private IEntity _target;
        public SpecialActionCommand(ICharacter character, IEntity target)
        {
            _character = character;
            _target = target;
        }

        public void Execute()
        {
            _character.PerformSpecialAction();
        }
    }
}

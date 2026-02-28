using Console_RPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Commands
{
    internal class DodgeCommand : ICommand
    {
        private IDodgeable _entity;
        public DodgeCommand(IDodgeable entity) 
        { 
            _entity = entity;
        }

        public void Execute()
        {
            _entity.Dodge();
        }
    }
}

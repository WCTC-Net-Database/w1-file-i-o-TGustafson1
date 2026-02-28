using Console_RPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Commands
{
    
    public class ReviveCommand : ICommand
    {
        private IRevivable _entity;

        public ReviveCommand(IRevivable entity)
        {
            _entity = entity;
        }

        public void Execute()
        {
            _entity.Revive();
        }
    }
}

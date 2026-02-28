using Console_RPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Commands
{
    internal class SneakCommand : ICommand
    {
        private ISneakable _entity;
        public SneakCommand(ISneakable entity) {
            _entity = entity;
        }

        public void Execute()
        {
            _entity.Sneak();
        }
    }
}

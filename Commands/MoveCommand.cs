using Console_RPG.Interfaces;

namespace Console_RPG.Commands
{
    public class MoveCommand : ICommand
    {
        private IEntity _entity;

        public MoveCommand(IEntity entity)
        {
            _entity = entity;
        }

        public void Execute()
        {
            _entity.Move();
        }
    }
}

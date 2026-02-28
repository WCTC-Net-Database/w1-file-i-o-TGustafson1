using Console_RPG.Interfaces;

namespace Console_RPG.Commands
{
    public class AttackCommand : ICommand
    {
        private IEntity _entity;
        private IEntity _target;
        public AttackCommand(IEntity entity, IEntity target)
        {
            _entity = entity;
            _target = target;
        }

        public void Execute()
        {
            _entity.Attack(_target);
        }
    }
}

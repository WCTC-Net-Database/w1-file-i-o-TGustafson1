using Console_RPG.Interfaces;

namespace Console_RPG.Commands
{
    internal class FlyCommand : ICommand
    {
        private IFlyable _entity;

        public FlyCommand(IFlyable entity)
        {
            _entity = entity;
        }

        public void Execute()
        {
            _entity.Fly();
        }
    }
}

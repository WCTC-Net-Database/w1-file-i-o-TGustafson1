using Console_RPG.Interfaces;
using Console_RPG.Models;

namespace Console_RPG.Services
{
    public class GameEngine
    {
        private readonly IEntity _character;
        private readonly IEntity _goblin;
        private readonly IEntity _ghost;

        public GameEngine(IEntity character, IEntity goblin, IEntity ghost)
        {
            _character = character;
            _goblin = goblin;
            _ghost = ghost;
        }

        public void Run()
        {
            _character.Name = "Hero";
            _goblin.Name = "Goblin";
            _ghost.Name = "Ghost";

            ConsoleService.WriteHeadline("Processing Character");
            ProcessEntity(_character);

            ConsoleService.WriteHeadline("Processing Goblin");
            ProcessEntity(_goblin);

            ConsoleService.WriteHeadline("Processing Ghost");
            ProcessEntity(_ghost);

            ConsoleService.WriteHeadline("Combat");
            _character.Attack(_goblin);
            _goblin.Attack(_character);
            _ghost.Attack(_character);
        }

        public void ProcessEntity(IEntity entity)
        {
            entity.Move();

            if (entity is IFlyable flyingEntity)
            {
                flyingEntity.Fly();
            }
            else
            {
                Console.WriteLine($"  {entity.Name} cannot fly.");
            }
        }
    }
}

using Console_RPG.Commands;
using Console_RPG.Interfaces;
using Console_RPG.Models;

namespace Console_RPG.Services
{
    public class GameEngine
    {
        private readonly IEntity _character;
        private readonly IEntity _goblin;
        private readonly IEntity _ghost;

        private List<ICommand> commands = new List<ICommand>();


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

            //TODO: Mock timer/processing time
            ConsoleService.WriteHeadline("Processing Character");
            ProcessEntity(_character);

            ConsoleService.WriteHeadline("Processing Goblin");
            ProcessEntity(_goblin);

            ConsoleService.WriteHeadline("Processing Ghost");
            ProcessEntity(_ghost);

            ConsoleService.WriteHeadline("Movement");
            foreach (var c in commands) {
                c.Execute();
            }

            commands.Clear();

            ConsoleService.WriteHeadline("Combat");
            commands.Add(new AttackCommand(_goblin, _character));
            commands.Add(new AttackCommand(_ghost, _character));
            commands.Add(new AttackCommand(_character, _ghost));

            foreach (var c in commands) {
                c.Execute();
            }
        }

        public void ProcessEntity(IEntity entity)
        {
            if (entity is IFlyable flyingEntity)
            {
                commands.Add(new FlyCommand(flyingEntity));
            }
            else if (entity is ISneakable sneakingEntity)
            {
                commands.Add(new SneakCommand(sneakingEntity));
            }
            else
            {
                commands.Add(new MoveCommand(entity));
            }
        }
    }
}

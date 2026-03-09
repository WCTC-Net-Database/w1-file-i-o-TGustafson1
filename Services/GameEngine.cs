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
        private readonly IEntity _zombie;

        private List<ICommand> commands = new List<ICommand>();


        //TODO: Alter to accept List<IEntity> instead of hardcoding each entity as a parameter.
        public GameEngine(IEntity character, IEntity goblin, IEntity ghost, IEntity zombie)
        {
            _character = character;
            _goblin = goblin;
            _ghost = ghost;
            _zombie = zombie;
        }

        public void Run()
        {
            _character.Name = "Hero";
            _goblin.Name = "Goblin";
            _ghost.Name = "Ghost";
            _zombie.Name = "Zombie";

            List <IEntity> entities = new List<IEntity>() { _character, _goblin, _ghost, _zombie };

            //TODO: Mock timer/processing time

            foreach (var entity in entities) 
            {
                UIService.WriteHeadline($"Processing {entity.Name}");
                ProcessMovement(entity);
            }

            UIService.WriteHeadline("Movement");
            foreach (var c in commands) {
                c.Execute();
            }

            commands.Clear();

            UIService.WriteHeadline("Combat");
            ProcessCombat(_goblin, _character);
            ProcessCombat(_ghost, _character);
            ProcessCombat(_zombie, _character);
            ProcessCombat(_character, _goblin);

            foreach (var c in commands) {
                c.Execute();
            }

            commands.Clear();

            UIService.WriteHeadline("End of Round");

            foreach (var entity in entities) 
            {
                ProcessRoundEnd(entity);
            }

            foreach (var c in commands) {
                c.Execute();
            }

            commands.Clear();
        }

        public void ProcessMovement(IEntity entity)
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

        public void ProcessRoundEnd(IEntity entity) 
        {             
            if (entity is IRevivable revivableEntity)
            {
                if (entity.HP <= 0)
                {
                    commands.Add(new ReviveCommand(revivableEntity));
                }
            }
        }

        public void ProcessCombat(IEntity attacker, IEntity target)
        {
            commands.Add(new AttackCommand(attacker, target));

            if (target is IDodgeable dodgyTarget)
            {
                Random random = new Random();
                if (random.Next(100) < 25)
                {
                    commands.Add(new DodgeCommand(dodgyTarget));
                }
            }
        }
    }
}

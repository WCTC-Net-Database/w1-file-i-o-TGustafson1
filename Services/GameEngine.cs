using Console_RPG.Commands;
using Console_RPG.Interfaces;
using Console_RPG.Models;
using Console_RPG.Models.Classes;

namespace Console_RPG.Services
{
    public class GameEngine
    {
        private readonly List<IEntity> _entities;
        private readonly IEntity _character;
        private List<ICommand> commands = new List<ICommand>();


        //TODO: Alter to accept List<IEntity> instead of hardcoding each entity as a parameter. 
        public GameEngine(List<IEntity> entities)
        {
            _entities = entities;
            _character = _entities.FirstOrDefault(e => e is ICharacter) ?? new CustomCharacter(); ;
        }

        public void Run()
        {

            //TODO: Mock timer/processing time

            foreach (var entity in _entities) 
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
            foreach (MonsterBase monster in _entities.OfType<MonsterBase>()) 
            {
                ProcessCombat(monster, _character);
            }
            if (_entities.Exists(_entities => _entities is IEntity))
            {
                ProcessCombat(_character, _entities.OfType<MonsterBase>().FirstOrDefault());
            }

            foreach (var c in commands) {
                c.Execute();
            }

            commands.Clear();

            UIService.WriteHeadline("End of Round");

            foreach (var entity in _entities) 
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
            if (attacker is ICharacter)
            {
                commands.Add(new SpecialActionCommand((ICharacter)attacker, target));
            }
            else
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
}

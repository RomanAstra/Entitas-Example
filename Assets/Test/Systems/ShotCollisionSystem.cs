using Entitas;

namespace Test.Systems
{
    internal sealed class ShotCollisionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _shotEntities;
        private readonly IGroup<GameEntity> _enemyEntities;

        public ShotCollisionSystem(Contexts contexts)
        {
            _shotEntities = contexts.game.GetGroup(GameMatcher.Bullet);
            _enemyEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Health));
        }

        public void Execute()
        {
            foreach (var shot in _shotEntities)
            {
                var shotPosition = shot.position.Value;
                foreach (var enemy in _enemyEntities)
                {
                    var enemyPosition = enemy.position.Value;
                    if ((enemyPosition - shotPosition).sqrMagnitude < 0.5f)
                    {
                        enemy.ReplaceHealth(enemy.health.Value - 1.0f);
                    }
                }
            }
        }
    }
}

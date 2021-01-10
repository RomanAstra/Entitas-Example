using Entitas;

namespace Test.Systems
{
    internal sealed class ApplyDamageSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _healthEntityGroup;
        
        public ApplyDamageSystem(Contexts contexts)
        {
            _healthEntityGroup = contexts.game.GetGroup(GameMatcher.Health);
        }
        
        public void Execute()
        {
            foreach (var gameEntity in _healthEntityGroup)
            {
                gameEntity.ReplaceHealth(gameEntity.health.Value -= 0.0001f);
            }
        }
    }
}

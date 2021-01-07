using System.Collections.Generic;
using Entitas;

namespace Test.Systems
{
    internal sealed class PositionMoveSystems : ReactiveSystem<GameEntity>
    {
        public PositionMoveSystems(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Position.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var valueTransform = gameEntity.view.Value.transform;
                valueTransform.position = gameEntity.position.Value;
            }
        }
    }
}

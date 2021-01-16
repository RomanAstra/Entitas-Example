using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Test.Systems
{
    internal sealed class PositionMoveSystems : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _context;

        public PositionMoveSystems(Contexts context) : base(context.game)
        {
            _context = context;

            Input.GetAxis("Fire1");
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
                _context.game.viewService.value.SetPosition(gameEntity);
            }
        }
    }
}

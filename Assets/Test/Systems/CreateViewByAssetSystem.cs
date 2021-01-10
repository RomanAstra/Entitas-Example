using System.Collections.Generic;
using System.Linq;
using Entitas;

namespace Test.Systems
{
    internal sealed class CreateViewByAssetSystem : ReactiveSystem<GameEntity>, ITearDownSystem
    {
        private readonly GameContext _contexts;

        public CreateViewByAssetSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Asset.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasAsset;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            for (var i = 0; i < entities.Count; i++)
            {
                var entity = entities[i];
                _contexts.viewService.value.DestroyView(entity);
                _contexts.viewService.value.CreateView(_contexts, entity);
            }
        }

        public void TearDown()
        {
            foreach (var battleEntity in _contexts.GetEntities().Where(a => a.hasView))
            {
                _contexts.viewService.value.DestroyView(battleEntity);
            }
        }
    }
}

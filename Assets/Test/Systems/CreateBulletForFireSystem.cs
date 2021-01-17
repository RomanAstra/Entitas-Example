using System.Collections.Generic;
using Entitas;
using Test.Data;

namespace Test.Systems
{
    internal sealed class CreateBulletForFireSystem: ReactiveSystem<GameEntity>
    {
        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _player;

        public CreateBulletForFireSystem(Contexts context) : base(context.game)
        {
            _context = context.game;
            _player = _context.GetGroup(GameMatcher.Player);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Fire.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var entity = _context.CreateEntity();
                entity.isBullet = true;
                entity.AddAsset(AssetPathWeaponManager.Path[WeaponType.Bullet]);
                entity.AddPosition(_player.GetSingleEntity().position.Value);
                entity.AddRotation(_player.GetSingleEntity().rotation.Value);
            }
        }
    }
}

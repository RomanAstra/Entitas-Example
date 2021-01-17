using Entitas;
using UnityEngine;

namespace Test.Systems
{
    internal sealed class ShotMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public ShotMovementSystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(GameMatcher.Bullet);
        }

        public void Execute()
        {
            foreach (var e in _entities)
            {
                var angle = e.rotation.Value * Mathf.Deg2Rad;
                var dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
                e.ReplacePosition(e.position.Value + dir * 60.0f * Time.deltaTime);
            }
        }
    }
}

using Entitas;
using UnityEngine;

namespace Test.Systems
{
    internal sealed class TestInit : IInitializeSystem
    {
        private readonly Contexts _contexts;

        public TestInit(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Initialize()
        {
            var gameEntity = _contexts.game.CreateEntity();
            gameEntity.ReplacePosition(Vector3.one);
            gameEntity.isPlayer = true;
            gameEntity.AddAsset("Sphere");
            gameEntity.AddHealth(100.0f);
        }
    }
}

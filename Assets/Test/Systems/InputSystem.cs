using Entitas;
using UnityEngine;

namespace Test.Systems
{
    internal sealed class InputSystem : IExecuteSystem
    {
        private readonly Contexts _context;

        public InputSystem(Contexts context)
        {
            _context = context;
        }

        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var gameEntity = _context.game.CreateEntity();
                gameEntity.isFire = true;
            }
        }
    }
}

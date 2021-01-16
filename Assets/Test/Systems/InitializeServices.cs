using Entitas;
using Test.Manager;
using Test.Services;
using UnityEngine;

namespace Test.Systems
{
    internal sealed class InitializeServices : IInitializeSystem
    {
        private readonly GameContext _context;

        public InitializeServices(Contexts context)
        {
            _context = context.game;
            Input.GetAxis(AxisManager.FIRE);
        }
        
        public void Initialize()
        {
            _context.SetViewService(new ViewService(new PrefabLoader()));
        }
    }
}

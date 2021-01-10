using Entitas;
using Test.Services;

namespace Test.Systems
{
    internal sealed class InitializeServices : IInitializeSystem
    {
        private readonly GameContext _context;

        public InitializeServices(Contexts context)
        {
            _context = context.game;
        }
        
        public void Initialize()
        {
            _context.SetViewService(new ViewService(new PrefabLoader()));
        }
    }
}

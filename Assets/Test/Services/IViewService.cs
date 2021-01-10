using Entitas.CodeGeneration.Attributes;

namespace Test.Services
{
    [Game, Unique, ComponentName("ViewService")]
    public interface IViewService
    {
        void CreateView(GameContext context, GameEntity entity);
        void DestroyView(GameEntity entity);
        void SetParent(GameEntity entity);
        void SetPosition(GameEntity entity);
    }
}

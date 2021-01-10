using Entitas;

namespace Test.Services
{
    public interface IEventListener
    {
        void CreateListeners(IEntity entity);
        void DestroyListeners();
    }
}

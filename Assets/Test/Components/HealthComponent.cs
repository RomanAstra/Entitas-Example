using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Test.Components
{
    [Game, Event(EventTarget.Self)]
    public sealed class HealthComponent : IComponent
    {
        public float Value;
    }
}

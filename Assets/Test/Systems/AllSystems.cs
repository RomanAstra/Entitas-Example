namespace Test.Systems
{
    internal sealed class AllSystems : Feature
    {
        public AllSystems(Contexts contexts)
        {
            Add(new TestInit(contexts));
            Add(new PositionMoveSystems(contexts));
        }
    }
}

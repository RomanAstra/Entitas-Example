namespace Test.Systems
{
    internal sealed class AllSystems : Feature
    {
        public AllSystems(Contexts contexts)
        {
            Add(new InitializeServices(contexts));
            Add(new TestInit(contexts));
            Add(new GameEventSystems(contexts));
            Add(new PositionMoveSystems(contexts));
            Add(new ApplyDamageSystem(contexts));
            Add(new CreateViewByAssetSystem(contexts));
            Add(new InputSystem(contexts));
            Add(new CreateBulletForFireSystem(contexts));
            Add(new ShotMovementSystem(contexts));
        }
    }
}

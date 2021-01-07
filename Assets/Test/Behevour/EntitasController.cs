using Test.Systems;
using UnityEngine;

namespace Test.Behevour
{
    internal sealed class EntitasController : MonoBehaviour
    {
        private Entitas.Systems _systems;

        private void Start()
        {
            _systems = new AllSystems(new Contexts());
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private void OnDestroy()
        {
            _systems.TearDown();
        }
    }
}

using UnityEngine;

namespace Test.Services
{
    internal sealed class PrefabLoader : IPrefabLoader
    {
        public GameObject GetPrefab(string name)
        {
            return Resources.Load<GameObject>(name);
        }
    }
}

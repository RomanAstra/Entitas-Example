using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Test.Services
{
    [Game, Unique, ComponentName("PrefabLoader")]
    public interface IPrefabLoader
    {
        GameObject GetPrefab(string name);
    }
}

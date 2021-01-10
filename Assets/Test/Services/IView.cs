using UnityEngine;

namespace Test.Services
{
    public interface IView
    {
        Transform Transform { get; }
        GameObject GameObject { get; }
        void InitializeView(GameEntity entity);
        void SetActive(bool isActive);
        void SetParent(Transform parent, bool worldPositionStays = false);
        Vector3 GetPosition();
        void SetPosition(Vector3 position, bool isTween = false);
        void SetRotation(Quaternion rotation);
        void DestroyView();
    }
}

using Entitas.Unity;
using UnityEngine;

namespace Test.Services
{
    [RequireComponent(typeof(EntityLink))]
    internal sealed class UnityView : MonoBehaviour, IView
    {
        private EntityLink _entityLink;
        Transform IView.Transform => transform;
        GameObject IView.GameObject => gameObject;

        public void InitializeView(GameEntity entity)
        {
            _entityLink = gameObject.GetComponent<EntityLink>();
            if (_entityLink == null)
            {
                _entityLink = gameObject.AddComponent<EntityLink>();
            }

            entity.AddView(this);
            _entityLink = gameObject.Link(entity);

            var eventListeners = gameObject.GetComponents<IEventListener>();
            foreach (var listener in eventListeners)
            {
                listener.CreateListeners(entity);
            }

            if (entity.hasPosition)
            {
                SetPosition(entity.position.Value);
            }
        }

        public void UnlinkGameObject()
        {
            var eventListeners = gameObject.GetComponents<IEventListener>();
            foreach (var listener in eventListeners)
            {
                listener.DestroyListeners();
            }

            gameObject.Unlink();
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetParent(Transform parent, bool worldPositionStays = true)
        {
            transform.SetParent(parent, worldPositionStays);
        }

        public Vector3 GetPosition()
        {
            return transform.localPosition;
        }

        public void SetPosition(Vector3 position, bool isTween = false)
        { 
            transform.localPosition = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }

        public void DestroyView()
        {
            GameEntity thisEntity = (GameEntity) _entityLink.entity;
            UnlinkGameObject();
            Destroy(gameObject);

            // thisEntity.isAssetLoaded = false;
        }

        private void OnDestroy()
        {
            UnlinkGameObject();
        }
    }
}
using Entitas;
using Test.Services;
using UnityEngine;

namespace Test.View
{
    internal sealed class HealthBehaviour : MonoBehaviour, IEventListener, IHealthListener
    {
        [SerializeField] private TextMesh _textMesh;
        private GameEntity _gameEntity;

        public void CreateListeners(IEntity entity)
        {
            _gameEntity = (GameEntity)entity;
            _gameEntity.AddHealthListener(this);
        }

        public void DestroyListeners()
        {
            _gameEntity.RemoveHealthListener();
        }

        public void OnHealth(GameEntity entity, float value)
        {
            _textMesh.text = $"{value}";
        }
    }
}

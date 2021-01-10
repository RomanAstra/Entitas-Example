using UnityEngine;

namespace Test.Services
{
    internal sealed class ViewService : IViewService
    { 
        private readonly IPrefabLoader _prefabLoader;
        
        public ViewService(IPrefabLoader prefabLoader)
        {
            _prefabLoader = prefabLoader;
        }
        
        public void CreateView(GameContext context, GameEntity entity)
        {
            var prefab = _prefabLoader.GetPrefab(entity.asset.Value);
            
            var obj = Object.Instantiate(prefab);
            var view = obj.GetComponent<UnityView>();
            view.InitializeView(entity);
            
            // entity.isAssetLoaded = true;
            // if (entity.hasParent)
            // {
            //     SetParent(entity);
            // }
        }

        public void DestroyView(GameEntity entity)
        {
            if (entity.hasView)
            {
                entity.view.Value.DestroyView();
                entity.RemoveView();
            }
        }

        public void SetParent(GameEntity entity)
        {
            // if (entity.hasView)
            // {
            //     entity.view.Value.SetParent(entity.parent.Value);
            // }
        }
        
        public void SetPosition(GameEntity entity)
        {
            if (entity.hasView)
            {
                entity.view.Value.SetPosition(entity.position.Value);
            }
        }
    }
}

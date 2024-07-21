using System.Collections.Generic;
using _Project.CodeBase.Infrastructure.AssetsManagement;
using _Project.CodeBase.Infrastructure.Services.PersistentProgress;
using _Project.CodeBase.Infrastructure.Services.SaveLoad;
using _Project.CodeBase.Logic.NPC;
using UnityEngine;

namespace _Project.CodeBase.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private const string GuestSpawnPointTag = "GuestSpawnPoint";
        
        private readonly IAssets _assets;
        private readonly AssetProvider _assetProvider;
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();


        public GameFactory(IAssets assets, AssetProvider assetProvider)
        {
            _assets = assets;
            _assetProvider = assetProvider;
        }

        public void CreateGuest(ISaveLoadService saveLoadService, IPersistentProgressService progressService)
        {
            var position = GameObject.FindGameObjectWithTag(GuestSpawnPointTag).transform.position;
            var gameObject = InstantiateRegistered(_assetProvider.guest, position);
            gameObject.GetComponent<NPCLife>().Construct(saveLoadService, progressService);
        }
        
        public void CreateHud() =>
            InstantiateRegistered(_assetProvider.hud);

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegistered(GameObject prefab, Vector3 position)
        {
            GameObject gameObject = _assets.Instantiate(prefab, position);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
		
        private GameObject InstantiateRegistered(GameObject prefab)
        {
            GameObject gameObject = _assets.Instantiate(prefab);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
		
        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter) 
                ProgressWriters.Add(progressWriter);
            ProgressReaders.Add(progressReader);
        }
    }
}
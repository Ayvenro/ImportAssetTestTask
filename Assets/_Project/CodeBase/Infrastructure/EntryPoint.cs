using _Project.CodeBase.Data;
using _Project.CodeBase.Infrastructure.Factories;
using _Project.CodeBase.Infrastructure.Services.PersistentProgress;
using _Project.CodeBase.Infrastructure.Services.SaveLoad;
using VContainer.Unity;

namespace _Project.CodeBase.Infrastructure
{
    public class EntryPoint : IStartable
    {
        private readonly IGameFactory _factory;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public EntryPoint(IGameFactory factory, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _factory = factory;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Start()
        {
            
            InitGameWorld();
            InformProgressReaders();
        }

        private void InitGameWorld()
        {
            LoadProgressOrInitNew();
           _factory.CreateHud();
           InformProgressReaders();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _factory.ProgressReaders) 
                progressReader.LoadProgress(_progressService.Progress);
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress() => new();
    }
}
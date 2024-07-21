using System.Collections.Generic;
using _Project.CodeBase.Infrastructure.Services.PersistentProgress;
using _Project.CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace _Project.CodeBase.Infrastructure.Factories
{
    public interface IGameFactory
    {
        void CreateGuest(ISaveLoadService saveLoadService, IPersistentProgressService progressService);
        void CreateHud();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
    }
}
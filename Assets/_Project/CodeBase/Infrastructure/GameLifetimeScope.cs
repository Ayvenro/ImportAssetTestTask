using _Project.CodeBase.Infrastructure.AssetsManagement;
using _Project.CodeBase.Infrastructure.Factories;
using _Project.CodeBase.Infrastructure.Services;
using _Project.CodeBase.Infrastructure.Services.PersistentProgress;
using _Project.CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.CodeBase.Infrastructure
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private AssetProvider assetProvider;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IAssets, Assets>(Lifetime.Singleton);
            builder.RegisterInstance(assetProvider);
            builder.Register<IPersistentProgressService, PersistentProgressService>(Lifetime.Singleton);
            builder.Register<IGameFactory, GameFactory>(Lifetime.Singleton);
            builder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<EntryPoint>();
        }
    }
}

using _Project.CodeBase.Infrastructure.AssetsManagement;
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
        }
    }
}

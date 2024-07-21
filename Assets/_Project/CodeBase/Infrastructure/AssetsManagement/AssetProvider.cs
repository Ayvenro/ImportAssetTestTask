using UnityEngine;

namespace _Project.CodeBase.Infrastructure.AssetsManagement
{
    [CreateAssetMenu(menuName = "Settings/AssetProvider", fileName = "AssetProvider", order = 0)]
    public class AssetProvider : ScriptableObject
    {
        public GameObject hud;
    }
}
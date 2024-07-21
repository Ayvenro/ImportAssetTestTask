using UnityEngine;

namespace _Project.CodeBase.Infrastructure.AssetsManagement
{
    public interface IAssets
    {
        GameObject Instantiate(GameObject prefab);
        GameObject Instantiate(GameObject prefab, Vector3 at);
    }
}
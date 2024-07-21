using UnityEngine;
using VContainer;

namespace _Project.CodeBase.Infrastructure.AssetsManagement
{
    public class Assets : IAssets
    {
        public GameObject Instantiate(GameObject prefab)
        {
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(GameObject prefab, Vector3 at)
        {
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}
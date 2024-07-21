using System;
using _Project.CodeBase.Infrastructure.Factories;
using StarterAssets;
using UnityEngine;
using VContainer;

namespace _Project.CodeBase.Logic
{
    public class SpawnTrigger : MonoBehaviour
    {
        private IGameFactory _gameFactory;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ThirdPersonController>())
            {
                _gameFactory.CreateGuest();
            }
        }
    }
}
using System;
using _Project.CodeBase.Infrastructure.Factories;
using StarterAssets;
using UnityEngine;
using VContainer;

namespace _Project.CodeBase.Logic
{
    public class SpawnTrigger : MonoBehaviour
    {
        [SerializeField] private float timeBeforeSpawn = 3f;
        
        private IGameFactory _gameFactory;

        private bool _isTimerRunning;
        private float _remainingTime;
        
        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Update()
        {
            if (_isTimerRunning)
            {
                if (_remainingTime > 0)
                {
                    _remainingTime -= Time.deltaTime;
                }
                else
                {
                    _remainingTime = 0;
                    _isTimerRunning = false;
                    _gameFactory.CreateGuest();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ThirdPersonController>())
            {
                _remainingTime = timeBeforeSpawn;
                _isTimerRunning = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<ThirdPersonController>())
            {
                _remainingTime = timeBeforeSpawn;
                _isTimerRunning = false;
            }
        }
    }
}
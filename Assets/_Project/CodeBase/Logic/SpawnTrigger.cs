using System;
using _Project.CodeBase.Infrastructure.Factories;
using _Project.CodeBase.Infrastructure.Services.PersistentProgress;
using _Project.CodeBase.Infrastructure.Services.SaveLoad;
using StarterAssets;
using UnityEngine;
using VContainer;

namespace _Project.CodeBase.Logic
{
    public class SpawnTrigger : MonoBehaviour
    {
        [SerializeField] private float timeBeforeSpawn = 3f;
        
        private IGameFactory _gameFactory;
        private ISaveLoadService _saveLoad;
        private IPersistentProgressService _progressService;

        private bool _isTimerRunning;
        private float _remainingTime;

        [Inject]
        public void Construct(IGameFactory gameFactory, ISaveLoadService saveLoad, IPersistentProgressService progressService)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
            _saveLoad = saveLoad;
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
                    _gameFactory.CreateGuest(_saveLoad, _progressService);
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
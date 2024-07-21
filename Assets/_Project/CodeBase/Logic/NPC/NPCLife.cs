using _Project.CodeBase.Infrastructure;
using _Project.CodeBase.Infrastructure.Services.PersistentProgress;
using _Project.CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace _Project.CodeBase.Logic.NPC
{
    public class NPCLife : MonoBehaviour
    {
        private ISaveLoadService _saveLoad;
        private IPersistentProgressService _progressService;

        public void Construct(ISaveLoadService saveLoad, IPersistentProgressService progressService)
        {
            _saveLoad = saveLoad;
            _progressService = progressService;
        }
        
        public void IncreaseScore()
        {
            _progressService.Progress.Score += 1;
            _saveLoad.SaveProgress();
            Events.IncreaseScore();
            Destroy(this.gameObject);
        }
    }
}
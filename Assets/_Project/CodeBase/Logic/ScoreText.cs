using _Project.CodeBase.Data;
using _Project.CodeBase.Infrastructure;
using _Project.CodeBase.Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;

namespace _Project.CodeBase.Logic
{
    public class ScoreText : MonoBehaviour, ISavedProgressReader
    {
        [SerializeField] private TMP_Text _text;
        
        public void Construct()
        {
            
        }
        
        public void LoadProgress(PlayerProgress progress)
        {
            _text.text = progress.Score.ToString();
        }
    }
}
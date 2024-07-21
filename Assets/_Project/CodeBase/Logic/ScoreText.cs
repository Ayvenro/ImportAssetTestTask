using System;
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

        private PlayerProgress _progress;

        private void Awake()
        {
            Events.OnScoreIncreased += UpdateText;
        }

        private void OnDestroy()
        {
            Events.OnScoreIncreased -= UpdateText;
        }

        private void UpdateText()
        {
            _text.text = _progress.Score.ToString();
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _progress = progress;
            UpdateText();
        }
    }
}
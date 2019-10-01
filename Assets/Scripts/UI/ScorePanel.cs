using System;
using Systems;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScorePanel : MonoBehaviour
    {
        [SerializeField] private Text scoreText = null;
        
        private void Awake()
        {
            EventManager.ScoreChangeEvent += OnScoreChanged;
        }

        private void OnScoreChanged(int score)
        {
            scoreText.text = $"Score: {score}";
        }
    }
}

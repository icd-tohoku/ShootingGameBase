using System;
using Systems;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StatusPanel : MonoBehaviour
    {
        [SerializeField] private Text scoreText = null;
        [SerializeField] private Text lifeText = null;
        
        private void Awake()
        {
            EventManager.ScoreChangeEvent += OnScoreChanged;
            EventManager.LifeChangeEvent += OnLifeChanged;
        }

        /// <summary>
        /// 得点の表示を変える処理
        /// </summary>
        /// <param name="score"></param>
        private void OnScoreChanged(int score)
        {
            scoreText.text = $"Score: {score}";
        }

        /// <summary>
        /// プレイヤーのライフの表示を変える処理
        /// </summary>
        /// <param name="life"></param>
        private void OnLifeChanged(int life)
        {
            lifeText.text = $"Life: {life}";
        }

        private void OnDestroy()
        {
            EventManager.ScoreChangeEvent -= OnScoreChanged;
            EventManager.LifeChangeEvent -= OnLifeChanged;
        }
    }
}

using System;
using Systems;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel = null;
        
        private void Awake()
        {
            gameOverPanel.SetActive(false);
            EventManager.GameOverEvent += OnGameOver;
        }

        private void OnDestroy()
        {
            EventManager.GameOverEvent -= OnGameOver;
        }

        private void OnGameOver()
        {
            // 自身のGameObjectをactiveにする
            gameOverPanel.SetActive(true);
        }

        public void RestartGame()
        {
            var loadScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(loadScene.name);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
#endif
        }
    }
}

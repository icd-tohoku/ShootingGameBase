using ARrietty.Systems;
using UnityEngine;

namespace Systems
{
    public class GameData : SingletonMonoBehaviour<GameData>
    {
        private int _score = 0;
        private int _life = 3;

        /// <summary>
        /// スコアを加算する
        /// </summary>
        /// <param name="point"></param>
        public void AddScore(int point)
        {
            Instance._score += point;
            EventManager.InvokeScoreChangeEvent(Instance._score);
        }

        /// <summary>
        /// プレイヤーのライフを変える
        /// </summary>
        /// <param name="change"></param>
        public void ChangeLife(int change)
        {
            Instance._life += change;
            EventManager.InvokeLifeChangeEvent(Instance._life);

            if (Instance._life <= 0)
            {
                EventManager.InvokeGameOverEvent();
            }
        }
    }
}

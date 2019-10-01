using UnityEngine;

namespace Systems
{
    public static class GameData
    {
        private static int _score = 0;

        public static void AddScore(int point)
        {
            _score += point;
            EventManager.InvokeScoreChangeEvent(_score);
        }
    }
}

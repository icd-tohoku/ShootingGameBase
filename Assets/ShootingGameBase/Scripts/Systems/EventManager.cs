using System;

namespace Shooting.Systems
{
    public static class EventManager
    {
        public static event Action<int> ScoreChangeEvent;
        public static event Action<int> LifeChangeEvent;
        public static event Action GameOverEvent;

        public static void InvokeScoreChangeEvent(int point) => ScoreChangeEvent?.Invoke(point);
        public static void InvokeLifeChangeEvent(int life) => LifeChangeEvent?.Invoke(life);
        public static void InvokeGameOverEvent() => GameOverEvent?.Invoke();
    }
}

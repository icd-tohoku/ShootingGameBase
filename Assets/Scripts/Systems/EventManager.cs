using System;

namespace Systems
{
    public static class EventManager
    {
        public static event Action<int> ScoreChangeEvent;

        public static void InvokeScoreChangeEvent(int point) => ScoreChangeEvent?.Invoke(point);
    }
}

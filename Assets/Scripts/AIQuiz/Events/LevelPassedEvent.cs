using SimpleEventBus.Events;
using UnityEngine;

namespace AIQuiz
{
    public class LevelPassedEvent : EventBase
    {
        public Sprite View { get; }

        public LevelPassedEvent(Sprite view)
        {
            View = view;
        }
    }
}
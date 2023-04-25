using SimpleEventBus.Events;
using UnityEngine;

namespace AIQuiz.Events
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
using System.Collections.Generic;
using SimpleEventBus.Events;
using UnityEngine;

namespace AIQuiz
{
    public class LoadingCompletedEvent : EventBase
    {
        public Dictionary<string,Sprite> Items { get; }

        public LoadingCompletedEvent(Dictionary<string,Sprite> items)
        {
            Items = items;
        }
    }
}
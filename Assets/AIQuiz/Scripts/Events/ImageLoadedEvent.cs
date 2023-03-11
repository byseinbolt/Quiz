using SimpleEventBus.Events;
using UnityEngine;

namespace AIQuiz.Scripts.Events
{
    public class ImageLoadedEvent : EventBase
    {
        public Sprite Sprite { get; }

        public ImageLoadedEvent(Sprite sprite)
        {
            Sprite = sprite;
        }
    }
}
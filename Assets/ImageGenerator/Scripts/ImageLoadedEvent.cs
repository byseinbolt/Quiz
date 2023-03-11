using SimpleEventBus.Events;
using UnityEngine;

namespace ImageGenerator
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
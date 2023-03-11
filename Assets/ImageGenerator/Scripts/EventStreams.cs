using SimpleEventBus;
using SimpleEventBus.Interfaces;

namespace ImageGenerator
{
    public static class EventStreams
    {
        public static IEventBus Game { get; } = new EventBus();
    }
}
using SimpleEventBus;
using SimpleEventBus.Interfaces;

namespace AIQuiz.Scripts.Events
{
    public static class EventStreams
    {
        public static IEventBus AIQuiz { get; } = new EventBus();
    }
}
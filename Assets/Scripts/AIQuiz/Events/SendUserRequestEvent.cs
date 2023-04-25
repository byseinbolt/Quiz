using SimpleEventBus.Events;

namespace AIQuiz.Events
{
    public class SendUserRequestEvent : EventBase
    {
        public string Topic { get; }

        public SendUserRequestEvent(string topic)
        {
            Topic = topic;
        }
    }
}
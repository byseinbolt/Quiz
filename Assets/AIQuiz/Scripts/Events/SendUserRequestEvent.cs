using SimpleEventBus.Events;

namespace AIQuiz.Scripts.Events
{
    internal class SendUserRequestEvent : EventBase
    {
        public string Request { get; }

        public SendUserRequestEvent(string request)
        {
            Request = request;
        }
    }
}
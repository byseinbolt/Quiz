using SimpleEventBus.Events;

namespace ImageGenerator
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
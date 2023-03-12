using SimpleEventBus.Events;

namespace AIQuiz
{
    public class SendUserRequestEvent : EventBase
    {
        public string UserInput { get; }

        public SendUserRequestEvent(string userInput)
        {
            UserInput = userInput;
        }
    }
}
using SimpleEventBus.Events;

namespace Events
{
    public class GoalSelectedEvent : EventBase
    {
        public string Goal { get; }

        public GoalSelectedEvent(string goal)
        {
            Goal = goal;
        }
    }
}
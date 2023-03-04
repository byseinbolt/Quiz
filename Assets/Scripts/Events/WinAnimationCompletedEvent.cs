using SimpleEventBus.Events;

namespace Events
{
    public class WinAnimationCompletedEvent : EventBase
    {
        public Cell Cell { get; }

        public WinAnimationCompletedEvent(Cell cell)
        {
            Cell = cell;
        }
    }
}
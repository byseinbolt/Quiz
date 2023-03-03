using SimpleEventBus.Events;

namespace Events
{
    public class CellClickedEvent : EventBase
    {
        public Cell Cell { get; }

        public CellClickedEvent(Cell cell)
        {
            Cell = cell;
        }
    }
}
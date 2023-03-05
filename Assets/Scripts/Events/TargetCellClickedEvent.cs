using JetBrains.Annotations;
using SimpleEventBus.Events;

namespace Events
{
    public class TargetCellClickedEvent : EventBase
    { 
        public Cell Cell { get; }

        public TargetCellClickedEvent(Cell cell)
        {
            Cell = cell;
        }
    }
}
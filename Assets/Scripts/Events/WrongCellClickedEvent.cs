using SimpleEventBus.Events;
using UnityEngine.UI;

namespace Events
{
    public class WrongCellClickedEvent : EventBase
    {
        public Cell Cell { get; }
        public Button Button { get; }

        public WrongCellClickedEvent(Cell cell, Button button)
        {
            Cell = cell;
            Button = button;
        }
    }
}
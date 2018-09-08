using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    class GameEventArgs : EventArgs
    {
        private readonly EventType eventType;
        public EventType EventType => eventType; 

        public GameEventArgs(EventType eventType)
        {
            this.eventType = eventType;
        }
    }
}

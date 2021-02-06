using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public abstract class MessageEvent
    {
        public event Action EventStarted;
        public event Action EventEnded;

        public void OnEventStarted()
        {
            EventStarted?.Invoke();
        }

        public void OnEventEnded()
        {
            EventEnded?.Invoke();
        }

        public abstract void Execute();
    }
}

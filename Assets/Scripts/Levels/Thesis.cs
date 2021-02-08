using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messaging;

namespace Levels
{
    public class Thesis
    {
        public string Text { get; }
        public MessageType Type { get; }
        public float Pause { get; }
        public Thesis(string text, MessageType type, float pause = 0f)
        {
            this.Text = text;
            this.Type = type;
            this.Pause = pause;
        }
    }
}

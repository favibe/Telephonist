using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Menu
{
    public class IntroText : MonoBehaviour
    {
        public void ActivateIntro()
        {
            /*
Hi there!
Do you mind situation when your phone turns off?
It was because low battary, wasn't it?
Remind it.
And remind good old times with Nokia 3310.
This phone can't turn off with low battary.
I think, if you have the one, it's already On.
But imagine the situation when you need to text to someone with Nokia 3310 and low battary.
I know it's difficult, but just try it.
Forget about comfortable keypad, you have only 10 keys
0: for remove symbol.
1: for punctuation.
2-9 for letters.
Good luck!
             */
            this._display.TypingMessage("Hi there!", MessageType.Outgoing);
            this._display.AddPause(1);
            this._display.TypingMessage("Do you recall situation when your phone turns off?", MessageType.Outgoing);
            this._display.AddPause(2);
            this._display.TypingMessage("It was because low battery, wasn't it?", MessageType.Outgoing);
            this._display.AddPause(2);
            this._display.TypingMessage("Remind it.", MessageType.Outgoing);
            this._display.AddPause(1);
            this._display.TypingMessage("And remind good old times with Nokia 3310.", MessageType.Outgoing);
            this._display.AddPause(2);
            this._display.TypingMessage("This phone can't turn off with low battary.", MessageType.Outgoing);
            this._display.AddPause(2);
            this._display.TypingMessage("I think, if you have the one, it's already On.", MessageType.Outgoing);
            this._display.AddPause(2);
            this._display.TypingMessage("But imagine the situation when you need to text to someone with Nokia 3310 and low battery.", MessageType.Outgoing);
            this._display.AddPause(4);
            this._display.TypingMessage("I know it's difficult, but just try it.", MessageType.Outgoing);
            this._display.AddPause(2);
            this._display.TypingMessage("Forget about comfortable keypad! You have only 10 keys on numpad.", MessageType.Outgoing);
            this._display.AddPause(3);
            this._display.TypingMessage("0: for remove symbol.", MessageType.Outgoing);
            this._display.AddPause(2);
            this._display.TypingMessage("1: for punctuation.", MessageType.Outgoing);
            this._display.AddPause(2);
            this._display.TypingMessage("2-9 for letters.", MessageType.Outgoing);
            this._display.AddPause(2);
            this._display.TypingMessage("Good luck!", MessageType.Outgoing);
            this._display.AddPause(2);
            this._display.TypingMessage("Press '5' to continue...", MessageType.Outgoing);
        }

        [SerializeField] private MessageDisplay _display;
    }
}

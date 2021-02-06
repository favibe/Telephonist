using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Messaging
{
    public class AddMessageEvent : MessageEvent
    {
        public AddMessageEvent(string text, Message prefab, Transform parent)
        {
            _text = text;
            _prefab = prefab;
            _parent = parent;
        }
        public override void Execute()
        {
            OnEventStarted();

            var message = GameObject.Instantiate(_prefab, _parent);
            message.Set(_text);

            OnEventEnded();
        }

        private string _text;
        private Message _prefab;
        private Transform _parent;
    }
}

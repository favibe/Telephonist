using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Messaging
{
    public class TypingMessageEvent : MessageEvent
    {
        public TypingMessageEvent(string text, float speed, Message prefab, Transform parent)
        {
            _text = text;
            _speed = speed;
            _prefab = prefab;
            _parent = parent;
        }
        public override void Execute()
        {
            OnEventStarted();

            var message = GameObject.Instantiate(_prefab, _parent);
            message.TypingEnded += OnMessageTypingEnded;

            message.Type(_text, _speed);
        }

        private void OnMessageTypingEnded(Message message)
        {
            message.TypingEnded -= OnMessageTypingEnded;
            OnEventEnded();
        }

        private string _text;
        private float _speed;
        private Message _prefab;
        private Transform _parent;
    }
}

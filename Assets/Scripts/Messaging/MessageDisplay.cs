using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Messaging
{
    public enum MessageType
    {
        Incoming,
        Outgoing
    }
    public class MessageDisplay : MonoBehaviour
    {
        private void Awake()
        {
            _events = new Queue<MessageEvent>();
        }

        public bool IsEventActive => _isEventActive;
        public int EventsCount => _events.Count;

        public void AddMessage(string text, MessageType type)
        {
            AddMessageEvent messageEvent;

            if (type == MessageType.Incoming)
            {
                messageEvent = new AddMessageEvent(text, _incomingMessagePrefab, _messageArea);
            }
            else
            {
                messageEvent = new AddMessageEvent(text, _outgoingMessagePrefab, _messageArea);
            }

            _events.Enqueue(messageEvent);
        }
        public void TypingMessage(string text, MessageType type, float speed = 10)
        {
            TypingMessageEvent messageEvent;

            if (type == MessageType.Incoming)
            {
                messageEvent = new TypingMessageEvent(text, speed, _incomingMessagePrefab, _messageArea);
            }
            else
            {
                messageEvent = new TypingMessageEvent(text, speed, _outgoingMessagePrefab, _messageArea);
            }

            _events.Enqueue(messageEvent);
        }
        public void AddPause(float time)
        {
            _events.Enqueue(new PauseMessageEvent(time));
        }
        public void AddClear()
        {
            _events.Enqueue(new ClearMessagesCommand(_messageArea));
        }

        private void Update()
        {
            if (!_isEventActive && _events.Count > 0)
            {
                var nextEvent = _events.Dequeue();

                nextEvent.EventStarted += OnEventStarted;
                nextEvent.EventEnded += OnEventEnded;

                nextEvent.Execute();
            }
        }
        private void OnEventStarted()
        {
            _isEventActive = true;
        }
        private void OnEventEnded()
        {
            _isEventActive = false;
        }

        [Header("Prefabs")]
        [SerializeField]
        private Message _incomingMessagePrefab;
        [SerializeField]
        private Message _outgoingMessagePrefab;
        [Header("Settings")]
        [SerializeField]
        private Transform _messageArea;

        private Queue<MessageEvent> _events;
        private bool _isEventActive;
    }
}
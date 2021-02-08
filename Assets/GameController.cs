using Levels;
using Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        public UnityEvent<string> SentenceChanged;

        public void Start()
        {
            this._current = LevelManager.Current;
            _battery.ChargeLossSpeed = 0;

            _battery.MaxCharge = 100;
            _battery.CurrentCharge = 100;

            SentenceChanged.Invoke("Hel");
        }

        public void OnSentenceFinished()
        {
            _messageDisplay.AddMessage("a", MessageType.Incoming);
            _messageDisplay.AddMessage("b", MessageType.Outgoing);
            _messageDisplay.AddMessage("a", MessageType.Incoming);
            _messageDisplay.AddMessage("b", MessageType.Outgoing);
            _messageDisplay.AddMessage("a", MessageType.Incoming);
            _messageDisplay.AddMessage("b", MessageType.Outgoing);
            _battery.ChargeLossSpeed = 2;
            _messageDisplay.AddMessage("Hello Jack!", MessageType.Outgoing);
            _messageDisplay.AddMessage("Hi, Alex...", MessageType.Incoming);
        }

        public void OnBatteryDischarged()
        {
            SceneManager.LoadScene(2);
        }

        private Level _current;
        [SerializeField]
        private MessageDisplay _messageDisplay;
        [SerializeField]
        private Battery _battery;
    }
}
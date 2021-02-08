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
            //SentenceChanged.Invoke("Hel");
            this._current = LevelManager.Current;
        }

        public void OnSentenceFinished()
        {
            _messageDisplay.AddMessage("a", MessageType.Incoming);
            _messageDisplay.AddMessage("b", MessageType.Outgoing);
            _messageDisplay.AddMessage("a", MessageType.Incoming);
            _messageDisplay.AddMessage("b", MessageType.Outgoing);
            _messageDisplay.AddMessage("a", MessageType.Incoming);
            _messageDisplay.AddMessage("b", MessageType.Outgoing);

        }

        public void OnBatteryDischarged()
        {
            SceneManager.LoadScene(2);
        }

        private Level _current;
        [SerializeField]
        private MessageDisplay _messageDisplay;
    }
}
using Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        public UnityEvent<string> SentenceChanged;

        public void Start()
        {
            SentenceChanged.Invoke("Hel");
        }

        public void OnSentenceFinished()
        {
            Debug.Log("Sentence finished");
            _messageDisplay.AddMessage("Hello Jack!", MessageType.Outgoing);
            _messageDisplay.AddMessage("Hi, Alex...", MessageType.Incoming);
        }

        public void OnBatteryDischarged()
        {
            Debug.Log("Battery discharged");
        }

        [SerializeField]
        private MessageDisplay _messageDisplay;
    }
}
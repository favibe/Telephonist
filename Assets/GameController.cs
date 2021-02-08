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
            SentenceChanged.Invoke("Hello Jack!");
        }

        public void OnSentenceFinished()
        {
            Debug.Log("Sentence finished");
        }
    }
}
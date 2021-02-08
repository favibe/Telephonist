using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class OutgoingMessagingController : MonoBehaviour
    {
        public UnityEvent<string> NextWord;
        public UnityEvent SentenceComplete;
        public UnityEvent SpaceAdded;

        public OutgoingMessagingController()
        {
            _sb = new StringBuilder();
        }

        public void SetNextSentence(string sentence)
        {
            _words = sentence.ToUpper().Split(' ');
            _currentIndex = 0;

            NextWord.Invoke(_words[_currentIndex]);
        }

        public void OnSymbolAdded(char symbol)
        {
            _sb.Append(symbol);

            if (_sb.ToString() == _words[_currentIndex])
            {
                _sb.Clear();

                if (_currentIndex == _words.Length-1)
                {
                    SentenceComplete.Invoke();
                    return;
                }

                _currentIndex++;

                NextWord.Invoke(_words[_currentIndex]);
                SpaceAdded.Invoke();
            }
        }

        public void OnSymbolBackspaced()
        {
            _sb.Length--;
        }

        private string[] _words;
        private StringBuilder _sb;

        private int _currentIndex;
    }
}
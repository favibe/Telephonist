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
            LevelManager.InitializeLevels(() => { }, () => { });
            this._current = LevelManager.Current;

            _sentenceFinished = true;
            _battery.ChargeLossSpeed = 0;

            StartCoroutine(GameThread());
        }

        private IEnumerator GameThread()
        {
            while (true)
            {
                if (!_sentenceFinished)
                {
                    yield return null;
                    continue;
                }
                else if (_last != null)
                {
                    _messageDisplay.AddMessage(_last.Text, MessageType.Outgoing);

                    if (_last.Pause > 0)
                        _messageDisplay.AddPause(_last.Pause);

                    _last = null;
                    _current.MoveNext();
                }

                while (_current.Current.Type != MessageType.Outgoing)
                {
                    var message = _current.Current;

                    _messageDisplay.AddMessage(message.Text, MessageType.Incoming);

                    if (message.Pause > 0)
                    {
                        _messageDisplay.AddPause(message.Pause);
                    }

                    _current.MoveNext();
                }

                yield return null;

                while (_messageDisplay.IsEventActive || _messageDisplay.EventsCount > 0)
                {
                    yield return null;
                }

                SentenceChanged.Invoke(_current.Current.Text);
                _sentenceFinished = false;
                _last = _current.Current;
            }
        }

        public void OnSentenceFinished()
        {
            _sentenceFinished = true;
        }

        public void OnBatteryDischarged()
        {
            SceneManager.LoadScene(2);
        }

        private bool _sentenceFinished;
        private Thesis _last;

        private Level _current;
        [SerializeField]
        private MessageDisplay _messageDisplay;
        [SerializeField]
        private Battery _battery;
    }
}
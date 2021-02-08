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
            _current.Restart();
            //this._current.OnSequenceEnded += LevelComplete;

            _sentenceFinished = true;

            if (_current.BattaryCharge == 0)
            {
                _battery.ChargeLossSpeed = 0;
            }
            else
            {
                _battery.ChargeLossSpeed = 1;
                _battery.MaxCharge = _battery.CurrentCharge;
            }

            _gameThread = StartCoroutine(GameThread());
        }

        private IEnumerator GameThread()
        {
            yield return null;

            while (_gameThread != null)
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

                    if (_current.Current == null)
                    {
                        StartCoroutine(LevelComplete());
                        break;
                    }
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

                    if (_current.Current == null)
                    {
                        StartCoroutine(LevelComplete());
                        break;
                    }
                }

                yield return null;

                while (_messageDisplay.IsEventActive || _messageDisplay.EventsCount > 0)
                {
                    yield return null;
                }


                if (_current.Current == null)
                {
                    StartCoroutine(LevelComplete());
                    break;
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


        private IEnumerator LevelComplete()
        {
            while (_messageDisplay.IsEventActive || _messageDisplay.EventsCount > 0)
            {
                yield return new WaitForEndOfFrame();
            }

            StopCoroutine(_gameThread);
            _current.OnLevelEnded();
        }

        public void OnBatteryDischarged()
        {
            SceneManager.LoadScene(3);
        }

        private bool _sentenceFinished;
        private Thesis _last;

        private Level _current;
        [SerializeField]
        private MessageDisplay _messageDisplay;
        [SerializeField]
        private Battery _battery;
        [SerializeField]
        private Coroutine _gameThread;
    }
}
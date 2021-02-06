using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Messaging
{
    public class Message : MonoBehaviour
    {
        public event Action<Message> TypingEnded;

        private void Awake()
        {
            TypingEnded += OnTypingEnded;
        }

        public void Type(string text, float speed = 10f)
        {
            _textView.text = "";
            _typingCoroutine = StartCoroutine(TypeCoroutine(text, 1 / speed));
        }

        public void Set(string text)
        {
            _textView.text = text;
        }

        private IEnumerator TypeCoroutine(string text, float interval)
        {
            for (int i = 0; i < text.Length; i++)
            {
                _textView.text += text[i];

                if (i != text.Length - 1)
                    yield return new WaitForSeconds(interval);
            }

            TypingEnded?.Invoke(this);
        }

        private void OnTypingEnded(Message message)
        {
            if (_typingCoroutine != null)
            {
                StopCoroutine(_typingCoroutine);
                _typingCoroutine = null;
            }
        }

        [SerializeField]
        private TMP_Text _textView;

        private Coroutine _typingCoroutine;
    }
}

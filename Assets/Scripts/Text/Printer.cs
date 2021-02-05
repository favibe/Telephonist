using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Text
{
    public class Printer : MonoBehaviour
    {
        public void PrintImmediately(string text)
        {
            text = text.ToUpper();

            var allowedSymbols = _alphabet
                .Symbols
                .Select(x => x.ID)
                .ToArray();

            for (int i = 0; i < text.Length; i++)
            {
                if (allowedSymbols.Contains(text[i]))
                {
                    var newLetter = Instantiate(_letterPrefab, transform);
                    newLetter.sprite = _alphabet.Symbols.Find(x => x.ID == text[i]).Letter;
                }
                else
                {
                    Debug.Log($"Symbol not exist in alphabet: {text[i]}");
                }
            }

        }

        public IEnumerator PrintWithPause(string text, float pause)
        {
            text = text.ToUpper();

            var allowedSymbols = _alphabet
                .Symbols
                .Select(x => x.ID)
                .ToArray();

            for (int i = 0; i < text.Length; i++)
            {
                if (allowedSymbols.Contains(text[i]))
                {
                    var newLetter = Instantiate(_letterPrefab, transform);
                    newLetter.sprite = _alphabet.Symbols.Find(x => x.ID == text[i]).Letter;

                    yield return new WaitForSeconds(pause);
                }
                else
                {
                    Debug.Log($"Symbol not exist in alphabet: {text[i]}");
                }
            }

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                StartCoroutine(PrintWithPause("WAKE UP NEO YOU OBOSRALSA!", 0.1f));
            }
        }

        [SerializeField]
        private Image _letterPrefab;
        [SerializeField]
        private Alphabet _alphabet;

    }
}
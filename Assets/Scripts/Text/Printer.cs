using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Text
{
    public class Printer : MonoBehaviour
    {
        public void AddSymbol(char symbol)
        {
            if (_isLastTemp)
            {
                _text.Remove(_text.Length - 1);
                _isLastTemp = false;
            }

            _text.Add(symbol);
        }

        public void AddTemporarySymbol(char symbol)
        {
            if (_isLastTemp)
            {
                _text.Remove(_text.Length - 1);
            }

            _text.Add(symbol);
            _isLastTemp = true;
        }

        private bool _isLastTemp;

        [SerializeField]
        private ISpriteText _text;
    }
}
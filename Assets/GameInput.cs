using System;
using System.Collections;
using System.Collections.Generic;
using Text;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class GameInput : MonoBehaviour
    {
        public UnityEvent<char> SymbolEntered;
        public UnityEvent<char> SymbolSelected;
        private GameInput()
        {
            _inputCodes = new Dictionary<KeyCode, char[]>()
            {
                [KeyCode.Alpha1] = new char[] { ' ', '.', '?', '!', '(', ')' },
                [KeyCode.Alpha2] = new char[] { 'A', 'B', 'C' },
                [KeyCode.Alpha3] = new char[] { 'D', 'E', 'F' },
                [KeyCode.Alpha4] = new char[] { 'G', 'H', 'I' },
                [KeyCode.Alpha5] = new char[] { 'J', 'K', 'L' },
                [KeyCode.Alpha6] = new char[] { 'M', 'N', 'O' },
                [KeyCode.Alpha7] = new char[] { 'P', 'Q', 'R', 'S' },
                [KeyCode.Alpha8] = new char[] { 'T', 'U', 'V', 'W' },
                [KeyCode.Alpha9] = new char[] { 'X', 'Y', 'Z' }
            };
        }

        private void Update()
        {
            foreach (KeyCode key in _inputCodes.Keys)
            {
                if (Input.GetKeyDown(key))
                {
                    KeyPressed(key);
                }
            }
        }

        private void FixedUpdate()
        {
            if (_currentTime > 0)
            {
                _currentTime -= Time.fixedDeltaTime;

                if (_currentTime <= 0)
                {

                    SymbolEntered.Invoke(_inputCodes[_lastKey.Value][_curIndex]);

                    _currentTime = 0;
                    _curIndex = 0;
                    _lastKey = null;
                }
            }
        }

        private void KeyPressed(KeyCode key)
        {
            if (_currentTime > 0 && _lastKey.HasValue)
            {
                if (key == _lastKey.Value)
                {
                    _curIndex++;
                    
                    if (_curIndex >= _inputCodes[key].Length)
                        _curIndex = 0;
                }
                else
                {
                    SymbolEntered.Invoke(_inputCodes[_lastKey.Value][_curIndex]);

                    _curIndex = 0;
                    _lastKey = key;
                }
            }
            else
            {
                _curIndex = 0;
                _lastKey = key;
            }

            _currentTime = _timeInterval;
            SymbolSelected.Invoke(_inputCodes[key][_curIndex]);
        }

        public void DebugSelected(char symbol)
        {
            Debug.Log($"Selected symbol: {symbol}");
        }

        public void DebugEntered(char symbol)
        {
            Debug.Log($"Entered symbol: {symbol}");
        }

        [Header("Game components")]
        [SerializeField]
        private Printer _printer;
        [Header("Parameters")]
        [SerializeField]
        private float _timeInterval;
        [Header("Debug")]
        [SerializeField]
        private float _currentTime;
        [SerializeField]
        private int _curIndex;

        private KeyCode? _lastKey;
        private readonly Dictionary<KeyCode, char[]> _inputCodes;

    }
}
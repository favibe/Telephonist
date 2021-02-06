using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{

    public class Typing : MonoBehaviour
    {
        public void SetTemporarySymbol(char symbol)
        {
            _tempSymbol.text = symbol.ToString();
        }

        public void SetTemporaryPanelActive(bool active)
        {
            _tempPanel.SetActive(active);
        }

        public void AddConst(char symbol)
        {
            _constText.text += symbol;
        }

        public void SetExample(string text)
        {
            _exampleText.text = text;
        }

        public void RemoveLast()
        {
            if (_constText.text.Length > 0)
            {
                _constText.text = _constText.text.Remove(_constText.text.Length - 1);
            }
        }

        public void ClearAll()
        {
            _tempSymbol.text = string.Empty;
            _constText.text = string.Empty;
            SetTemporaryPanelActive(false);
        }

        [SerializeField]
        private TMP_Text _tempSymbol;
        [SerializeField]
        private TMP_Text _constText;
        [SerializeField]
        private TMP_Text _exampleText;
        [SerializeField]
        private GameObject _tempPanel;
    }
}
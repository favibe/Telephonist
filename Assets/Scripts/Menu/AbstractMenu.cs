using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Menu
{
    public abstract class AbstractMenu : MonoBehaviour
    {
        public MenuState CurrentState => this._states[this._currentIndex];

        public void MoveNext()
        {
            this._currentIndex++;
            if (this._currentIndex >= this._states.Length)
                this._currentIndex = 0;
        }
        public void MovePrev()
        {
            this._currentIndex--;
            if (this._currentIndex < 0)
                this._currentIndex = this._states.Length - 1;
        }

        public void InitializeStates(params MenuState[] states)
        {
            this._states = states;
        }
        private void Update()
        {
            if (Input.GetKeyDown(this._movePrev))
            {
                this.MovePrev();
                this._menuStateAnimator.SetInteger("State", this.CurrentState.ID);
                return;
            }
            if (Input.GetKeyDown(this._moveNext))
            {
                this.MoveNext();
                this._menuStateAnimator.SetInteger("State", this.CurrentState.ID);
                return;
            }
            if (Input.GetKeyDown(this._invokeCurrent))
            {
                this.CurrentState.InvokeState();
            }
        }

        protected void ExitGame()
        {
            Application.Quit();
        }

        private int _currentIndex;
        protected MenuState[] _states;

        [SerializeField] private Animator _menuStateAnimator;
        [SerializeField] private KeyCode _movePrev = KeyCode.Keypad4;
        [SerializeField] private KeyCode _moveNext = KeyCode.Keypad6;
        [SerializeField] private KeyCode _invokeCurrent = KeyCode.Keypad5;
    }
}

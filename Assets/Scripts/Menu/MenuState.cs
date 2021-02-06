using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Menu
{
    public class MenuState
    {
        public int ID { get; }
        public string Name { get; }
        
        public MenuState(int id, string name, Action action)
        {
            this.ID = id;
            this.Name = name;
            this._onStateInvoked = action;
        }

        public void InvokeState()
        {
            this._onStateInvoked?.Invoke();
        }

        private Action _onStateInvoked;

    }
}

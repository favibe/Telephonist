using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels
{
    public class Level
    {
        public event Action OnSequenceEnded;
        public Thesis Current => this._theses?[this._index];
        public void MoveNext()
        {
            this._index++;
            if(this._index >= this._theses.Length)
            {
                this.OnSequenceEnded?.Invoke();
            }
        }
        
        public Level(params Thesis[] theses)
        {
            this._theses = theses;
            this._index = 0;
        }

        private int _index;
        private readonly Thesis[] _theses;
    }
}

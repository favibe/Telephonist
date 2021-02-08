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
        public Thesis Current => this._theses?[this._index];
        public float BattaryCharge { get; }
        public void MoveNext()
        {
            this._index++;
            if(this._index >= this._theses.Length)
            {
                this._onSequenceEnded?.Invoke();
            }
        }
        
        public Level(float battaryCharge, Action onLevelEnded, params Thesis[] theses)
        {
            this.BattaryCharge = battaryCharge;
            this._theses = theses;
            this._onSequenceEnded = onLevelEnded;
            this._index = 0;
        }
        
        private Action _onSequenceEnded;
        private int _index;
        private readonly Thesis[] _theses;
    }
}

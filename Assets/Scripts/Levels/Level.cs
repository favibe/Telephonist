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
        public Thesis Current => _index > _theses.Length - 1 ? null : this._theses?[this._index];
        public float BattaryCharge { get; }
        public void MoveNext()
        {
            this._index++;
        }

        public void OnLevelEnded()
        {
            this.OnSequenceEnded?.Invoke();
        }
        
        public Level(float battaryCharge, params Thesis[] theses)
        {
            this.BattaryCharge = battaryCharge;
            this._theses = theses;
            this._index = 0;
        }
        
        private int _index;
        private readonly Thesis[] _theses;
    }
}

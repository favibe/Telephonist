using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels
{
    public class Level : MonoBehaviour
    {

        public event Action OnSequanceEnded;
        public Thesis Current => this._theses?[this._index];
        public void MoveNext()
        {
            this._index++;
            if(this._index > this._theses.Length)
            {
                this.OnSequanceEnded?.Invoke();
            }
        }
        private void Awake()
        {
            this._index = 0;
        }

        public static Level Create(params Thesis[] theses)
        {
            GameObject go = new GameObject("Level");
            Level level = go.AddComponent<Level>();
            level._theses = theses;
            return level;
        }



        private int _index;
        private Thesis[] _theses;
    }
}

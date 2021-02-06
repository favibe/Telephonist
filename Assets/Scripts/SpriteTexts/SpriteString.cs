using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text;
using UnityEngine;

namespace SpriteTexts
{
    public class SpriteString : MonoBehaviour, ISpriteText
    {
        
        public static SpriteString Create(SpriteText parent, string s, Vector2 position, Alphabet alphabet)
        {
            GameObject textHandler = new GameObject();
            textHandler.transform.position = position;
            textHandler.transform.SetParent(parent.transform);

            SpriteString text = textHandler.AddComponent<SpriteString>();
            text._alphabet = alphabet;
            foreach(char c in s.ToCharArray())
            {
                text.Add(c);
            }
            return text;
        }

        public int Length => this._text.Count;

        public void Add(char c)
        {
            this.Add(c, this.Length);
        }

        public void Add(char c, int index)
        {
            int pointer = this.GetPixelLength(0, index);
            SpriteSymbol symbol = SpriteSymbol.Create(this, this.GetSymbol(c), (Vector2)this.transform.position + new Vector2(pointer, 0));
            Vector3 offset = new Vector3(symbol.PixelLength, 0);
            for(int i = index; i < this._text.Count; i++)
            {
                this._text[i].transform.position += offset;
            }
            this._text.Insert(index, symbol);
        }

        public void CLear()
        {
            while(this.Length > 0)
            {
                Destroy(this._text[0].gameObject);
            }
        }

        public void Remove(int index)
        {
            SpriteSymbol symbol = this._text[index];
            Vector3 offset = new Vector3(-symbol.PixelLength, 0);
            for(int i = index + 1; i < this.Length; i++)
            {
                this._text[i].transform.position += offset;
            }
            Destroy(symbol.gameObject);
        }

        private void Awake()
        {
            this._text = new List<SpriteSymbol>();
        }

        private Symbol GetSymbol(char c)
        {
            return this._alphabet.Symbols.First(symbol => symbol.ID == c);
        }

        public int GetPixelLength(int startIndex, int endIndex)
        {
            int sum = 0;
            for(int i = startIndex; i < endIndex; i++)
            {
                sum += this._text[i].PixelLength;
            }
            return sum;
        }

        private List<SpriteSymbol> _text;
        private Alphabet _alphabet;
    }
}

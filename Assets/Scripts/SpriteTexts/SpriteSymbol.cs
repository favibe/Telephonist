using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text;
using UnityEngine;

namespace SpriteTexts
{
    public class SpriteSymbol : MonoBehaviour
    {
        public Symbol Symbol { get; private set; }
        public int PixelLength => (int)this.Symbol.Letter.bounds.size.x + 1;

        public static SpriteSymbol Create(SpriteString parent, Symbol symbol, Vector2 position)
        {
            GameObject symbolHandler = new GameObject($"Symbol: {symbol.ID}");
            symbolHandler.transform.SetParent(parent.transform);
            symbolHandler.transform.position = position;

            SpriteSymbol spriteSymbol = symbolHandler.AddComponent<SpriteSymbol>();
            spriteSymbol.Symbol = symbol;

            SpriteRenderer renderer = symbolHandler.AddComponent<SpriteRenderer>();
            renderer.sprite = symbol.Letter;
            renderer.sortingOrder = 10;

            return spriteSymbol;
        }

    }
}

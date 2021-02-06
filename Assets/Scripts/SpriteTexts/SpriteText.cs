using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text;
using UnityEngine;

namespace SpriteTexts
{
    public class SpriteText : MonoBehaviour
    {
        public List<SpriteString> Strings { get; private set; }

        public static SpriteText Create(string s, Vector2 position, int stringHeight, int stringWidth, Alphabet alphabet)
        {
            string[] substrings = s.Split('\n');
            List<string> finalSubStrings = new List<string>();
            foreach(string str in substrings)
            {
                if(str.Length > stringWidth)
                {
                    string[] words = str.Split(' ');
                    string currentStr = "";
                    foreach(string word in words)
                    {
                        if(currentStr.Length + word.Length > stringWidth)
                        {
                            finalSubStrings.Add(currentStr);
                            currentStr = "";
                        }
                        currentStr += word;
                    }
                    if (currentStr != "")
                        finalSubStrings.Add(currentStr);
                }
                else
                {
                    finalSubStrings.Add(str);
                }
            }

            GameObject textHandler = new GameObject("Text");
            textHandler.transform.position = position;

            SpriteText text = textHandler.AddComponent<SpriteText>();
            return text;
        }


        public static int GetPixelWidth(Alphabet alphabet, char c) => (int)alphabet.Symbols.First(s => s.ID == c).Letter.bounds.size.x + 1;
        private void Awake()
        {
            this.Strings = new List<SpriteString>();
        }

    }
}

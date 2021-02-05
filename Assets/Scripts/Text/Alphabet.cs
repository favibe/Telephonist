using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Text
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AlphabetObject", order = 1)]
    public class Alphabet : ScriptableObject
    {
        public List<Symbol> Symbols;
    }
}
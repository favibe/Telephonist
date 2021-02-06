using System;
using System.Collections;
using UnityEngine;

namespace Messaging.Utilities
{
    public class CoroutineRunner: MonoBehaviour
    {
        public Func<IEnumerator> Coroutine;
        private void Start()
        {
            StartCoroutine(Coroutine());
        }
    }
}

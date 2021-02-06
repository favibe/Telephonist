using Messaging.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Messaging
{
    public class PauseMessageEvent : MessageEvent
    {
        public PauseMessageEvent(float time)
        {
            _time = time;
        }
        public override void Execute()
        {
            OnEventStarted();

            _runnerObj = new GameObject();
            var runner = _runnerObj.AddComponent<CoroutineRunner>();

            runner.Coroutine = Pause;
        }

        private IEnumerator Pause()
        {
            yield return new WaitForSeconds(_time);

            GameObject.Destroy(_runnerObj);

            OnEventEnded();

        }

        private GameObject _runnerObj;
        private float _time;
    }

}

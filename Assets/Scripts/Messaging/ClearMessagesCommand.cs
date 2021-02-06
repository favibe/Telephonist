using UnityEngine;

namespace Messaging
{
    public class ClearMessagesCommand : MessageEvent
    {
        public ClearMessagesCommand(Transform parent)
        {
            _parent = parent;
        }
        public override void Execute()
        {
            OnEventStarted();

            foreach (Transform child in _parent)
            {
                GameObject.Destroy(child.gameObject);
            }

            OnEventEnded();
        }

        private Transform _parent;
    }
}

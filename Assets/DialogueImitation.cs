using Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueImitation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        display.TypingMessage("Hello, how are you?", MessageType.Incoming);
        display.AddPause(1);
        display.TypingMessage("I'm little bit nervous about yesterday...", MessageType.Incoming);
        display.AddPause(3);
        display.TypingMessage("Call me, please!", MessageType.Incoming);
        display.AddPause(1);
        display.TypingMessage("You have to stop!", MessageType.Outgoing);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]
    MessageDisplay display;
}

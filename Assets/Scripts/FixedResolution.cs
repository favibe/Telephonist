using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _cam = GetComponent<Camera>();
        _cam.pixelRect = new Rect(0, 0, 84, 48);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Camera _cam;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedResolution : MonoBehaviour
{
    void Start()
    {
        _cam = GetComponent<Camera>();
        _cam.pixelRect = new Rect(0, 0, 84, 48);
    }

    Camera _cam;
}

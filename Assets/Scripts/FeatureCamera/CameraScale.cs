using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScale : MonoBehaviour
{
    void Update()
    {
        Camera.main.orthographicSize = Screen.height / 2;
    }
}

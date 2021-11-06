using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScale : MonoBehaviour
{
    void Update()
    {
        Camera.main.orthographicSize = Screen.height / 2;
        this.gameObject.transform.position = new Vector3(Screen.width, Screen.height, -930);
        
    }
}

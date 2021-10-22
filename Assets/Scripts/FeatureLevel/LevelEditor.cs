using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{ 
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localScale = new Vector2(Screen.width, Screen.height);
    }
}

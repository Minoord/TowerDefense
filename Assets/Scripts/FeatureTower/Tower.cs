using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int TowerHP;

    // Start is called before the first frame update
    void Start()
    {
        TowerHP = 3000;
    }

    // Update is called once per frame
    void Update()
    {
        if (TowerHP == 0)
        {
            Destroy(this.gameObject);
        }
    }
}

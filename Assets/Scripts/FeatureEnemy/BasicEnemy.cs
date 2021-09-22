using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public int enemyHealthPoints;
    public int BasicAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public int towerHealthPoints;
    public BasicEnemy EnemyAttack;

    // Update is called once per frame
    void Update()
    {
        if (towerHealthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print("HEY");
            towerHealthPoints -= EnemyAttack.BasicAttack; 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet1 : BulletTracking
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentEnemy.enemyBurning = true;
        }
    }
}

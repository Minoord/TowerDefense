using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public BasicEnemy enemyHP;
    public int basicAttack;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyHP.enemyHealthPoints -= basicAttack;
        }
    }
}

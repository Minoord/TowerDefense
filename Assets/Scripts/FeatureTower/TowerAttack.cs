using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public BasicEnemy enemyHP;
    public int basicAttack;
    public bool canAttack;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && canAttack == true)
        {
            enemyHP = collision.gameObject.GetComponent<BasicEnemy>();
            enemyHP.enemyHealthPoints -= basicAttack;
        }
    }
}

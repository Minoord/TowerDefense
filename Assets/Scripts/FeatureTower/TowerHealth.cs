using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public int towerHealthPoints;
    public BasicEnemy EnemyAttack;
    public bool canBeHit;

    private void Start()
    {
        canBeHit = false;
    }

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
        if (collision.gameObject.tag == "Enemy" && canBeHit == true)
        {
            EnemyAttack = collision.gameObject.GetComponent<BasicEnemy>();
            towerHealthPoints -= EnemyAttack.basicAttack; 
        }
    }
}

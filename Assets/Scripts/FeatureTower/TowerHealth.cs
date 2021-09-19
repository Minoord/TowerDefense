using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public int towerHealthPoints;
    //BaiscEnemyAttack EnemyAttack;

    // Start is called before the first frame update
    void Start()
    {
        towerHealthPoints = 3000;
    }

    // Update is called once per frame
    void Update()
    {
        if (towerHealthPoints == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //towerHealthPoints -= EnemyAttack.enemyDamage; 
        }
    }
}

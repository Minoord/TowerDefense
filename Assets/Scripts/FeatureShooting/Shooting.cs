using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    private BasicEnemy _enemy;
    public List<BasicEnemy> EnemyList = new List<BasicEnemy>();

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            _enemy = FindObjectOfType<BasicEnemy>();
            EnemyList.Add(_enemy);
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }
}

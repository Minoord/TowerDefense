using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    private BasicEnemy _enemy;
    [SerializeField] private float _timer;
    public List<BasicEnemy> EnemyList = new List<BasicEnemy>();


    private void Update()
    {

        _timer -= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            _enemy = FindObjectOfType<BasicEnemy>();
            EnemyList.Add(_enemy);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           
            if(_timer <= 0)
            {
                _timer = 800;
                Instantiate(Bullet, transform.position, Quaternion.identity);
            }
        }
    }
}

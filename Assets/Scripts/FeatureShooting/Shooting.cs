using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public bool canAttack;
    private GameObject _enemy;
    [SerializeField] private float _timer;
    public List<GameObject> EnemyList = new List<GameObject>();



    private void Update()
    {
        _timer -= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            _enemy = collision.gameObject;
            EnemyList.Add(_enemy);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && canAttack == true)
        {
            if(_timer <= 0)
            {
                _timer = 800;
                Instantiate(Bullet, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyList.Remove(collision.gameObject);
    }
}

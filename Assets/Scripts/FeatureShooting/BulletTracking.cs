using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTracking : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private BasicEnemy _currentEnemy;
    [SerializeField] private Shooting _whichEnemy;
    [SerializeField] private Vector2 _bulletsPosition;

    private void Start()
    {
        _speed = 0.001f;
        _whichEnemy = FindObjectOfType<Shooting>();
    }
    // Update is called once per frame
    void Update()
    {
        _bulletsPosition = this.transform.position;
        _currentEnemy = _whichEnemy.EnemyList[0];
        transform.position =  Vector2.MoveTowards(_bulletsPosition, _currentEnemy.GetPosition(), _speed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        print("hey");
        if (collision.gameObject.tag == "Enemy")
        {
            _currentEnemy.enemyHealthPoints -= 10;
            Destroy(this.gameObject);
        }
    }
}

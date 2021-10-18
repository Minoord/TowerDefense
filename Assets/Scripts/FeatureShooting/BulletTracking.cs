using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTracking : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Shooting _shooting;
    [SerializeField] private Vector2 _bulletsPosition;
    public BasicEnemy _currentEnemy;

    private void Start()
    {
        _speed = 0.004f;
    }
    // Update is called once per frame
    void Update()
    {
        if (_shooting.enemy)
        {
            _bulletsPosition = this.transform.position;
            _currentEnemy = _shooting.enemy;
            transform.position = Vector2.MoveTowards(_bulletsPosition, _currentEnemy.GetPosition(), _speed);

            if (_currentEnemy.enemyHealthPoints == 0 )
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _shooting = collision.gameObject.GetComponent<Shooting>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _currentEnemy.enemyHealthPoints -= 10;
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTracking : MonoBehaviour
{
    [SerializeField] private float _speed;
    public Shooting _shooting;
    [SerializeField] private Vector2 _bulletsPosition;
    private BasicEnemy _currentEnemy;

    private void Start()
    {
        _speed = 0.4f;
    }
    // Update is called once per frame
    void Update()
    {
        if (_shooting )
        {
            if (_shooting.enemy)
            {
                _bulletsPosition = this.transform.position;
                _currentEnemy = _shooting.enemy;
                transform.position = Vector2.MoveTowards(_bulletsPosition, _currentEnemy.GetPosition(), _speed);
            }
            else
            {
                Destroy(gameObject);
            }

            if (_currentEnemy.enemyHealthPoints == 0 || _currentEnemy == null)
            {
                Destroy(gameObject);
            }
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            _shooting = collision.gameObject.GetComponent<Shooting>();
        }
            
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

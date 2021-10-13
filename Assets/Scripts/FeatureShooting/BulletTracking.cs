using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTracking : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Shooting _whichEnemy;
    [SerializeField] private Vector2 _bulletsPosition;
    public BasicEnemy _currentEnemy;

    private void Start()
    {
        _speed = 0.004f;
    }
    // Update is called once per frame
    void Update()
    {
        if(_whichEnemy) {
            _bulletsPosition = this.transform.position;
            _currentEnemy = _whichEnemy.EnemyList[0].GetComponent<BasicEnemy>();
            transform.position =  Vector2.MoveTowards(_bulletsPosition, _currentEnemy.GetPosition(), _speed);

            if (_currentEnemy.enemyHealthPoints == 0 && _whichEnemy != null)
            {
                Destroy(gameObject);
                _whichEnemy.EnemyList.Remove(_currentEnemy.gameObject);
            }
        }

       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _whichEnemy = collision.gameObject.GetComponent<Shooting>();
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

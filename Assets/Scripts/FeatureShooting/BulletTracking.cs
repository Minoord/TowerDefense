using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTracking : MonoBehaviour
{
    [SerializeField] private float _speed;
    public Shooting _shooting;
    public int damage;
    [SerializeField] private Vector2 _bulletsPosition;
    public BasicEnemy currentEnemy;
    private Renderer rend;

    private void Start()
    {
        _speed = 0.4f;
        rend = this.gameObject.GetComponent<Renderer>();
        rend.enabled = false;
        Invoke("ScreachEnemy", 1);
    }
    // Update is called once per frame
    void Update()
    {
        if (currentEnemy)
        {
            _bulletsPosition = this.transform.position;
            transform.position = Vector2.MoveTowards(_bulletsPosition, currentEnemy.GetPosition(), _speed);

            if (currentEnemy.enemyHealthPoints == 0)
            {
                Destroy(gameObject);
            }
            if (currentEnemy == null)
            {
                Destroy(gameObject);
            }

        }




    }
    private void ScreachEnemy()
    {
        if (_shooting && _shooting.enemy)
        {
            rend.enabled = true;
            currentEnemy = _shooting.enemy;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            _shooting = collision.gameObject.GetComponent<Shooting>();
        }
            
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentEnemy.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}

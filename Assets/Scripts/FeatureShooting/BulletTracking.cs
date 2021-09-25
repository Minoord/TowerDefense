using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTracking : MonoBehaviour
{
    [SerializeField] private float _speed;
    private BasicEnemy _currentEnemy;
    private Shooting _whichEnemy;
    private Vector2 _bulletsPosition;

    private void Start()
    {
        _speed = 2;
        _whichEnemy = FindObjectOfType<Shooting>();
    }
    // Update is called once per frame
    void Update()
    {
        _bulletsPosition = this.transform.position;
        _currentEnemy = _whichEnemy.EnemyList[0];
        transform.LookAt(_currentEnemy.GetPosition());
        Vector2.MoveTowards(_bulletsPosition, _currentEnemy.transform.position, _speed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public BasicEnemy enemy;
    public bool canAttack;

    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _timer;
    [SerializeField] private int _attackDamage;

    private void Start()
    {
        _timer = 400;
    }

    private void Update()
    {
        enemy = GetFirstEnemyInRange();
        if (canAttack)
        {
            _timer -= Time.deltaTime;
        }

        if (enemy && _timer <= 0)
        {
            enemy.TakeDamage(_attackDamage);
            _timer = 10;
        }
    }

    public BasicEnemy GetFirstEnemyInRange()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, _radius, _layer);
        if (cols.Length <= 0)
        {
            //Debug.Log("Cols is empty");
            return null;
        }
        else
        {
            Debug.Log(cols.Length);
        }
        return cols[0].GetComponent<BasicEnemy>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}

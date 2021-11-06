using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public int enemyHealthPoints;
    public int basicAttack;
    public int enemyWorth;
    public bool enemyBurning;
    public WaveSpawnerScript WaveSpawnList;
    public Wallet wallet;

    private int _enemyBurningTimer;

    // Start is called before the first frame update
    void Start()
    {
        WaveSpawnList = FindObjectOfType<WaveSpawnerScript>();
        wallet = FindObjectOfType<Wallet>();
        WaveSpawnList.WaveEnemies.Add(this.gameObject);
        enemyBurning = false;
        _enemyBurningTimer = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealthPoints <= 0)
        {
            WaveSpawnList.WaveEnemies.Remove(this.gameObject);
            Destroy(this.gameObject);
            wallet.AddMoney(enemyWorth);
        }

        if (enemyBurning )
        {
            _enemyBurningTimer -= 1;
            if( _enemyBurningTimer <= 0)
            {
                TakeDamage(1);
                _enemyBurningTimer = 50;
            }
        }
    }


    public void TakeDamage(int damage)
    {
        enemyHealthPoints -= damage;
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public int enemyHealthPoints;
    public int basicAttack;
    public int enemyWorth;
    public WaveSpawnerScript WaveSpawnList;
    public Wallet wallet;

    // Start is called before the first frame update
    void Start()
    {
        WaveSpawnList = FindObjectOfType<WaveSpawnerScript>();
        wallet = FindObjectOfType<Wallet>();
        WaveSpawnList.WaveEnemies.Add(this.gameObject);
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
    }


    public Vector2 GetPosition()
    {
        return transform.position;
    }
}

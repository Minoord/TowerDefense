using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public int enemyHealthPoints;
    public int BasicAttack;
    public WaveSpawnerScript WaveSpawnList;

    // Start is called before the first frame update
    void Start()
    {
        WaveSpawnList = FindObjectOfType<WaveSpawnerScript>();
        WaveSpawnList.WaveEnemies.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealthPoints <= 0)
        {
            WaveSpawnList.WaveEnemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }


    public Vector2 GetPosition()
    {
        return transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerScript : MonoBehaviour
{
    //These list are for spawning enemies
    public List<GameObject> WaveEnemies = new List<GameObject>();

    //this list contains all the enemies 
    public List<GameObject> EnemiesThatSpawn = new List<GameObject>();

    [SerializeField] private int _whichWave;
    [SerializeField] private GameObject _whichEnemyToSpawn;
    [SerializeField] private int _howManyEnemies;
    [SerializeField] private int _timer;

    public int betweenTimeWaves;
    public bool WaveStart;
    public int minEnemies;
    public int maxEnemies;
    public int indexNumb;
    
    private void Start()
    {
        _whichWave = 1;
        _timer = 0;
        _howManyEnemies = RandomizeHowManyEnemies();
    }

    private void Update()
    {
        
        if (WaveStart)
        {
            _timer -= 1;
            betweenTimeWaves = 300;

            if (WaveEnemies.Count >= 0 && _timer <= 0)
            {
                AddEnemy();
                _timer = 200;
            }

            switch (_whichWave)
            {
                case 1:
                    minEnemies = 5;
                    maxEnemies = 10;
                    for (int i = 0; i < _howManyEnemies; i++)
                    {
                        indexNumb = Random.Range(1, 2);
                    }
                    break;
                case 2:
                    minEnemies = 10;
                    maxEnemies = 15;
                    for (int i = 0; i < _howManyEnemies; i++)
                    {
                        indexNumb = Random.Range(3, 5); ;
                    }
                    break;
                case 3:
                    minEnemies = 15;
                    maxEnemies = 20;
                    for (int i = 0; i < _howManyEnemies; i++)
                    {
                        indexNumb = Random.Range(6, 7);
                    }
                    break;
                case 4:
                    minEnemies = 20;
                    maxEnemies = 25;
                    for (int i = 0; i < _howManyEnemies; i++)
                    {
                        indexNumb = Random.Range(8, 13);
                    }
                    break;
            }
            if (WaveEnemies.Count == 0)
            {
                _whichWave += 1;
                WaveStart = false;
                _howManyEnemies = RandomizeHowManyEnemies();
            }
        }
        else
        {
            betweenTimeWaves -= 1;

            if(betweenTimeWaves <= 0)
            {
                WaveStart = true;
            }
        }
        
    }
    public int RandomizeHowManyEnemies()
    {
        int howManyEnemies = Random.Range(minEnemies,maxEnemies);
        return howManyEnemies;
    }

    public void AddEnemy()
    {
        _whichEnemyToSpawn = EnemiesThatSpawn[indexNumb];
        WaveEnemies.Add(_whichEnemyToSpawn);
        Instantiate(_whichEnemyToSpawn);
    }

}

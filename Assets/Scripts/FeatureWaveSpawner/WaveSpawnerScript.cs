using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawnerScript : MonoBehaviour
{
    //These list are for spawning enemies
    public List<GameObject> WaveEnemies = new List<GameObject>();

    //this list contains all the enemies 
    public List<GameObject> EnemiesThatSpawn = new List<GameObject>();

    [SerializeField] private int _whichWave; //holds the current wave
    [SerializeField] private GameObject _whichEnemyToSpawn; //Knows which enemy to spawn
    [SerializeField] private GameObject _spawnPoint; // where the enemy needs to spawn
    [SerializeField] private int _howManyEnemies; //Knows how many enemy it can spawn
    [SerializeField] private int _timer; // Timer to keep enemies from spawning

    public int minEnemies; //minium enemies it can spawn
    public int maxEnemies; // maxium enemies it can spawn
    public int indexNumb; // knows the index number of _whichEnemyToSpawn
    int i;
    
    private void Start()
    {
        _whichWave = 1;
        _timer = 0;
        minEnemies = 5;
        maxEnemies = 10;
        _howManyEnemies = RandomizeHowManyEnemies();
    }

    private void Update()
    {
            switch (_whichWave)
            {
                case 0:
                    Debug.Log("Case 0");;
                break;
                case 1:
                    RandomizeWhichEnemies(0, 2);
                    break;
                case 2:
                    minEnemies = 10;
                    maxEnemies = 15;
                    RandomizeWhichEnemies(2,5);
                    break;
                case 3:
                    minEnemies = 15;
                    maxEnemies = 20;
                    RandomizeWhichEnemies(5, 7);
                    break;
                case 4:
                    minEnemies = 20;
                    maxEnemies = 25;
                    RandomizeWhichEnemies(7, 13);
                    break;
                case 5:
                    SceneManager.LoadScene("WinGame");
                    break;
            }
        
    }

    public int RandomizeHowManyEnemies()
    {
        _howManyEnemies = Random.Range(minEnemies,maxEnemies);
        return _howManyEnemies;
    }
    public int RandomizeWhichEnemies(int min, int max)
    {
        if(i == _howManyEnemies)
        {
            Debug.Log("_howManyEnemies is even groot als i");
            if (WaveEnemies.Count == 0)
            {
                Debug.Log("New Wave");
                _whichWave += 1;
                _timer = 3000;
                RandomizeHowManyEnemies();
                i = 0;
            }
        }
        else
        {
            _timer -= 1;
            indexNumb = Random.Range(min, max);
            ActivateAddEnemy();
        }
        return indexNumb;
    }
    public void ActivateAddEnemy()
    {
        if (_timer <= 0)
        {
            AddEnemy();
            i += 1;
            _timer = 2500;
        }
    } 
    public void AddEnemy()
    {
        _whichEnemyToSpawn = EnemiesThatSpawn[indexNumb];
        Instantiate(_whichEnemyToSpawn, _spawnPoint.transform.position, Quaternion.identity);
    }

}

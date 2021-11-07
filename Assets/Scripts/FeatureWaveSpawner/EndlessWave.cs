using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessWave : MonoBehaviour
{
    //These list are for spawning enemies
    public List<GameObject> WaveEnemies = new List<GameObject>();

    //this list contains all the enemies 
    public List<GameObject> EnemiesThatSpawn = new List<GameObject>();

    [SerializeField] private int _whichWave; //holds the current wave
    [SerializeField] private GameObject _whichEnemyToSpawn; //Knows which enemy to spawn
    [SerializeField] private GameObject _spawnPoint; // where the enemy needs to spawn
    [SerializeField] private int _howManyEnemies; //Knows how many enemy it can spawn
    [SerializeField] private float _timer; // Timer to keep enemies from spawning

    public int minEnemies; //minium enemies it can spawn
    public int maxEnemies; // maxium enemies it can spawn
    public int indexNumb; // knows the index number of _whichEnemyToSpawn
    public Text printWave;
    int i;

    private void Start()
    {
        minEnemies = 5;
        maxEnemies = 10;
        RandomizeHowManyEnemies();
        printWave = GameObject.Find("WaveCount").GetComponent<Text>();
    }
    private void Update()
    {
        RandomizeWhichEnemies(0, EnemiesThatSpawn.Count);
        printWave.text = "Wave :" + _whichWave;
    }

    public int RandomizeHowManyEnemies()
    {
        _howManyEnemies = Random.Range(minEnemies, maxEnemies);
        minEnemies += 10;
        maxEnemies += 10;
        return _howManyEnemies;
    }

    public int RandomizeWhichEnemies(int min, int max)
    {
        if (i == _howManyEnemies)
        {
            //Debug.Log("_howManyEnemies is even groot als i");
            if (WaveEnemies.Count == 0)
            {
                //Debug.Log("New Wave");
                _whichWave += 1;
                _timer = 20;
                RandomizeHowManyEnemies();
                i = 0;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
            indexNumb = Random.Range(min, max);
            ActivateAddEnemy();
        }
        return indexNumb;
    }

    public void ActivateAddEnemy()
    {
        if (_timer <= 0)
        {
            Invoke("AddEnemy", 1);
            i += 1;
            _timer = 15;
        }
    }
    public void AddEnemy()
    {
        _whichEnemyToSpawn = EnemiesThatSpawn[indexNumb];
        Instantiate(_whichEnemyToSpawn, _spawnPoint.transform.position, Quaternion.identity);
    }


}

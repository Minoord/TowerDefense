using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerScript : MonoBehaviour
{
    public List<GameObject> Wave1Enemies = new List<GameObject>(); // Asmodeus en Clara
    public List<GameObject> Wave2Enemies = new List<GameObject>(); // Familliar
    public List<GameObject> Wave3Enemies = new List<GameObject>(); // Beast of the Valley
    public List<GameObject> Wave4Enemies = new List<GameObject>(); // Dodge ball

    [SerializeField] private int _whichWave;
    [SerializeField] private int _whichEnemyToSpawn;
    [SerializeField] private int _numberOfEnemies;

    private void Start()
    {
        _whichWave = 1;
    }

    private void Update()
    {
        switch(_whichWave)
        {
            case 1:
                _whichEnemyToSpawn = Random.Range(1, Wave1Enemies.Count);
                Instantiate(Wave1Enemies[_whichEnemyToSpawn]);
                break;
            case 2:
                _whichEnemyToSpawn = Random.Range(1, Wave2Enemies.Count);
                Instantiate(Wave2Enemies[_whichEnemyToSpawn]);
                break;
            case 3:
                _whichEnemyToSpawn = Random.Range(1, Wave3Enemies.Count);
                Instantiate(Wave3Enemies[_whichEnemyToSpawn]);
                break;
            case 4:
                _whichEnemyToSpawn = Random.Range(1, Wave4Enemies.Count);
                Instantiate(Wave4Enemies[_whichEnemyToSpawn]);
                break;
        }
    }
}

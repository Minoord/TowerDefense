using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public GameObject _spawnPlaceTower;

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}

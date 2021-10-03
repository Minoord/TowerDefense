using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    [SerializeField] private Waypoints[] _waypoints;

    public Waypoints GetPathStart()
    {
        return _waypoints[0];
    }

    public Waypoints GetPathEnd()
    {
        return _waypoints[_waypoints.Length - 1];
    }

    public Waypoints GetNextWaypoint(Waypoints currentWaypoint)
    {
        for (int i = 0; i < _waypoints.Length; i++)
        {
            if (_waypoints[i] == currentWaypoint)
            {
                return _waypoints[i + 1];
            }
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _arrivalTreshold;

    private PathScript _path;
    private Waypoints _currentWaypoint;

    private void Start()
    {
        _path = FindObjectOfType<PathScript>();
        _currentWaypoint = _path.GetPathStart();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, _currentWaypoint.GetPosition(), _speed);
        float distanceToWaypoint = Vector3.Distance(transform.position, _currentWaypoint.GetPosition());
        if (distanceToWaypoint <= _arrivalTreshold)
        {
            if (_currentWaypoint == _path.GetPathEnd())
            {
                PathComplete();
            }
            else
            {
                _currentWaypoint = _path.GetNextWaypoint(_currentWaypoint);
            }
        }

    }
    private void PathComplete()
    {
        _speed = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private WayPoints[] _waypoints;

    public WayPoints GetPathStart()
    {
        return _waypoints[0];
    }

    public WayPoints GetPathEnd()
    {
        return _waypoints[_waypoints.Length - 1];
    }
    public WayPoints GetNextWaypoint(WayPoints currentWaypoint)
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

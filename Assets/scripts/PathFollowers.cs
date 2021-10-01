using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowers : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _ArrivalThreshHold;

    private Path _path;
    private WayPoints _currentWaypoint;

    private void Start()
    {
        SetupPath();
    }

    // Update is called once per frame
    private void Update()
    {

        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        float distanceToWaypoint = Vector3.Distance(transform.position, _currentWaypoint.Getposition());
        if (distanceToWaypoint <= _ArrivalThreshHold)
        {
            if (_currentWaypoint == _path.GetPathEnd())
            {
                PathComplete();
            }
            else
            {
                _currentWaypoint = _path.GetNextWaypoint(_currentWaypoint);
                transform.LookAt(_currentWaypoint.Getposition() + new Vector3(0, transform.position.y, 0));
            }
        }

    }
    private void SetupPath()
    {
        _path = FindObjectOfType<Path>();
        _currentWaypoint = _path.GetPathStart();
        transform.LookAt(_currentWaypoint.Getposition());
    }


    private void PathComplete()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : Enemy
{
    [SerializeField] Transform[] _waypoints;

    int _actualWaypoint;
    protected override void Update()
    {
        AddForce(Seek(_waypoints[_actualWaypoint].position));

        if (Vector3.Distance(_waypoints[_actualWaypoint].position,
            transform.position) < 0.5f)
        {
            _actualWaypoint++;

            if (_actualWaypoint >= _waypoints.Length)
                _actualWaypoint = 0;
        }

        base.Update();
    }

    public Vector3 Seek(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= _maxVelocity;

        Vector3 steering = desired - _velocity;
        steering = Vector3.ClampMagnitude(steering, _maxForce);

        return steering;
    }
}
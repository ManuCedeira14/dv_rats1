using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float _maxVelocity;
    [Range(0f, 1f)]
    [SerializeField] protected float _maxForce;
    protected Vector3 _velocity;
    public Vector3 Velocity { get { return _velocity; } }

    protected virtual void Update()
    {
        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
    }
    public void AddForce(Vector3 dir)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + dir, _maxVelocity);
    }
}

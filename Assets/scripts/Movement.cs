using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement
{
    float _speed;
    float _jumpSpeed;

    public LayerMask _whatIsGround;
    public Transform target;
    public Transform targetOrientation;

    Rigidbody _targetRigidbody;

    Vector3 moveDirection;


    public Movement(Transform transform, Transform orientation, float speed, Rigidbody rb, float jumpSpeed, LayerMask whatIsGround) //datos que le paso a player
    {
        _whatIsGround = whatIsGround;
        targetOrientation = orientation;
        target = transform;
        _speed = speed;
        _targetRigidbody = rb;
        _jumpSpeed = jumpSpeed;
    }

    public float Speed //para acceder y modificar speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public void Move(float horizontal, float vertical) //funcion para mover
    {
        moveDirection = targetOrientation.forward * vertical + targetOrientation.right * horizontal;
        _targetRigidbody.AddForce(moveDirection.normalized * _speed * 10f, ForceMode.Force);
    }

    public void Jump() //funcion para saltar
    {

        Vector3 floor = target.TransformDirection(Vector3.down);

        if (Physics.Raycast(target.position, floor, 8f, _whatIsGround))
        {
            _targetRigidbody.velocity = Vector3.up * _jumpSpeed;
            Debug.Log("Salte");
        }
        else
        {
            Debug.Log("NO salte");
        }

    }
    public void SpeedControl() //funcion para controlar la velocidad
    {
        Vector3 flatVel = new Vector3(_targetRigidbody.velocity.x, 0f, _targetRigidbody.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > _speed)
        {
            Vector3 limitedVel = flatVel.normalized * _speed;
            _targetRigidbody.velocity = new Vector3(limitedVel.x, _targetRigidbody.velocity.y, limitedVel.z);
        }
    }
}

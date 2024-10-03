using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerModel))]
public class PlayerController : IController
{
    Vector3 _direction;
    PlayerModel _m;
    Transform _cameraTransform;

    public PlayerController(PlayerModel m)
    {
        _direction = Vector3.zero;
        _m = m;
        _cameraTransform = Camera.main.transform; 
    }

    public void ControllerUpdate()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        
        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        forward.y = 0f;  
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        _direction = forward * vertical + right * horizontal;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _m.Jump();
        }
    }

    public void ControllerFixedUpdate()
    {
        _m.Move(_direction);
    }
}

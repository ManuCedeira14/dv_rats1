using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerModel))]

public class PlayerController :IController
{
    Vector3 _direction;

    PlayerModel _m;

    public PlayerController(PlayerModel m)
    {
        _direction = Vector3.zero;

        _m = m;
    }


    public void ControllerUpdate()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.z = Input.GetAxisRaw("Vertical");

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


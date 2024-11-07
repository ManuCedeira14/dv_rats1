using UnityEngine;


public class PlayerController : IController
{
    Vector3 _direction;
    PlayerModel _m;
    Transform _cameraTransform;
    LifeHandler _lifeHandler;
    private bool _controlsEnabled = true;
    public PlayerController(PlayerModel m, LifeHandler lifeHandler)
    {
        _direction = Vector3.zero;
        _m = m;
        _cameraTransform = Camera.main.transform; 
        _lifeHandler = lifeHandler;  
        _lifeHandler.OnDead += TurnOffControls;
    }


    public void ControllerUpdate()
    {
        if (!_controlsEnabled) return;

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
    void TurnOffControls()
    {
        _controlsEnabled = false;

    }
}

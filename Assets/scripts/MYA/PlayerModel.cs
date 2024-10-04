using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerModel : MonoBehaviour
{
    Rigidbody _rb;

    [SerializeField] public float speed;
    [SerializeField] public float forceJump;
    [SerializeField] public bool canJump;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDistance = 1f;
    LifeHandler _lifeHandler;
    HealthBar _healthBar;

    IController _controller;
    PlayerView _PV;

    public event Action<float, float> OnMovement = delegate { };
    public event Action<float> OnLifeUpdate = delegate { };
    public event Action OnJump = delegate { };
    public event Action OnTakeDamage = delegate { };
    public event Action OnDeath = delegate { };

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _lifeHandler = GetComponent<LifeHandler>(); 
        _controller = new PlayerController(this, _lifeHandler);
        _healthBar = FindObjectOfType<HealthBar>();
        if (_healthBar != null)
        {
            _healthBar.Initialize(_lifeHandler);  
        }
    }

    private void Update()
    {
        _controller.ControllerUpdate();
        CheckGround(); 
    }

    private void FixedUpdate()
    {
        _controller.ControllerFixedUpdate();
    }

    public void Move(Vector3 dir)
    {
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        _rb.MovePosition(_rb.position + dir * (speed * Time.fixedDeltaTime));

        OnMovement(dir.x, dir.y);
    }

    public void Jump()
    {
        if (canJump)
        {
            _rb.AddForce(Vector3.up * forceJump, ForceMode.VelocityChange);
            canJump = false; 
            OnJump();
        }
    }
    public void TakeDamage(float amount)
    {
        _lifeHandler.TakeDamage(amount);  
    }

    public void Heal(float amount)
    {
        _lifeHandler.Heal(amount); 
    }
    public float CurrentLife => _lifeHandler.CurrentLife;
    public float MaxLife => _lifeHandler.MaxLife;
    private void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, checkDistance, groundLayer))
        {
            canJump = true; 
        }
        else
        {
            canJump = false; 
        }
    }
}

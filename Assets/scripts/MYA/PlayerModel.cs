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

        _lifeHandler = GetComponent<LifeHandler>(); // Obtener LifeHandler antes de crear el controlador
        _controller = new PlayerController(this, _lifeHandler); // Pasar LifeHandler al controlador
    }

    private void Update()
    {
        _controller.ControllerUpdate();
        CheckGround(); // Verificar si el jugador está en el suelo
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
            canJump = false; // Evitar saltos consecutivos sin tocar el suelo
            OnJump();
        }
    }
    public void TakeDamage(float amount)
    {
        _lifeHandler.TakeDamage(amount);  // Delegar el daño al LifeHandler
    }

    public void Heal(float amount)
    {
        _lifeHandler.Heal(amount);  // Delegar la curación al LifeHandler
    }
    public float CurrentLife => _lifeHandler.CurrentLife;
    public float MaxLife => _lifeHandler.MaxLife;
    private void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, checkDistance, groundLayer))
        {
            canJump = true; // Si está en el suelo, puede saltar
        }
        else
        {
            canJump = false; // Si no está en el suelo, no puede saltar
        }
    }
}

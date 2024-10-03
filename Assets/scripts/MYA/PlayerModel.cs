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
    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] public bool canJump;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDistance = 1f;
    [SerializeField] private Slider _healthBar;

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

        _controller = new PlayerController(this);

        currentHealth = maxHealth;
    }

    private void Update()
    {
        _controller.ControllerUpdate();
        UpdateHealthBar(currentHealth);
        CheckGround(); // Verificar si el jugador está en el suelo
        Death();
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

    public void UpdateHealthBar(int _currentHealth)
    {
        _healthBar.value = _currentHealth;
        Debug.Log("vida actual" + _currentHealth);
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthBar(currentHealth);
    }

    void Death()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("RIP");
            enabled = false;
            SceneManager.LoadScene(2);
        }

        OnDeath();
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerModel : MementoEntity
{
    Rigidbody _rb;

    [SerializeField] public float speed;
    [SerializeField] public float forceJump;
    [SerializeField] public bool canJump;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDistance = 1f;
    [SerializeField] private Material damageMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Slider healthBar;

    private IPlayerDecorator _decoratedPlayer;
    LifeHandler _lifeHandler;
    HealthBar _healthBar;
    Renderer _renderer;

    IController _controller;

    public event Action<float, float> OnMovement = delegate { };
    public event Action<float> OnLifeUpdate = delegate { };
    public event Action OnJump = delegate { };
    public event Action OnTakeDamage = delegate { };
    public event Action OnDeath = delegate { };

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        
        _renderer = GetComponent<Renderer>();
        if (_renderer == null)
        {
            Debug.LogError("No se encontr� el componente Renderer en el Player. Aseg�rate de que tenga un MeshRenderer o SkinnedMeshRenderer.");
            return;
        }

        
        if (damageMaterial == null || defaultMaterial == null)
        {
            Debug.LogError("Los materiales damageMaterial y defaultMaterial no est�n asignados en el inspector.");
            return;
        }

       
        _lifeHandler = GetComponent<LifeHandler>();
        _controller = new PlayerController(this, _lifeHandler);

        
        _decoratedPlayer = new MaterialChangeDecorator(this, _renderer, damageMaterial, defaultMaterial);
    }

    protected override void Update()
    {
        if (Debugger.ItsRewindTime)
        {
            Debug.Log("Rebobinando, deteniendo controlador...");
            return;
        }
        _controller.ControllerUpdate();
        CheckGround();
        UpdateHealthBar();
        base.Update();
    }

    private void FixedUpdate()
    {
        if (!Debugger.ItsRewindTime)
        {
            _controller.ControllerFixedUpdate();
        }
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
        _decoratedPlayer.TakeDamage(amount);
        OnTakeDamage();
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
    public void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            
            healthBar.value = _lifeHandler._currentLife;
        }
    }

    protected override void SaveStates()
    {
        _memento.SaveMemory(_rb.position, _rb.rotation, _lifeHandler.CurrentLife);
        Debug.Log($"Estado guardado: Posici�n = {_rb.position}, Rotaci�n = {_rb.rotation.eulerAngles}, Vida = {_lifeHandler.CurrentLife}");
    }

    protected override void LoadStates(object[] state)
    {
        if (state == null || state.Length != 3)
        {
            Debug.LogError($"Estado inv�lido cargado: {state?.Length ?? 0} elementos.");
            return;
        }

        _rb.position = (Vector3)state[0];
        _rb.rotation = (Quaternion)state[1];
        _lifeHandler.Heal((float)state[2] - _lifeHandler.CurrentLife);

        Debug.Log($"Estado restaurado: Posici�n = {_rb.position}, Rotaci�n = {_rb.rotation.eulerAngles}, Vida = {_lifeHandler.CurrentLife}");
    }
}
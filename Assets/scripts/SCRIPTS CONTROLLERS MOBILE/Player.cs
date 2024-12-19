using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private Controller controller;
    [SerializeField] public float speed;
    [SerializeField] public int Actuallife;
    [SerializeField] public int _maxLife = 5;
    [SerializeField] public int bullets = 20;
    [SerializeField] public int totalBullets = 150;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] public int coins;
    //[SerializeField] private int maxCoins = 20;
    [SerializeField] private TextMeshProUGUI coinsText;
    playerprefs _playerprefs;
    public bool _isMoving = false;
    private bool isInitialized = false;
    [SerializeField] private audiomanager soundManager;

    public Material dmgShader;
    private const string BoolParameterName = "_on_off";
    private const string FloatParameterName = "_Edge1";

    public void Awake()
    {

        dmgShader.SetFloat(BoolParameterName, 0.0f);
    }
    private void Start()
    {
        _playerprefs = FindObjectOfType<playerprefs>();
        StartCoroutine(InitializePlayer());
        UpdateCoinsUI();
    }

    IEnumerator InitializePlayer()
    {
        while (RemoteConfigExample.Instance == null || RemoteConfigExample.Instance.actualLife == 0)
        {
            yield return null;
        }

        Actuallife = RemoteConfigExample.Instance.actualLife;
        speed = RemoteConfigExample.Instance.playerSpeed;

        if (healthBar != null)
        {
            healthBar.maxValue = _maxLife;
            UpdateHealthBar();
        }

        isInitialized = true;
    }

    void Update()
    {
        if (!isInitialized) return;
        
        MovePlayer();
        CheckStamina();
        UpdateEdgeValues(); 

        if (Actuallife <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }


    void MovePlayer()
    {
        Vector3 inputMovement = controller.GetMovement();

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 desiredMovement = (cameraForward * inputMovement.z + cameraRight * inputMovement.x) * speed;

        rb.velocity = new Vector3(desiredMovement.x, rb.velocity.y, desiredMovement.z);
        if (inputMovement.magnitude > 0)
        {
            if (!_isMoving)
            {
                _isMoving = true;
                soundManager.PlaySound(2);
                Debug.Log("El jugador comenzó a moverse");
            }
        }
        else
        {
            if (_isMoving)
            {
                _isMoving = false;
                Debug.Log("El jugador dejó de moverse");
            }
        }
    }

    public void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = Actuallife;
        }
    }

    public void Heal(int healAmount)
    {
        Actuallife += healAmount;
        Actuallife = Mathf.Clamp(Actuallife, 0, _maxLife);

        UpdateHealthBar();
        if (Actuallife == _maxLife)
        {
            dmgShader.SetFloat(BoolParameterName, 0.0f);
        }
    }

    
    private void UpdateEdgeValues()
    {
        if (Actuallife == 4)
        {
            dmgShader.SetFloat(BoolParameterName, 1.0f);
            dmgShader.SetFloat(FloatParameterName, 0.3f);
        }
        else if (Actuallife < 4 && Actuallife > 1)
        {

            dmgShader.SetFloat(FloatParameterName, 0.15f);
        }
        else if (Actuallife == 1)
        {

            dmgShader.SetFloat(FloatParameterName, -0.1f);
        }
    }
    public void AddLife(int amount)
    {
        Actuallife += amount;
        Actuallife = Mathf.Clamp(Actuallife, 0, _maxLife); 
        UpdateHealthBar(); 
        Debug.Log($"Vida actualizada: {Actuallife}/{_maxLife}");
    }

    //public void AddCoins(int amount)
    //{
    //    coins += amount;
    //    coins = Mathf.Clamp(coins, 0, maxCoins);
    //    UpdateCoinsUI();
    //    Debug.Log($"Monedas actuales: {coins}");
    //}

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateCoinsUI();
            Debug.Log($"Monedas restantes: {coins}");
            return true; 
        }
        else
        {
            Debug.Log("No hay suficientes monedas");
            return false;
        }
    }
    private void UpdateCoinsUI()
    {
        if (coinsText != null)
        {
            coinsText.text = coins.ToString(); 
    }
        
}
    void CheckStamina()
    {
        if (_playerprefs.staminaValue <= 0)
        {
            speed = 12.5f;
        }
        else if (_playerprefs.staminaValue > 1)
        {
            speed = 25f;
        }
    }
}


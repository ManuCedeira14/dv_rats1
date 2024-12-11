using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform bulletSpawnPoint; 
    [SerializeField] private float bulletSpeed = 20f; 
    [SerializeField] private List<ParticleSystem> _shootParticle; 
    

    private bool isInitialized = false;

    public Material dmgShader;
    private const string BoolParameterName = "_on_off";
    private const string FloatParameterName = "_Edge1";

    private void Start()
    {
        StartCoroutine(InitializePlayer());
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
        UpdateEdgeValues(); // Actualizar el valor de Edge1 según la vida del jugador

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
    }
    public void ShootButton()
    {
        Shoot();
        TriggerParticles();
    }
    private void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed;
            Destroy(bullet, 2f);
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
    public void TriggerParticles()
    {
        foreach (ParticleSystem particleEffect in _shootParticle)
        {
            if (particleEffect != null)
            {
                particleEffect.Play();
            }
        }
    }
}

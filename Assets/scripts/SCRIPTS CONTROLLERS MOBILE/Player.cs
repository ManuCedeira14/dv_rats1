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

    private void Start()
    {
        Actuallife = 2;
        if (healthBar != null)
        {
            healthBar.maxValue = _maxLife;
            healthBar.value = Actuallife;
        }
    }

    void Update()
    {
        MovePlayer();
        if (Actuallife == 0)
            SceneManager.LoadScene(3);
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

    public void UpdateHealthBar()
    {
        healthBar.value = Actuallife;
    }

    public void Heal(int healAmount)
    {
        Actuallife += healAmount;
        Actuallife = Mathf.Clamp(Actuallife, 0, _maxLife);

        if (healthBar != null)
        {
            UpdateHealthBar();
        }
    }
}
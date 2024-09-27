using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    
    

    private void Start()
    {
        Actuallife = 2;
        if (healthBar != null)
        {
            healthBar.maxValue = _maxLife;
            healthBar.value = Actuallife;
        }
      
    }
    void FixedUpdate()
    {
        MovePlayer();
        
    }

    void MovePlayer()
    {
        Vector3 finalVel = new Vector3(controller.GetMovement().x, 0, controller.GetMovement().z) ; 
        rb.velocity += finalVel * speed *Time.deltaTime;
    }
    void UpdateHealthBar()
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
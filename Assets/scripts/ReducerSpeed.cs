using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReducerSpeed : MonoBehaviour
{
    public float reducedSpeed = 5f;
    private float originalSpeed;
    private Player player;

    
    public Material movimiento;  
    private const string BoolParameterName = "_on_off"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();

            if (player != null)
            {
                
                originalSpeed = player.speed;
                player.Actuallife--;
                player.UpdateHealthBar();
                player.speed = reducedSpeed;
                movimiento.SetFloat(BoolParameterName, 1.0f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && player != null)
        {
            
            player.speed = originalSpeed;
            movimiento.SetFloat(BoolParameterName, 0.0f);
            player = null;
        }
    }
}

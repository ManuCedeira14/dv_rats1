using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUps : lifePowerUp
{
    private LifeHandler _lifeHandler; 


    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            DestroyPowerUp();
            Debug.Log("base Power-up pickeado");
        }
    }
}

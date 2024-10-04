using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUps : lifePowerUp
{
<<<<<<< HEAD
    private LifeHandler _lifeHandler; 
=======
    private PlayerModel playerModel;
>>>>>>> a6b0a709c4537d7c6f44533c76a7c91db8e7f847


    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            DestroyPowerUp();
            Debug.Log("base Power-up pickeado");
        }
    }
}

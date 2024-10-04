using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUps : lifePowerUp
{
    private PlayerModel playerModel;
     


    public DestroyPowerUps()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_pickedUp)
        {
            
            DestroyPowerUp();
            Debug.Log("base Power-up pickeado");
        }
    }
}

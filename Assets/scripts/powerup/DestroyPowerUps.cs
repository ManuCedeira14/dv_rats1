using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUps : lifePowerUp
{
    public DestroyPowerUps()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.Actuallife < player._maxLife && other.CompareTag("Player") && !_pickedUp)
        {
            _pickedUp = true;
            DestroyPowerUp();
            Debug.Log("base Power-up pickeado");
        }
    }
}

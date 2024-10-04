using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUps : lifePowerUp
{
    private PlayerModel playerModel; // Referencia al jugador


    public DestroyPowerUps()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerModel.CurrentLife < playerModel.MaxLife && other.CompareTag("Player") && !_pickedUp)
        {
            _pickedUp = true;
            DestroyPowerUp();
            Debug.Log("base Power-up pickeado");
        }
    }
}

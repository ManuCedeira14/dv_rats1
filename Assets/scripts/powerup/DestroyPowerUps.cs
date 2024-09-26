using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUps : lifePowerUp
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_pickedUp)
        {
            _pickedUp = true;
            DestroyPowerUp();
            Debug.Log("Power-up pickeado");
        }
    }
}

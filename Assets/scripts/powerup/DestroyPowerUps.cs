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
        if (RemoteConfigExample.Instance.actualLife < player._maxLife && other.CompareTag("Player") && !_pickedUp)
        {
            _pickedUp = true;
            DestroyPowerUp();
            Debug.Log("base Power-up pickeado");
        }
    }
}

//TP2 Manuel Cedeira

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletsPowerUp : PowerUp
{
    Player _player;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    protected void addBullets()
    {
        if (_player != null)
        {
            _player.totalBullets += 50;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _pickedUp = true;
            addBullets();
            DestroyPowerUp();
            Debug.Log("Power-up pickeado");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _pickedUp = false;
        }
    }
    
}

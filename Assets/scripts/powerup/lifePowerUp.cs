using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifePowerUp : PowerUp
{
    protected Player player;
    private int lifeToAdd = 1;  

    private void Start()
    {
       
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (player == null)
        {
            Debug.Log("no hay tag player");
        }
    }

    private void addLife()
    {
        if (player != null)
        {
           
            if (player.Actuallife < player._maxLife)
            {
                player.Heal(lifeToAdd);  
                Debug.Log("Actual life: " + player.Actuallife);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (player.Actuallife < player._maxLife && other.CompareTag("Player") && !_pickedUp)
        {
            _pickedUp = true;
            addLife();
            DestroyPowerUp();
            Debug.Log("Power-up pickeado");
        }
    }
}

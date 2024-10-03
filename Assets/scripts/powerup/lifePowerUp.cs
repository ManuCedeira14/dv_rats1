using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifePowerUp : PowerUp
{
    //protected Player player;
    protected PlayerModel player;
    private int lifeToAdd = 1;  

    private void Start()
    {
        
        //player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerModel>();
        if (player == null)
        {
            Debug.Log("no hay tag player");
        }
    }

    private void addLife()
    {
        if (player != null)
        {
           
            if (player.currentHealth < player.maxHealth)
            {
                player.Heal(lifeToAdd);  
                Debug.Log("Actual life: " + player.currentHealth);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (player.currentHealth < player.maxHealth && other.CompareTag("Player") && !_pickedUp)
        {
            _pickedUp = true;
            addLife();
            DestroyPowerUp();
            Debug.Log("Power-up pickeado");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReducerSpeed : MonoBehaviour
{
    public float reducedSpeed = 5f;

    private float originalSpeed;

   
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            Player playerMovement = other.GetComponent<Player>();

           
            if (playerMovement != null)
            {
                
                originalSpeed = playerMovement.speed;

                
                playerMovement.speed = reducedSpeed;
            }
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            Player playerMovement = other.GetComponent<Player>();

            
            if (playerMovement != null)
            {
                
                playerMovement.speed = originalSpeed;
            }
        }
    }
}

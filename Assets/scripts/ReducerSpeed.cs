using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReducerSpeed : MonoBehaviour
{
    public float reducedSpeed = 5f;
    private float originalSpeed;
    private Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();

            if (player != null)
            {
                originalSpeed = player.speed;
                player.Actuallife--;
                player.UpdateHealthBar();
                player.speed = reducedSpeed;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && player != null)
        {
            player.speed = originalSpeed;
            player = null;
        }
    }
}

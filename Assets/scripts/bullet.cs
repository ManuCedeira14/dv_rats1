using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy")) // Asegúrate de que el enemigo tiene el tag "Enemy"
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(1); 
            }
            Destroy(gameObject);
            Debug.Log("bala destruida");
        }
    }
}
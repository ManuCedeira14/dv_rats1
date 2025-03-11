using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    
    public int bulletHits = 0; // Contador de impactos
    public Material material; // Referencia al material del shader

    void Start()
    {
        // Obtener el material del objeto al inicio
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con una bala
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("entro la bala ");
            bulletHits++; // Aumentar el contador

            if (bulletHits >= 1) // Si recibe 3 impactos, desactiva el shader
            {
                Destroy(gameObject);
            }
        }
    }
}

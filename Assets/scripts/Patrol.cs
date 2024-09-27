using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroll : Enemy
{
    [SerializeField] Transform[] waypoints;  // Puntos de patrullaje
    [SerializeField] float patrolSpeed = 2f; // Velocidad de patrullaje
    [SerializeField] Transform player;       // Referencia al jugador

    private int currentWaypointIndex = 0;

    protected override void Update()
    {
        base.Update();

        // Continuar patrullando
        Patrol();
    }

    private void Patrol()
    {
        Vector3 targetWaypoint = waypoints[currentWaypointIndex].position;
        Vector3 direction = (targetWaypoint - transform.position).normalized;

        // Mueve al enemigo hacia el waypoint
        AddForce(direction * patrolSpeed);

        // Verifica si ha llegado al waypoint
        if (Vector3.Distance(transform.position, targetWaypoint) < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Cambia al siguiente waypoint
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Aquí manejamos la colisión con el jugador
        if (other.CompareTag("Player"))
        {
            Player playerScript = other.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.Actuallife -= 1; // Resta 1 de vida al jugador
                playerScript.UpdateHealthBar(); // Actualiza la barra de salud
                Debug.Log("Enemigo tocó al jugador. Vida restante: " + playerScript.Actuallife);
            }
        }
    }
}
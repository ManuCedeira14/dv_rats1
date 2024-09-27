using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroll : Enemy
{
    [SerializeField] Transform[] waypoints;  
    [SerializeField] float patrolSpeed = 2f; 
    [SerializeField] Transform player;      

    private int currentWaypointIndex = 0;

    protected override void Update()
    {
        base.Update();

       
        Patrol();
    }

    private void Patrol()
    {
        Vector3 targetWaypoint = waypoints[currentWaypointIndex].position;
        Vector3 direction = (targetWaypoint - transform.position).normalized;

        
        AddForce(direction * patrolSpeed);

        
        if (Vector3.Distance(transform.position, targetWaypoint) < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; 
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Player"))
        {
            Player playerScript = GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.Actuallife -= 1; 
                playerScript.UpdateHealthBar(); 
                Debug.Log("Enemigo tocó al jugador. Vida restante: " + playerScript.Actuallife);
            }
        }
    }
}
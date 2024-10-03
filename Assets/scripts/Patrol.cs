using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroll : Enemy
{
    [SerializeField] Transform[] waypoints;   
    [SerializeField] float patrolSpeed = 2f;  
    [SerializeField] float pursuitSpeed = 4f; 
    [SerializeField] Transform player;       
    [SerializeField] float attackRange = 5f;  

    private int currentWaypointIndex = 0;

    protected override void Update()
    {
        base.Update();

        
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            Pursuit();
        }
        else
        {
            Patrol();
        }
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

    private void Pursuit()
    {
        
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        
        AddForce(directionToPlayer * pursuitSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerModel playerScript = collision.collider.GetComponent<PlayerModel>();
            if (playerScript != null)
            {
                playerScript.currentHealth -= 1;
                playerScript.UpdateHealthBar(playerScript.currentHealth);
                Debug.Log("Enemigo tocó al jugador. Vida restante: " + playerScript.currentHealth);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
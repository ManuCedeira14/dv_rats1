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
    [SerializeField] private audiomanager soundManager;

    private int currentWaypointIndex = 0;

    private Animator animator; // Componente Animator

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>(); // Obtener el Animator
    }

    protected override void Update()
    {
        base.Update();

        // Si el jugador est� dentro del rango de ataque, perseguir
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

        // Configurar la animaci�n en modo walk
        animator.SetFloat("Speed", patrolSpeed);

        // Verificar si se alcanza el waypoint
        if (Vector3.Distance(transform.position, targetWaypoint) < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    private void Pursuit()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        AddForce(directionToPlayer * pursuitSpeed);

        // Configurar la animaci�n en modo run
        animator.SetFloat("Speed", pursuitSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Player playerScript = collision.collider.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.Actuallife -= 1;
                soundManager.PlaySound(0);
                playerScript.UpdateHealthBar();
                Debug.Log("Enemigo toc� al jugador. Vida restante: " + playerScript.Actuallife);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

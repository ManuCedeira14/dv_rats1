using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    // Transform que define la posición y rotación de destino
    [SerializeField] private Transform teleportDestination;

    private void OnTriggerEnter(Collider other)
    {
        // Asegúrate de que el objeto que entra tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Cambia la posición del jugador al destino
            other.transform.position = teleportDestination.position;

            // Opcional: Cambiar también la rotación si es necesario
            other.transform.rotation = teleportDestination.rotation;

            // Si el jugador tiene un Rigidbody, resetea su velocidad
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            Debug.Log("Player teleportado a: " + teleportDestination.position);
        }
    }
}

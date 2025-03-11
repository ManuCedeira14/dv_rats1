using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winStar : MonoBehaviour
{
    [SerializeField] public bool starGrabbed;
    [SerializeField] private GameObject portal;
    [SerializeField] private Material material;      // Material del shader de la estrella
    [SerializeField] private Transform player;       // Referencia al transform del jugador
    private const float activationDistance = 50f;     // Distancia para cambiar color (5 unidades)

    private Color originalColor;                     // Almacena el color original
    private bool playerInRange = false;
    private void Start()
    {
        originalColor = material.GetColor("_basecolor");
    }
    private void Awake()
    {
        starGrabbed = false;
        if (portal != null)
        {
            portal.SetActive(false);  
        }
        if (material != null && material.HasProperty("_basecolor"))
        {
            originalColor = material.GetColor("_basecolor");
            Debug.Log("Material y propiedad _basecolor encontrada. Color original: " + originalColor);
        }
        else
        {
            Debug.LogWarning("Material o propiedad _basecolor no encontrada. Material: " + material);
        }

        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
                Debug.Log("Jugador encontrado: " + player.name + " en posición: " + player.position);
            }
            else
            {
                Debug.LogError("No se encontró un objeto con el tag 'Player'. Por favor asigna el transform del jugador.");
            }
        }
        else
        {
            Debug.Log("Jugador asignado manualmente: " + player.name + " en posición: " + player.position);
        }

        // Mostrar la posición de la estrella
        Debug.Log("Posición de la estrella: " + transform.position);
    }
    private void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Debug.Log($"Distancia al jugador: {distanceToPlayer} unidades (Activation Distance: {activationDistance})");

        // Si el jugador está a 5 unidades o menos, cambiar el color a verde
        if (distanceToPlayer <= activationDistance)
        {
            Debug.Log("Cambio de color activado (dentro del rango)");
            if (!playerInRange) // Solo cambiar el color si no estaba ya en rango
            {
                playerInRange = true;
                if (material != null && material.HasProperty("_basecolor"))
                {
                    material.SetColor("_basecolor", Color.green);
                    Debug.Log("Estrella cambió a verde. Nuevo color: " + material.GetColor("_basecolor"));
                }
                else
                {
                    Debug.LogWarning("No se puede cambiar el color. Material o propiedad _BaseColor no encontrada.");
                }
            }
        }
        else
        {
            if (playerInRange) // Restaurar el color si el jugador sale del rango
            {
                playerInRange = false;
                if (material != null && material.HasProperty("_basecolor"))
                {
                    material.SetColor("_basecolor", originalColor);
                    Debug.Log("Estrella volvió a su color original. Color restaurado: " + material.GetColor("_basecolor"));
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            starGrabbed = true;
            Destroy(gameObject);
            ActivatePortal();
        }
    }

    private void ActivatePortal()
    {
        if (portal != null)
        {
            portal.SetActive(true);  
        }
    }
}

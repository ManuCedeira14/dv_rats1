using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movagua : MonoBehaviour
{
    [SerializeField] private Material fullScreenMaterial; // Material del shader de pantalla completa
    private float blend;                      // Almacena la intensidad original del efecto

    private void Awake()
    {
        // Guardar la intensidad original del efecto
        if (fullScreenMaterial != null && fullScreenMaterial.HasProperty("_blend"))
        {
            blend = fullScreenMaterial.GetFloat("_blend");
            Debug.Log("Intensidad original del efecto: " + blend);
        }
        else
        {
            Debug.LogWarning("Material de pantalla completa o propiedad _blend no encontrada. Material asignado: " + fullScreenMaterial);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("encontre al player");
        if (other.CompareTag("Player"))
        {
            // Activar el efecto de pantalla completa
            if (fullScreenMaterial != null && fullScreenMaterial.HasProperty("_blend"))
            {
                fullScreenMaterial.SetFloat("_blend", 0.2f); // Activar el efecto
                Debug.Log("Efecto de pantalla completa activado. Nueva intensidad: " + fullScreenMaterial.GetFloat("_blend"));
            }
            else
            {
                Debug.LogWarning("No se puede activar el efecto. Material o propiedad _blend no encontrada.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Desactivar el efecto de pantalla completa
            if (fullScreenMaterial != null && fullScreenMaterial.HasProperty("_blend"))
            {
                fullScreenMaterial.SetFloat("_blend", blend); // Restaurar la intensidad original
                Debug.Log("Efecto de pantalla completa desactivado. Intensidad restaurada: " + fullScreenMaterial.GetFloat("_blend"));
            }
        }
    }
}

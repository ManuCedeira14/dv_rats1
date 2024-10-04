using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        LifeHandler lifeHandler = FindObjectOfType<LifeHandler>();
        if (lifeHandler != null)
        {
            // Suscribirse al evento de cambio de vida
            lifeHandler.OnLifeChanged += UpdateHealthBar;

            // Inicializar la barra de vida con el valor máximo
            MaxHealth((int)lifeHandler._maxLife);
        }
    }

    public void MaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Método para actualizar la barra de vida cuando el evento es disparado
    public void UpdateHealthBar(float currentLife)
    {
        slider.value = currentLife;
    }

    private void OnDestroy()
    {
        LifeHandler lifeHandler = FindObjectOfType<LifeHandler>();
        if (lifeHandler != null)
        {
            // Desuscribirse del evento de cambio de vida cuando el objeto se destruye
            lifeHandler.OnLifeChanged -= UpdateHealthBar;
        }
    }
}

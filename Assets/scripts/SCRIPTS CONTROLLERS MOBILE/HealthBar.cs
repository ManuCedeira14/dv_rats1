using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void Initialize(LifeHandler lifeHandler)
    {
        if (lifeHandler != null)
        {
            lifeHandler.OnLifeChanged += UpdateHealthBar;

            MaxHealth((int)lifeHandler.MaxLife);
            Debug.Log("Suscrito a OnLifeChanged y barra de vida inicializada");
        }
        else
        {
            Debug.LogError("No se encontró LifeHandler para suscribirse");
        }
    }

    public void MaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void UpdateHealthBar(float currentLife)
    {
        slider.value = currentLife;
        Debug.Log("Barra de vida actualizada: " + currentLife);
    }

    private void OnDestroy()
    {
        LifeHandler lifeHandler = FindObjectOfType<LifeHandler>();
        if (lifeHandler != null)
        {
            lifeHandler.OnLifeChanged -= UpdateHealthBar;
        }
    }
}

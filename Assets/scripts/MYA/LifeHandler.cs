using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//mio
public class LifeHandler : MonoBehaviour
{
    [SerializeField] public float _maxLife = 5f;
    [SerializeField] public float _currentLife;
    public float MaxLife => _maxLife; // Propiedad para acceso a _maxLife
    public float CurrentLife => _currentLife;

    // Evento para notificar cuando la vida cambia
    public event Action<float> OnLifeChanged = delegate { };
    // Evento para notificar cuando el jugador muere
    public event Action OnDead = delegate { };

    private void Awake()
    {
        _currentLife = _maxLife;
    }

    public void TakeDamage(float dmg)
    {
        _currentLife -= dmg;
        Debug.Log($"Current life = {_currentLife}");

        // Llamar al evento de vida cambiada
        OnLifeChanged(_currentLife);

        if (_currentLife <= 0)
        {
            Dead();
        }
    }

    public void Heal(float amount)
    {
        _currentLife += amount;
        _currentLife = Mathf.Clamp(_currentLife, 0, _maxLife);

        // Llamar al evento de vida cambiada
        OnLifeChanged(_currentLife);
    }

    void Dead()
    {
        Debug.Log("Player is dead");

        // Llamar al evento de muerte
        OnDead();
    }
}
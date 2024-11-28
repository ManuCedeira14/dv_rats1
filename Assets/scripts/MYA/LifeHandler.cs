using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
//mio
public class LifeHandler : MonoBehaviour
{
    [SerializeField] public float _maxLife = 5f;
    [SerializeField] public float _currentLife;
    public float MaxLife => _maxLife; 
    public float CurrentLife => _currentLife;

   


    public event Action<float> OnLifeChanged = delegate { };

    public event Action OnDead = delegate { };

    private void Awake()
    {
        _currentLife = _maxLife;
    }

    public void TakeDamage(float dmg)
    {
        _currentLife -= dmg;
        
        Debug.Log($"Current life = {_currentLife}");

        if (OnLifeChanged != null)
        {
            OnLifeChanged(_currentLife);  
            Debug.Log("Evento OnLifeChanged disparado");
        }

        if (_currentLife <= 0)
        {
            Dead();
        }
    }

    public void Heal(float amount)
    {
        _currentLife += amount;
        _currentLife = Mathf.Clamp(_currentLife, 0, _maxLife);

        if (OnLifeChanged != null)
        {
            OnLifeChanged(_currentLife);  
            Debug.Log("Evento OnLifeChanged disparado (Heal)");
        }
    }

    void Dead()
    {
        Debug.Log("Player is dead");
        SceneManager.LoadScene(2);

        OnDead();
    }
}
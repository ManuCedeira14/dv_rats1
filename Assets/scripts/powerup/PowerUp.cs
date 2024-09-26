//TP2 Manuel Cedeira

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public bool _pickedUp;
    protected string _powerUpType;
    protected float _timer=5f;


    public void DestroyPowerUp() 
    {
        Destroy(gameObject);
    }
    
}

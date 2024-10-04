using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReducerSpeed : MonoBehaviour
{
    public float reducedSpeed;
    private float originalSpeed;
    private PlayerModel _player;

    private void Start()
    {
        originalSpeed = 20f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.GetComponent<PlayerModel>();

            if (_player != null)
            {
                _player.TakeDamage(1); 
<<<<<<< HEAD

               
=======


>>>>>>> a6b0a709c4537d7c6f44533c76a7c91db8e7f847
                _player.speed = reducedSpeed;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _player != null)
        {
            Debug.Log("salio del trigger");
            _player.speed = originalSpeed;
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeDecorator : IPlayerDecorator
{
    private  PlayerModel _player;
    private  Renderer _renderer;
    private  Material _damageMaterial;
    private  Material _defaultMaterial;
    private float _damageDuration = 1f; 

    public MaterialChangeDecorator(PlayerModel player, Renderer renderer, Material damageMaterial, Material defaultMaterial)
    {
        _player = player;
        _renderer = renderer;
        _damageMaterial = damageMaterial;
        _defaultMaterial = defaultMaterial;
    }

    public void TakeDamage(float damage)
    {
        
        if (_renderer == null)
        {
            Debug.LogError("Renderer no está configurado correctamente.");
            return;
        }

       
        _renderer.material = _damageMaterial;
        _player.StartCoroutine(ResetMaterialAfterDelay());
    }

    private System.Collections.IEnumerator ResetMaterialAfterDelay()
    {
        yield return new WaitForSeconds(_damageDuration);
        
        _renderer.material = _defaultMaterial;
    }
}


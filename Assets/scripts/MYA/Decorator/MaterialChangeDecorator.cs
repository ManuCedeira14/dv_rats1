using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeDecorator : PlayerDecorator
{
    
    private Material _defaultMaterial;
    private Material _damageMaterial;
    private Renderer _renderer;

    public MaterialChangeDecorator(PlayerModel player, Material damageMaterial) : base(player)
    {
        _renderer = player.GetComponent<Renderer>();
        _defaultMaterial = _renderer.material;
        _damageMaterial = damageMaterial;
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

       
        _renderer.material = _damageMaterial;
        _player.StartCoroutine(ResetMaterial());
    }

    private System.Collections.IEnumerator ResetMaterial()
    {
        yield return new WaitForSeconds(0.5f); 
        _renderer.material = _defaultMaterial;
    }
}


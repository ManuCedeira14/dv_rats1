using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessDecorator : PlayerDecorator
{
    private PostProcessVolume _postProcessVolume;

    public PostProcessDecorator(PlayerModel player, PostProcessVolume postProcessVolume) : base(player)
    {
        _postProcessVolume = postProcessVolume;
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

        // Activar efecto de postproceso
        _postProcessVolume.enabled = true;
        _player.StartCoroutine(DisablePostProcess());
    }

    private System.Collections.IEnumerator DisablePostProcess()
    {
        yield return new WaitForSeconds(1f); // Mantener el efecto por 1 segundo
        _postProcessVolume.enabled = false;
    }
}

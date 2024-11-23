using UnityEngine;
using System.Collections.Generic;

public class audiomanager : MonoBehaviour
{
    public AudioSource audioSource; 
    public List<AudioClip> soundClips = new List<AudioClip>(); 
    public void PlaySound(int soundIndex)
    {
        if (soundIndex >= 0 && soundIndex < soundClips.Count)
        {
            audioSource.PlayOneShot(soundClips[soundIndex]);  
        }
        else
        {
            Debug.LogWarning("Índice de sonido fuera de rango");
        }
    }
}

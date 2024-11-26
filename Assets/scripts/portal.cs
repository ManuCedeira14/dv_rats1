using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    [SerializeField] private winStar starScript; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && starScript.starGrabbed)  
        {
            WonScene(); 
        }
    }

    private void WonScene()
    {
        SceneManager.LoadScene(3);  
    }
}

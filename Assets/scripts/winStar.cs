using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winStar : MonoBehaviour
{
    [SerializeField] public bool starGrabbed;
    GameManager Gm;
    public void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
            starGrabbed = true;
            Destroy(gameObject);
            Gm.WonScene();
        }
    }
    
}

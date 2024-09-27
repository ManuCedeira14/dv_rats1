using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winStar : MonoBehaviour
{
    [SerializeField] public bool starGrabbed;

    private void Awake()
    {
        starGrabbed = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            starGrabbed = true;
            Destroy(gameObject);
            WonScene();
        }
    }
    public void WonScene()
    {
        if (starGrabbed)
            SceneManager.LoadScene(3);
    }
}

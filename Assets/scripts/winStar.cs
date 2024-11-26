using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winStar : MonoBehaviour
{
    [SerializeField] public bool starGrabbed;
    [SerializeField] private GameObject portal;

    private void Awake()
    {
        starGrabbed = false;
        if (portal != null)
        {
            portal.SetActive(false);  
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            starGrabbed = true;
            Destroy(gameObject);
            ActivatePortal();
        }
    }

    private void ActivatePortal()
    {
        if (portal != null)
        {
            portal.SetActive(true);  
        }
    }
}

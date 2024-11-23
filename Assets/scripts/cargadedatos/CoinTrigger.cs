using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
     private playerprefs playerPrefs; 
    [SerializeField] private int rotationSpeed;
    [SerializeField] private audiomanager soundManager;
    private void Start()
    {
        if (playerPrefs == null)
        {
            playerPrefs = FindObjectOfType<playerprefs>();
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            if (playerPrefs != null)
            {
                playerPrefs.AddCoin(1);
                soundManager.PlaySound(1);
                Debug.Log("Moneda recogida.");
            }
            else
            {
                Debug.LogError("playerprefs no está asignado.");
            }

            Destroy(gameObject); 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerprefs : MonoBehaviour
{
    [SerializeField] private float actualLife;
    [SerializeField] private int coins;

    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private TMP_Text coinsText;

    public void SaveData()
    {
        PlayerPrefs.SetFloat(keys.actualLifeKey, actualLife);
        PlayerPrefs.SetInt(keys.coinsKey, coins);
    }

    public void LoadData()
    {
        actualLife = PlayerPrefs.GetFloat(keys.actualLifeKey, keys.actualLifDefault);
        coins = PlayerPrefs.GetInt(keys.coinsKey, keys.coinsDefault);

        lifeText.text = "Life: " + actualLife;
        coinsText.text = "COINS: " + coins;
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        coinsText.text = "COINS: " + coins;  
        SaveData();  
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;  
            coinsText.text = "COINS: " + coins;
            SaveData();  
            Debug.Log($"Monedas restantes: {coins}");
            return true; 
        }
        else
        {
            Debug.Log("No hay suficientes monedas");
            return false;  
        }
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        LoadData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause) SaveData();
    }

    private void OnApplicationFocus(bool focus)
    {
        if(!focus) SaveData();
    }
}

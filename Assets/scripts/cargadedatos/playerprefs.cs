using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerprefs : MonoBehaviour
{
    [SerializeField] private float actualLife;
    [SerializeField] private int coins;
    CoinTrigger coin;
    [SerializeField] public float staminaValue = 100;
    public Slider StaminaSlider;
    [SerializeField] private TMP_Text coinsText;

    [SerializeField] private Player _player; 

    private void Start()
    {
        StaminaSlider.maxValue = 100;
        StaminaSlider.value = staminaValue;
    }

    public void Update()
    {
        DownStamina();
        StaminaSlider.value = staminaValue;
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("ActualLife", actualLife);
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void LoadData()
    {
        actualLife = PlayerPrefs.GetFloat("ActualLife", 100); // Usa un valor predeterminado de 100.
        coins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = ""+ coins;
    }

    public void AddCoin(int amount)
    {
        
       
            coins += amount;
            coinsText.text = "" + coins;
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
        if (pause) SaveData();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus) SaveData();
    }

    public void DownStamina()
    {
        if (_player != null && _player._isMoving)
        {
            staminaValue -= 17 * Time.deltaTime; 
            
        }
        else
        {
            staminaValue += 10 * Time.deltaTime; 
        }
        staminaValue = Mathf.Clamp(staminaValue, 0, 100);
    }

    
}

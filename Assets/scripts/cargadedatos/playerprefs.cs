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
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private TMP_Text coinsText;
    private const string positionKeyX = "PlayerPosX";
    private const string positionKeyY = "PlayerPosY";
    private const string positionKeyZ = "PlayerPosZ";
    

    [SerializeField] private Player _player;

    private void Awake()
    {
        LoadData();
    }

    private void Update()
    {
        DownStamina();
        StaminaSlider.value = staminaValue;
    }
    private void Start()
    {
        if (StaminaSlider == null)
        {
            Debug.LogError("StaminaSlider no está asignado.");
        }
        else
        {
            Debug.Log("stamina asignada!");
        }
        StaminaSlider.maxValue = 100;
        StaminaSlider.value = staminaValue;
    }

    

    public void SaveData()
    {
        PlayerPrefs.SetFloat("ActualLife", actualLife);
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetFloat(keys.staminaKey, staminaValue);
        if (_player != null)
        {
            PlayerPrefs.SetFloat(keys.positionKeyX, _player.transform.position.x);
            PlayerPrefs.SetFloat(keys.positionKeyY, _player.transform.position.y);
            PlayerPrefs.SetFloat(keys.positionKeyZ, _player.transform.position.z);
        }
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        actualLife = PlayerPrefs.GetFloat("ActualLife", 100); 
        if(lifeText != null)
            lifeText.text = "" + actualLife;
        coins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = coins.ToString();
        if (_player != null)
        {
            float posX = PlayerPrefs.GetFloat(keys.positionKeyX, _player.transform.position.x);
            float posY = PlayerPrefs.GetFloat(keys.positionKeyY, _player.transform.position.y);
            float posZ = PlayerPrefs.GetFloat(keys.positionKeyZ, _player.transform.position.z);

            _player.transform.position = new Vector3(posX, posY, posZ);
            Debug.Log($"Posición del jugador cargada: ({posX}, {posY}, {posZ})");
        }
        UpdateUI();
    }

    public void ContinueGame()
    {
        LoadData();
        Debug.Log("Continuando partida con datos cargados.");
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
        ResetToDefaults();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ResetToDefaults()
    {
        actualLife = keys.actualLifDefault;
        coins = keys.coinsDefault;
        staminaValue = keys.staminaDefault;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //lifeText.text = "actual life: " + actualLife.ToString("F0"); // Mostrar HP sin decimales
        coinsText.text = "COINS: " + coins;
        StaminaSlider.value = staminaValue;
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

    public void PauseGame()
    {
        SaveData();
        Time.timeScale = 0f; 
        Debug.Log("Juego pausado y datos guardados.");
    }

    public void ResumeGame()
    {

        Time.timeScale = 1f; 
        Debug.Log("Partida cargada y juego reanudado.");
    }

    public void DownStamina()
    {
        if (_player != null && _player._isMoving)
        {
            staminaValue -= 17 * Time.deltaTime;
            Debug.Log("Stamina está bajando: " + staminaValue);

        }
        else
        {
            staminaValue += 10 * Time.deltaTime; 
        }
        staminaValue = Mathf.Clamp(staminaValue, 0, 100);
    }

    
}

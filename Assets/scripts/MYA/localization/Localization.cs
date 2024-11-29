using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public enum Language
{
    Spanish,
    English
}

[DefaultExecutionOrder(-50)]
public class Localization : MonoBehaviour
{
    [SerializeField] string _webURL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vSeL1zlunFtUP-hKhtjVbpKkUg2WYSCAByHPnuPHb8EkgAU6IWnWa8YOCOfkWdTWnQZIF_RdWgpfJaR/pub?output=csv";

    [SerializeField] Language _currentLanguage;

    Dictionary<Language, Dictionary<string, string>> _localization;

    public event Action OnUpdate = delegate { };

    public static Localization Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        StartCoroutine(DownloadCSV(_webURL));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _currentLanguage = _currentLanguage == Language.Spanish ? Language.English : Language.Spanish;
            
            OnUpdate();
        }
    }

    IEnumerator DownloadCSV(string url)
    {
        var www = new UnityWebRequest(url);

        www.downloadHandler = new DownloadHandlerBuffer();

        //www.Abort();

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            var result = www.downloadHandler.text;

            _localization = SheetSplit.LoadCSV(result, "web");

            SaveSheet("Localization", result);
        }
        else
        {
            var result = LoadSheet("Localization");
            _localization = SheetSplit.LoadCSV(result, "disk");
        }

        OnUpdate();
    }

    public string GetTranslate(string ID)
    {
        if (_localization == null) return null;

        var idsDictionary = _localization[_currentLanguage];

        idsDictionary.TryGetValue(ID, out var result);

        return result;
    }

    void SaveSheet(string fileName, string sheet)
    {
        string path = Application.persistentDataPath + "/" + fileName;

        try
        {
            File.WriteAllText(path, sheet);
            Debug.Log($"File saved successfully at: {path}");
        }
        catch(Exception e)
        {
            Debug.LogError($"Failed to save file: {e}");
        }
    }

    string LoadSheet(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName;

        try
        {
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                Debug.Log($"File loaded successfully from: {path}");
                return content;
            }
            else
            {
                Debug.LogError($"File not found at: {path}");
                return null;
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load file: {e}");
            return null;
        }
    }
}

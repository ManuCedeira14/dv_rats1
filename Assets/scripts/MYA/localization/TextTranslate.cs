using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextTranslate : MonoBehaviour
{

    [SerializeField] string _id;

    [SerializeField] Localization _localization;

    [SerializeField] TextMeshProUGUI _myText;


    void Awake()
    {
        _localization.OnUpdate += ChangeLang;
    }

    void ChangeLang()
    {
        _myText.text = _localization.GetTranslate(_id);
    }

    private void OnDestroy()
    {
        _localization.OnUpdate -= ChangeLang;
    }
}

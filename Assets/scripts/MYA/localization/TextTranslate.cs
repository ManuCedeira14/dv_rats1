using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextTranslate : MonoBehaviour
{

    [SerializeField] string _id;
    [SerializeField] TextMeshProUGUI _myText;


    void Awake()
    {
        Localization.Instance.OnUpdate += ChangeLang;
        ChangeLang();
    }

    void ChangeLang()
    {
        _myText.text = Localization.Instance.GetTranslate(_id);
    }

    private void OnDestroy()
    {
        Localization.Instance.OnUpdate -= ChangeLang;
    }
}

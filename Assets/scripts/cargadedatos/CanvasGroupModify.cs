using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupModify : MonoBehaviour
{
    [SerializeField] CanvasGroup _myCanvasGroup;

    private void Start()
    {
        ShowOrHideMenu(false);

    }

    public void ShowOrHideMenu(bool Value)
    {
        if (Value) _myCanvasGroup.alpha = 1;
        else _myCanvasGroup.alpha = 0;

        _myCanvasGroup.interactable = Value;
        _myCanvasGroup.blocksRaycasts = Value;
    }
}

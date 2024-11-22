using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupModify : MonoBehaviour
{
    [SerializeField] private Canvas menuPrincipal;
    [SerializeField] private Canvas pausa;
    [SerializeField] private Canvas options;
    [SerializeField] private CanvasGroup shop;

    private void Start()
    {
        ShowMenu();

    }
    public void ShowMenu()
    {
        
        menuPrincipal.gameObject.SetActive(true);

        
        ShowOrHideShop(false);
    }

    public void ShowPause()
    {
        menuPrincipal.gameObject.SetActive(false);
        pausa.gameObject.SetActive(true);
        options.gameObject.SetActive(false);
        ShowOrHideShop(false); 
    }

    public void ShowOptions()
    {
        menuPrincipal.gameObject.SetActive(false);
        pausa.gameObject.SetActive(false);
        options.gameObject.SetActive(true);
        ShowOrHideShop(false); 
    }
    public void ShowShop()
    {
        
        menuPrincipal.gameObject.SetActive(false);

       
        ShowOrHideShop(true);
    }

    private void ShowOrHideShop(bool value)
    {
        shop.alpha = value ? 1 : 0;
        shop.interactable = value;
        shop.blocksRaycasts = value;
    }

}
 

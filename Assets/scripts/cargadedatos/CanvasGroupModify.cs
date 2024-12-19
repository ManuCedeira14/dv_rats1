using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasGroupModify : MonoBehaviour
{
    [SerializeField] private Canvas menuppal; 
    [SerializeField] private Canvas pausa;
    [SerializeField] private Canvas options;
    [SerializeField] private CanvasGroup shop;

    private void Start()
    {
        ShowMenu();
    }

    public void ShowMenu()
    {
        menuppal.gameObject.SetActive(true); 
        pausa.gameObject.SetActive(false);       
        ShowOrHideShop(false);
        if (options != null)
            options.gameObject.SetActive(false);
    }

    public void ShowMenumenu()
    {
        menuppal.gameObject.SetActive(false);
        pausa.gameObject.SetActive(false);
        ShowOrHideShop(false);
        if (options != null)
            options.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void ShowLevelDos()
    {
        menuppal.gameObject.SetActive(false);
        pausa.gameObject.SetActive(false);
        ShowOrHideShop(false);
        if (options != null)
            options.gameObject.SetActive(false);
        SceneManager.LoadScene(4);
    }
    public void ShowPause()
    {
        menuppal.gameObject.SetActive(false);
        pausa.gameObject.SetActive(true);
        if (options != null)
            options.gameObject.SetActive(false);
        ShowOrHideShop(false);
    }

    public void ShowOptions()
    {
       menuppal.gameObject.SetActive(false);
        pausa.gameObject.SetActive(false);
        if (options != null)
            options.gameObject.SetActive(true);
        ShowOrHideShop(false); 
    }

    public void ShowShop()
    {
        menuppal.gameObject.SetActive(false);
        pausa.gameObject.SetActive(false);

        if (options != null)
            options.gameObject.SetActive(false);
        ShowOrHideShop(true);
    }

    private void ShowOrHideShop(bool value)
    {
        if (shop == null) return;
        
        shop.alpha = value ? 1 : 0;
        shop.interactable = value;
        shop.blocksRaycasts = value;
    }

   
}



//    private void Start()
//    {
//        ShowMenu();

//    }
//    public void ShowMenu()
//    {

//        menuPrincipal.gameObject.SetActive(true);


//        ShowOrHideShop(false);
//    }

//    public void ShowPause()
//    {
//        menuPrincipal.gameObject.SetActive(false);
//        pausa.gameObject.SetActive(true);
//        options.gameObject.SetActive(false);
//        ShowOrHideShop(false); 
//    }

//    public void ShowOptions()
//    {
//        menuPrincipal.gameObject.SetActive(false);
//        pausa.gameObject.SetActive(false);
//        options.gameObject.SetActive(true);
//        ShowOrHideShop(false); 
//    }
//    public void ShowShop()
//    {

//        menuPrincipal.gameObject.SetActive(false);


//        ShowOrHideShop(true);
//    }

//    private void ShowOrHideShop(bool value)
//    {
//        shop.alpha = value ? 1 : 0;
//        shop.interactable = value;
//        shop.blocksRaycasts = value;
//    }

//}

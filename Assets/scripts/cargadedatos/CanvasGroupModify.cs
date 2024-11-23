using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupModify : MonoBehaviour
{
    [SerializeField] private Canvas niveluno; // Canvas del men� principal
    [SerializeField] private Canvas pausa;        // Canvas del men� de pausa

    private void Start()
    {
        // Configuraci�n inicial: mostrar el men� principal
        ShowNivelUno();
    }

    public void ShowNivelUno()
    {
        niveluno.gameObject.SetActive(true); // Activa el men� principal
        pausa.gameObject.SetActive(false);       // Desactiva el men� de pausa
    }

    public void ShowPause()
    {
        niveluno.gameObject.SetActive(false); // Desactiva el men� principal
        pausa.gameObject.SetActive(true);         // Activa el men� de pausa
    }

}
//{
//    [SerializeField] private Canvas menuPrincipal;
//    [SerializeField] private Canvas pausa;
//    [SerializeField] private Canvas options;
//    [SerializeField] private CanvasGroup shop;

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

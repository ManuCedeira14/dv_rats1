using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupModify : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    [SerializeField] private Canvas menuPrincipal; // Canvas del men� principal
    [SerializeField] private Canvas pausa;        // Canvas del men� de pausa
    [SerializeField] private Canvas options;      // Canvas del men� de opciones
    [SerializeField] private CanvasGroup shop;    // CanvasGroup del shop

    private void Start()
    {
        // Configuraci�n inicial: mostrar el men� principal
        ShowMenu();
    }

    public void ShowMenu()
    {
        menuPrincipal.gameObject.SetActive(true); // Activa el men� principal
        pausa.gameObject.SetActive(false);       // Desactiva el men� de pausa
        options.gameObject.SetActive(false);     // Desactiva el men� de opciones
        ShowOrHideShop(false);                   // Oculta el shop
    }

    public void ShowPause()
    {
        menuPrincipal.gameObject.SetActive(false); // Desactiva el men� principal
        pausa.gameObject.SetActive(true);         // Activa el men� de pausa
        options.gameObject.SetActive(false);      // Desactiva el men� de opciones
        ShowOrHideShop(false);                    // Oculta el shop
    }

    public void ShowOptions()
    {
        menuPrincipal.gameObject.SetActive(false); // Desactiva el men� principal
        pausa.gameObject.SetActive(false);         // Desactiva el men� de pausa
        options.gameObject.SetActive(true);        // Activa el men� de opciones
        ShowOrHideShop(false);                     // Oculta el shop
    }

    public void ShowShop()
    {
        menuPrincipal.gameObject.SetActive(false); // Desactiva el men� principal
        pausa.gameObject.SetActive(false);         // Desactiva el men� de pausa
        options.gameObject.SetActive(false);       // Desactiva el men� de opciones
        ShowOrHideShop(true);                      // Muestra el shop
    }

    private void ShowOrHideShop(bool value)
    {
        shop.alpha = value ? 1 : 0;           // Cambia la opacidad
        shop.interactable = value;            // Habilita/deshabilita la interacci�n
        shop.blocksRaycasts = value;          // Bloquea o permite raycasts
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
 
>>>>>>> 775579a4562d78dc8be598b1cbefeb2f580feb4d

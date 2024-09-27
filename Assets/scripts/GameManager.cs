using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Player player;
    winStar winStar;
    public void NextScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        NextScene();
    }
    public void OnPointerUp(PointerEventData eventData)
    { 
    }
}

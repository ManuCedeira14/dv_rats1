using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    PlayerModel player;
    
    public void NextScene()
    {
         SceneManager.LoadSceneAsync(1);
    }
 
}

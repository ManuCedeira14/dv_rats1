using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour/*, IPointerDownHandler, IPointerUpHandler*/
{
    public Material dmgShader;
    private const string BoolParameterName = "_on_off";
    public void NextScene()
    {
        SceneManager.LoadSceneAsync(1);
        dmgShader.SetFloat(BoolParameterName, 0.0f);
        Debug.Log("hiciste click");
    }
    
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    NextScene();
    //}
    //public void OnPointerUp(PointerEventData eventData)
    //{ 
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class initialseads : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameId = "5731199";
    [SerializeField] private bool testing;

    private string gameId;

    private void Awake()
    {
#if UNITY_IOS
        gameId = iosGameId;
#elif UNITY_ANDROID
        gameId = androidGameId;
#elif UNITY_EDITOR
        gameId = androidGameId;
#endif

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, testing, this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ads initialized.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {

    }

}

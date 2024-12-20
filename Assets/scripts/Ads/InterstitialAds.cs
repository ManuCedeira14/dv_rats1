using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitId = "Interstitial_Android";

    private string adUnitId;

    private void Awake()
    {

#if UNITY_ANDROID|| UNITY_EDITOR

        adUnitId = androidAdUnitId;
#endif
    }

    public void LoadInterstitialAd()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowInterstitialAd()
    {
        Advertisement.Show(adUnitId, this);
        LoadInterstitialAd();
    }

    #region SHOW CALLBACKS

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {

    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        //ahora volvemos
    }

    #endregion

    #region LOAD CALLBACKS

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Rewarded Ad Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Ad fallo");
    }

    #endregion
}
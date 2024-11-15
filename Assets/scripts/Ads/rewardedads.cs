using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class rewardedads : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitId = "Rewarded_Android";
    [SerializeField] private string iosAdUnitId = "Rewarded_iOS";

    private string adUnitId;

    private void Awake()
    {
#if UNITY_IOS
    adUnitId = iosAdUnitId;
#elif UNITY_ANDROID
    adUnitId = androidAdUnitId;
#endif
    }

    public void LoadRewardedAd()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowRewardedAd()
    {
        Advertisement.Show(adUnitId, this);
        LoadRewardedAd();
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

        Debug.Log("Unity Rewarded Ad");

        if (showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
            Debug.Log("COMPLETED");
        else if (showCompletionState.Equals(UnityAdsShowCompletionState.SKIPPED))
            Debug.Log("SKIPPED");
        else if (showCompletionState.Equals(UnityAdsShowCompletionState.UNKNOWN))
            Debug.Log("ERROR");

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    [SerializeField] private string androidAdUnitId = "Banner_Android";

    private string adUnitId;


    private void Awake()
    {
#if UNITY_ANDROID || UNITY_EDITOR

        adUnitId = androidAdUnitId;
#endif


        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }
    private void Start()
    {
        LoadBannerAd();
        ShowBannerAd();
    }

    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = BannerLoaded,
            errorCallback = BannerLoadError
        };

        Advertisement.Banner.Load(adUnitId, options);
    }

    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback = BannerShown,
            hideCallback = BannerHidden,
            clickCallback = BannerClicked
        };

        Advertisement.Banner.Show(adUnitId, options);
    }


    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    #region SHOW CALLBACKS

    public void BannerHidden() { }
    public void BannerShown() { }
    public void BannerClicked() { }

    #endregion

    #region LOAD CALLBACKS

    void BannerLoaded()
    {
        Debug.Log("Banner Ad Loaded");
    }

    void BannerLoadError(string error) { }

}
#endregion


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public initialseads initializeAds;
    public rewardedads rewardedAds;
    public BannerAds bannerAds;
    public InterstitialAds interstitialAds;


    public static AdsManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        rewardedAds.LoadRewardedAd();
        StartCoroutine(BannerAd());

    }


    public void ShowRewardedAd()
    {
        rewardedAds.ShowRewardedAd();
    }

    public void ShowInterstitialAd()
    {
        interstitialAds.ShowInterstitialAd();
    }

    IEnumerator BannerAd()
    {
        while (true)
        {
            bannerAds.LoadBannerAd();
            yield return new WaitForSeconds(5f);
            //ShowInterstitialAd();
            bannerAds.ShowBannerAd();
            yield return new WaitForSeconds(10f);
            bannerAds.HideBannerAd();
            yield return new WaitForSeconds(10f);
        }
    }
}
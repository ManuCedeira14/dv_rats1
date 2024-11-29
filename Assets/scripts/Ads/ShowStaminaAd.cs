using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStaminaAd : MonoBehaviour
{
    public void RewardStamina()
    {
        AdsManager.Instance.ShowRewardedAd();
    }
}

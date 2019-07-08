using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsController : MonoBehaviour 
{
    public void StartAds() 
    {
        if(Advertisement.IsReady("rewardedVideo")) 
        {
            Advertisement.Show("rewardedVideo");
        }
    }

}

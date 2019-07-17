using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsController : MonoBehaviour 
{
    public Button ads;
    public void StartAds() 
    {
        if(Advertisement.IsReady("rewardedVideo")) 
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                StartCoroutine(Reward());
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    IEnumerator Reward()
    {
        yield return new WaitForSeconds(2); // star some gift animation and instantiate bone
        GameObject bone = Resources.Load("SpecialBone") as GameObject; ;
        Instantiate(bone, ads.transform.position, Quaternion.identity);
    }
}

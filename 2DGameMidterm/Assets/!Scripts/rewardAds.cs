using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class rewardAds : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "3866354";
#elif UNITY_ANDROID
    private string gameId = "3866355";
#endif

    public playerValue gameValues; //ScriptableObject

    public Button myButton;
    public Text myCoinTXT;
    public string myPlacementId = "rewardedVideo";

    private int currentCoin;

    // Start is called before the first frame update
    void Start()
    {

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady(myPlacementId);

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);

    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            currentCoin = PlayerPrefs.GetInt("MyCoin");
            currentCoin = currentCoin + gameValues.rewardAdsPrice;
            PlayerPrefs.SetInt("MyCoin", currentCoin);
            StartCoroutine(updateMyCoin());
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    IEnumerator updateMyCoin()
    {
        while ( myCoinTXT.enabled == false)
        {
            yield return new WaitForSeconds(0.5f);
        }
        myCoinTXT.text = "" + currentCoin;
    }

}

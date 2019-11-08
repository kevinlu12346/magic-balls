using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class googleads : MonoBehaviour
{
    private BannerView bannerView;
    private RewardedAd rewardedAd;
    public ReviveScreen revive;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        //string appId = "ca-app-pub-2143595815920187~1981355806";

// test
        string appId = "ca-app-pub-2143595815920187~1981355806";

        MobileAds.Initialize(appId);

        this.RequestBanner();
        //Display_Banner();
        this.RequestVideo();

    }
    private void RequestBanner()
    {
        //string adUnitId = "ca-app-pub-2143595815920187~1981355806";


        // test
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";


        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

                // Called when an ad request has successfully loaded.
                this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;

        // Create an empty ad request. for testing
        AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
    public void Display_Banner() {
        this.bannerView.Show();
    }


    private void RequestVideo() {
         // test
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";



        // Create a 320x50 banner at the top of the screen.
        this.rewardedAd = new RewardedAd(adUnitId);

                        // Called when the user should be rewarded for interacting with the ad.
                        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;

        // Create an empty ad request. for testing
        AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        // Load the banner with the request.
        this.rewardedAd.LoadAd(request);
    }
    public void Display_Video() {
        Debug.Log("displaying video");
        if (rewardedAd.IsLoaded()) {
            this.rewardedAd.Show();
        }
    }


    public void HandleUserEarnedReward(object sender, Reward args)
{
    Debug.Log("eeeeeeeeeeeeeeeeeeeeeeeeeeeee");
    string type = args.Type;
    double amount = args.Amount;
    MonoBehaviour.print(
        "HandleRewardedAdRewarded event received for "
                    + amount.ToString() + " " + type);
                    SceneTransition.money += 20;
                    revive.GetComponent<ReviveScreen>().revive();// how to reference another script / object's function
                    GameManager.playedVideoAD = true;

}
public void HandleOnAdLoaded(object sender, EventArgs args)
   {
       Debug.Log("ssssssssssssssssssssssss");
       MonoBehaviour.print("HandleAdLoaded event received");
       Display_Banner();

   }

}

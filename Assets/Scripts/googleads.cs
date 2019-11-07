using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class googleads : MonoBehaviour
{
    private BannerView bannerView;

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        //string appId = "ca-app-pub-2143595815920187~1981355806";

// test
        string appId = "ca-app-pub-2143595815920187~1981355806";

        MobileAds.Initialize(appId);

        this.RequestBanner();
        Display_Banner();
    }
    private void RequestBanner()
    {
        //string adUnitId = "ca-app-pub-2143595815920187~1981355806";


        // test
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";


        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request. for testing
        AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
    public void Display_Banner() {
        this.bannerView.Show();
    }

}

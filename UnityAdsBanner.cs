using GoogleMobileAds.Api;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsBanner : MonoBehaviour
{
    private string placementId = "Banner";
    public BannerView bannerView;
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7926224711582855/6225842863";
    #else
            string adUnitId = "unexpected_platform";
    #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    void Awake()
    {
        StartCoroutine(ShowBannerWhenReady());
    }

    // Update is called once per frame
    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.0f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(placementId);
    }
}

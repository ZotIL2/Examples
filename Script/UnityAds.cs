using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;

public class UnityAds : MonoBehaviour
{
    private string gameid = "3789363";
    private string gameIdG = "ca-app-pub-7926224711582855~5519627244";

    [System.Obsolete]
    void Awake()
    {
        MobileAds.Initialize(gameIdG);
        MobileAds.Initialize(initStatus => { });
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameid, false);
        }
    }
}

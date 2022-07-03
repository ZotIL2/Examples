using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;


public class Buy : MonoBehaviour {

    // public GameObject NewPokypka, Selectbtn,zamok, Ball_standart;
    public string action;

    int mymoney;
    // public Sprite ballmiami;
    public GameObject canva, WatchAd, Phone_sunset, PhoneWinter, zamochickm, zamochickr, zamochickpalr, zamochick3, zamochickClassik, zamochickMaiami, zamochickChina, zamochickClasic, zamochickBallNY, zamochickStickNY, zamochickPhoneS, zamochickPhonetree, zamochickPhoneW, prise, canvavibor, advice;
    public AllShop stickandball;
    public Text money;
    int listball = 0;
    int lball = 0;
    private string adUnitId = "ca-app-pub-7926224711582855/6696977545";//ca-app-pub-3940256099942544/5224354917-testid
    private RewardedAd rewardedAd;
    private GameObject[] Shop;
    private bool flagShop = false;
    public AudioSource PutSound;


    private void Start()
    {
       //PlayerPrefs.SetInt("Money", 10000);
        PlayerPrefs.SetInt("ZamochPhoneWinter", 1);
        //PlayerPrefs.SetInt("ZamochPhonetree", 0);
        //  PlayerPrefs.SetInt("Zamoch1", 0); 
        //  PlayerPrefs.SetInt("Zamoch", 0); 
        //PlayerPrefs.SetInt("ZamochPhonesun", 0);
        //  print("listball=" + listball);
        // print("lball=" + lball);
        this.rewardedAd = new RewardedAd(adUnitId);
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
        if (PlayerPrefs.GetInt("Zamoch") == 1)
        {
            stickandball.ball[0].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickm.SetActive(false);

        }
        if (PlayerPrefs.GetInt("Zamoch1") == 1)
        {
            stickandball.ball[1].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickr.SetActive(false);

        }
        if (PlayerPrefs.GetInt("Zamochpalr") == 1)
        {
            stickandball.sticks[1].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickpalr.SetActive(false);

        }
        if (PlayerPrefs.GetInt("zamochick3") == 1)
        {
            stickandball.ball[2].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochick3.SetActive(false);

        }
        if (PlayerPrefs.GetInt("zamochick2") == 1)
        {
            stickandball.ball[3].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickClassik.SetActive(false);

        }
        if (PlayerPrefs.GetInt("ZamochMai") == 1)
        {
            stickandball.sticks[0].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickMaiami.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ZamochChina") == 1)
        {
            stickandball.sticks[2].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickChina.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ZamochClasic") == 1)
        {
            stickandball.sticks[3].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickClasic.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ZamochPhonesun") == 1)
        {
            stickandball.phone[0].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickPhoneS.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ZamochPhonetree") == 1)
        {
            stickandball.phone[1].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickPhonetree.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ZamochPhoneWinter") == 1)
        {
            stickandball.phone[2].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickPhoneW.SetActive(false);
        }
        if (PlayerPrefs.GetInt("zamochickBallNY") == 1)
        {
            stickandball.ball[4].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickBallNY.SetActive(false);
        }
        if (PlayerPrefs.GetInt("zamochickStickNY") == 1)
        {
            stickandball.sticks[4].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickStickNY.SetActive(false);
        }

    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
      //  MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
      //  MonoBehaviour.print(
       //     "HandleRewardedAdFailedToLoad event received with message: "
         //                    + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
       // MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
       // MonoBehaviour.print(
      //      "HandleRewardedAdFailedToShow event received with message: "
       //                      + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
       // MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        // PlayerPrefs.SetInt("baynum", 8);
        // PlayerPrefs.SetInt("ZamochPhonesun", 0);
        if (PlayerPrefs.GetInt("baynum") == 8)
        {
            stickandball.phone[0].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickPhoneS.SetActive(false);
            Phone_sunset.GetComponent<BoxCollider2D>().enabled = true;
            PlayerPrefs.SetInt("Phoneunlock", 1);
            PlayerPrefs.SetInt("ZamochPhonesun", 1);
        }
        if (PlayerPrefs.GetInt("baynum") == 9)
        {
            Phone_sunset.GetComponent<BoxCollider2D>().enabled = true;
            PlayerPrefs.SetInt("Phoneunlock1", 1);
            stickandball.phone[1].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickPhonetree.SetActive(false);
            PlayerPrefs.SetInt("ZamochPhonetree", 1);
        }
        if (PlayerPrefs.GetInt("baynum") == 10)
        { 
            PhoneWinter.GetComponent<BoxCollider2D>().enabled = true;
            PlayerPrefs.SetInt("Phoneunlock1", 1);
            stickandball.phone[2].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
            zamochickPhoneW.SetActive(false);
            PlayerPrefs.SetInt("ZamochPhoneWinter", 1);
        }


    }
    private void OnMouseDown()
    {
        switch (action)
        {
            case "buyball":
                GetComponent<Transform>().localScale = new Vector3(112, 112, 140f);
                break;
            case "viborball":
                GetComponent<Transform>().localScale = new Vector3(122, 122, 140f);
                break;
        }
    }
    void OnMouseUpAsButton()
    {

        switch (action)
        {
            case "Ball_standart":
                canvavibor.SetActive(true);
                listball = 0;
                PlayerPrefs.SetInt("valu2", listball);
                break;
            case "Phone_standart":
                canvavibor.SetActive(true);
                listball = 0;
                PlayerPrefs.SetInt("phonevalue", listball);
                break;
            case "stick_1_standart":
                canvavibor.SetActive(true);
                listball = 5;
                PlayerPrefs.SetInt("valuestick", listball);
                break;
            case "Phone_sunset":
                if (zamochickPhoneS.activeInHierarchy)
                {
                    WatchAd.SetActive(true);
                    PlayerPrefs.SetInt("baynum", 8);
                    PlayerPrefs.SetInt("prise", 0);
                }
                else
                {
                    WatchAd.SetActive(false);
                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    // PlayerPrefs.SetInt("ZamochPhonesun", 1);
                    listball = 1;
                    PlayerPrefs.SetInt("phonevalue", listball);
                }

                break;
            case "PhoneWinter":
                if (zamochickPhoneW.activeInHierarchy)
                {
                    WatchAd.SetActive(true);
                    PlayerPrefs.SetInt("baynum", 10);
                    PlayerPrefs.SetInt("prise", 0);
                }
                else
                {
                    WatchAd.SetActive(false);
                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    // PlayerPrefs.SetInt("ZamochPhonesun", 1);
                    listball = 3;
                    PlayerPrefs.SetInt("phonevalue", listball);
                }

                break;
            case "Phone_tree":
                if (zamochickPhonetree.activeInHierarchy)
                {

                    WatchAd.SetActive(true);
                    Phone_sunset.GetComponent<BoxCollider2D>().enabled = false;
                    PlayerPrefs.SetInt("baynum", 9);
                    PlayerPrefs.SetInt("prise", 0);
                }
                else
                {
                    Phone_sunset.GetComponent<BoxCollider2D>().enabled = false;
                    WatchAd.SetActive(false);
                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    //  PlayerPrefs.SetInt("ZamochPhonetree", 1);
                    listball = 2;
                    PlayerPrefs.SetInt("phonevalue", listball);
                }

                break;
            case "stick_1_retro":
                PlayerPrefs.SetInt("prise", 500);
                if (zamochickpalr.activeInHierarchy)
                {
                    canva.SetActive(true);
                    PlayerPrefs.SetInt("baynum", 2);
                    prise.GetComponent<Text>().text = PlayerPrefs.GetInt("prise").ToString();
                    PlayerPrefs.SetInt("Zamochpalr", 0);
                }
                else
                {
                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    PlayerPrefs.SetInt("Zamochpalr", 1);
                    listball = 6;
                    PlayerPrefs.SetInt("valuestick", listball);
                }

                break;
            case "stick_1_miami":
                PlayerPrefs.SetInt("prise", 300);
                if (zamochickMaiami.activeInHierarchy)
                {
                    canva.SetActive(true);
                    PlayerPrefs.SetInt("baynum", 5);
                    prise.GetComponent<Text>().text = PlayerPrefs.GetInt("prise").ToString();
                    PlayerPrefs.SetInt("ZamochMai", 0);
                }
                else
                {
                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    PlayerPrefs.SetInt("ZamochMai", 1);
                    listball = 8;
                    PlayerPrefs.SetInt("valuestick", listball);
                }
                break;
            case "stick_1_china":
                PlayerPrefs.SetInt("prise", 750);
                if (zamochickChina.activeInHierarchy)
                {
                    canva.SetActive(true);
                    PlayerPrefs.SetInt("baynum", 6);
                    prise.GetComponent<Text>().text = PlayerPrefs.GetInt("prise").ToString();
                    PlayerPrefs.SetInt("ZamochChina", 0);
                }
                else
                {
                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    PlayerPrefs.SetInt("ZamochChina", 1);
                    listball = 9;
                    PlayerPrefs.SetInt("valuestick", listball);
                }
                break;
            case "stick_1_clasic":
                PlayerPrefs.SetInt("prise", 1000);
                if (zamochickClasic.activeInHierarchy)
                {
                    canva.SetActive(true);
                    PlayerPrefs.SetInt("baynum", 7);
                    prise.GetComponent<Text>().text = PlayerPrefs.GetInt("prise").ToString();
                    PlayerPrefs.SetInt("ZamochClasic", 0);
                }
                else
                {
                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    PlayerPrefs.SetInt("ZamochClasic", 1);
                    listball = 10;
                    PlayerPrefs.SetInt("valuestick", listball);
                }
                break;
            case "stick_2_new_year":
                PlayerPrefs.SetInt("prise", 550);
                if (zamochickStickNY.activeInHierarchy)
                {
                    canva.SetActive(true);
                    PlayerPrefs.SetInt("baynum", 12);
                    prise.GetComponent<Text>().text = PlayerPrefs.GetInt("prise").ToString();
                    PlayerPrefs.SetInt("zamochickStickNY", 0);
                }
                else
                {
                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    PlayerPrefs.SetInt("zamochickStickNY", 1);
                    listball = 11;
                    PlayerPrefs.SetInt("valuestick", listball);
                }
                break;
            case "Ball_miami":
                PlayerPrefs.SetInt("prise", 100);
                if (zamochickm.activeInHierarchy)
                {
                    canva.SetActive(true);
                    PlayerPrefs.SetInt("baynum", 0);
                    prise.GetComponent<Text>().text = PlayerPrefs.GetInt("prise").ToString();
                    PlayerPrefs.SetInt("Zamoch", 0);
                }
                else
                {

                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    PlayerPrefs.SetInt("Zamoch", 1);
                    listball = 1;
                    PlayerPrefs.SetInt("valu2", listball);
                }
                break;
            case "BallNY":
                PlayerPrefs.SetInt("prise", 350);
                if (zamochickBallNY.activeInHierarchy)
                {
                    canva.SetActive(true);
                    PlayerPrefs.SetInt("baynum", 11);
                    prise.GetComponent<Text>().text = PlayerPrefs.GetInt("prise").ToString();
                    PlayerPrefs.SetInt("zamochickBallNY", 0);
                }
                else
                {

                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    PlayerPrefs.SetInt("zamochickBallNY", 1);
                    listball = 8;
                    PlayerPrefs.SetInt("valu2", listball);
                }
                break;
            case "Ball_retro":

                PlayerPrefs.SetInt("prise", 250);
                if (zamochickr.activeInHierarchy)
                {
                    canva.SetActive(true);
                    PlayerPrefs.SetInt("baynum", 1);
                    prise.GetComponent<Text>().text = PlayerPrefs.GetInt("prise").ToString();
                    PlayerPrefs.SetInt("Zamoch1", 0);
                }
                else
                {
                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    PlayerPrefs.SetInt("Zamoch1", 1);
                    listball = 2;
                    PlayerPrefs.SetInt("valu2", listball);
                }

                break;
            case "Ball_china":
                PlayerPrefs.SetInt("prise", 400);
                if (zamochick3.activeInHierarchy)
                {

                    canva.SetActive(true);
                    PlayerPrefs.SetInt("baynum", 3);
                    prise.GetComponent<Text>().text = PlayerPrefs.GetInt("prise").ToString();
                    PlayerPrefs.SetInt("zamochick3", 0);
                }
                else
                {
                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    PlayerPrefs.SetInt("zamochick3", 1);
                    listball = 4;
                    PlayerPrefs.SetInt("valu2", listball);
                }

                break;
            case "Ball_clasic":
                PlayerPrefs.SetInt("prise", 500);
                if (zamochickClassik.activeInHierarchy)
                {

                    canva.SetActive(true);
                    PlayerPrefs.SetInt("baynum", 4);
                    prise.GetComponent<Text>().text = PlayerPrefs.GetInt("prise").ToString();
                    PlayerPrefs.SetInt("zamochick2", 0);
                }
                else
                {
                    canva.SetActive(false);
                    canvavibor.SetActive(true);
                    PlayerPrefs.SetInt("zamochick2", 1);
                    listball = 7;
                    PlayerPrefs.SetInt("valu2", listball);
                }

                break;
            case "buyball":
                GetComponent<Transform>().localScale = new Vector3(120, 120, 140f);
                PutSound.Play();
                mymoney = PlayerPrefs.GetInt("Money");
                if (PlayerPrefs.GetInt("baynum") == 8)
                {
                    if (this.rewardedAd.IsLoaded())
                    {
                        this.rewardedAd.Show();
                        WatchAd.SetActive(false);
                    }
                }
                if (PlayerPrefs.GetInt("baynum") == 9)
                {
                    if (this.rewardedAd.IsLoaded())
                    {
                        this.rewardedAd.Show();
                        WatchAd.SetActive(false);
                    }
                    // for test!!!!!!!!!!
                    /* Phone_sunset.GetComponent<BoxCollider2D>().enabled = true;
                     PlayerPrefs.SetInt("Phoneunlock1", 1);
                     stickandball.phone[1].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                     zamochickPhonetree.SetActive(false);
                     PlayerPrefs.SetInt("ZamochPhonetree", 1);
                     */

                }
                if (PlayerPrefs.GetInt("baynum") == 10)
                {
                    if (this.rewardedAd.IsLoaded())
                   {
                      this.rewardedAd.Show();
                      WatchAd.SetActive(false);
                    }
                  //PhoneWinter.GetComponent<BoxCollider2D>().enabled = true;
                   // PlayerPrefs.SetInt("Phoneunlock1", 1);
                   //stickandball.phone[2].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                   //zamochickPhoneW.SetActive(false);
                 //PlayerPrefs.SetInt("ZamochPhoneWinter", 1);
                }

                    if (PlayerPrefs.GetInt("prise") <= mymoney)
                {
                  //  print("vib");
                   // print(PlayerPrefs.GetInt("prise"));
                    mymoney = mymoney - PlayerPrefs.GetInt("prise");
                    if (PlayerPrefs.GetInt("baynum") == 0)
                    {
                        PlayerPrefs.SetInt("Zamoch", 1);
                        zamochickm.SetActive(false);
                        stickandball.ball[0].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                    }
                    if (PlayerPrefs.GetInt("baynum") == 1)
                    {
                        PlayerPrefs.SetInt("Zamoch1", 1);
                        stickandball.ball[1].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                        zamochickr.SetActive(false);
                    }
                    if (PlayerPrefs.GetInt("baynum") == 2)
                    {
                        PlayerPrefs.SetInt("Zamochpalr", 1);
                        stickandball.sticks[1].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                        zamochickpalr.SetActive(false);
                    }
                    if (PlayerPrefs.GetInt("baynum") == 3)
                    {
                        PlayerPrefs.SetInt("zamochick3", 1);
                        stickandball.ball[2].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                        zamochick3.SetActive(false);
                    }
                    if (PlayerPrefs.GetInt("baynum") == 4)
                    {
                        PlayerPrefs.SetInt("zamochick2", 1);
                        stickandball.ball[3].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                        zamochickClassik.SetActive(false);
                    }
                    if (PlayerPrefs.GetInt("baynum") == 5)
                    {
                        PlayerPrefs.SetInt("ZamochMai", 1);
                        stickandball.sticks[0].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                        zamochickMaiami.SetActive(false);
                    }
                    if (PlayerPrefs.GetInt("baynum") == 6)
                    {
                        PlayerPrefs.SetInt("ZamochChina", 1);
                        stickandball.sticks[2].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                        zamochickChina.SetActive(false);
                    }
                    if (PlayerPrefs.GetInt("baynum") == 7)
                    {
                        PlayerPrefs.SetInt("ZamochClasic", 1);
                        stickandball.sticks[3].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                        zamochickClasic.SetActive(false);
                    }
                    if (PlayerPrefs.GetInt("baynum") == 11)
                    {
                        PlayerPrefs.SetInt("zamochickBallNY", 1);
                        stickandball.ball[4].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                        zamochickBallNY.SetActive(false);
                    }
                    if (PlayerPrefs.GetInt("baynum") == 12)
                    {
                        PlayerPrefs.SetInt("zamochickStickNY", 1);
                        stickandball.sticks[4].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                        zamochickStickNY.SetActive(false);
                    }
                    
                    canva.SetActive(false);
                    PlayerPrefs.SetInt("Money", mymoney);
                   // print("money = " + PlayerPrefs.GetInt("Money"));
                    money.text = PlayerPrefs.GetInt("Money").ToString();
                }
                canva.SetActive(false);
                break;
            case "viborball":
                GetComponent<Transform>().localScale = new Vector3(130, 130, 140f);
                PutSound.Play();
                switch (PlayerPrefs.GetInt("valu2"))
                {
                    case 0:
                        PlayerPrefs.SetInt("ballvalue", 0);
                        break;
                    case 1:
                        PlayerPrefs.SetInt("ballvalue", 1);
                        break;
                    case 2:
                        PlayerPrefs.SetInt("ballvalue", 2);
                        break;
                    case 3:
                        PlayerPrefs.SetInt("ballvalue", 3);
                        break;
                    case 4:
                        PlayerPrefs.SetInt("ballvalue", 4);
                        break;
                    case 7:
                        PlayerPrefs.SetInt("ballvalue", 7);
                        break;
                    case 8:
                        PlayerPrefs.SetInt("ballvalue", 8);
                        break;

                }
                switch (PlayerPrefs.GetInt("valuestick"))
                {
                    case 5:
                        PlayerPrefs.SetInt("stickvalue", 5);
                        break;
                    case 6:
                        PlayerPrefs.SetInt("stickvalue", 6);
                        break;
                    case 8:
                        PlayerPrefs.SetInt("stickvalue", 8);
                        break;
                    case 9:
                        PlayerPrefs.SetInt("stickvalue", 9);
                        break;
                    case 10:
                        PlayerPrefs.SetInt("stickvalue", 10);
                        break;
                    case 11:
                        PlayerPrefs.SetInt("stickvalue", 11);
                        break;
                }
                switch (PlayerPrefs.GetInt("phonevalue")) {
                    case 0:
                        PlayerPrefs.SetInt("valuephone", 0);
                        break;
                    case 1:
                        PlayerPrefs.SetInt("valuephone", 1);
                        break;
                    case 2:
                        PlayerPrefs.SetInt("valuephone", 2);
                        break;
                    case 3:
                        PlayerPrefs.SetInt("valuephone", 3);
                        break;
                }

               // print(PlayerPrefs.GetInt("valu2"));
                canvavibor.SetActive(false);
                break;


        }

    }
    private void Update()
    {
        Shop = GameObject.FindGameObjectsWithTag("Shop");
        if ((canva.activeSelf == true || canvavibor.activeSelf == true || WatchAd.activeSelf == true || advice.activeSelf == true) && flagShop == false)
        {
            flagShop = true;    
            for (int i = 0; i < Shop.Length; i++)
            {
              //  print("yesVipol");
                Shop[i].GetComponent<BoxCollider2D>().enabled = false;
            }
            
        }
        if (canva.activeSelf == false && canvavibor.activeSelf == false && WatchAd.activeSelf == false && advice.activeSelf == false && flagShop == true)
        {
            flagShop = false;
          //  print("noVipolnocikl");
            for (int i = 0; i < Shop.Length; i++)
            {
              //  print("noVipol");
                Shop[i].GetComponent<BoxCollider2D>().enabled = true;
            }
            
        }
    }


}

  
   





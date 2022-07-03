using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Scripting;

public class ContinueGame : MonoBehaviour
{
    public GameObject CanvasAd;
    public Text timeCon;
    public GameObject paus;
    public string Action;
    public GameObject Ball;
    public GameObject Noadsavailable;
    public GameObject[] Sticks;
    public GameObject backGroundMove;
    private string adUnitId = "ca-app-pub-7926224711582855/1851026738";//ca-app-pub-3940256099942544/5224354917
    private RewardedAd rewardedAd;
    public float gameT = 0;
    private int TimerC;
   //public Text Test;
    public GameEff perevorot;
    public GameEffT perevorot1;
    private int interval = 3;
    public AudioSource PutSound;
    AdRequest request;
    // Update is called once per frame
    private void Start()
    {
      //  GarbageCollector.GCMode = GarbageCollector.Mode.Disabled;
        Sticks = GameObject.FindGameObjectsWithTag("Stick");
        this.rewardedAd = new RewardedAd(adUnitId);
        Ball = GameObject.FindGameObjectWithTag("Monay");
        // Called when an ad request has successfully loaded.
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
        request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
        TimerC = 10;   
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
      //  MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        //MonoBehaviour.print(
       //     "HandleRewardedAdFailedToLoad event received with message: "
        //                     + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
      //  MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
       
        switch (Action)
        {
            case "WatchAd":
                SceneManager.LoadScene(1);   
                break;
            case "WatchAdT":
                SceneManager.LoadScene(2);
                break;
            case "WatchAdS":
                SceneManager.LoadScene(3);
                break;
        }
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        //Noadsavailable.SetActive(true);
       // Noadsavailable.GetComponent<Text>().text = "whyyy";

        //    request = new AdRequest.Builder().Build();
        /* switch (Action)
         {
             case "WatchAd":
                 SceneManager.LoadScene(1);
                 break;
             case "WatchAdT":
                 SceneManager.LoadScene(2);
                 break;
             case "WatchAdS":
                 SceneManager.LoadScene(3);
                 break;
         }*/
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
       // request = new AdRequest.Builder().Build();
        switch (Action)
        {
            case "WatchAd":
                //  Noadsavailable.SetActive(true);
                // Noadsavailable.GetComponent<Text>().text = "WatchAD";
                Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                perevorot.dvig = true;
                paus.GetComponent<AnimationStick>().paus = true;
                backGroundMove.GetComponent<BackGroundMove>().enabled = true;
                Ball.GetComponent<RectTransform>().localPosition = new Vector3(-100.6f, -353.4f, -3446);
                if (perevorot.perevor == false)
                {
                    Sticks[1].GetComponent<RectTransform>().localPosition = new Vector3(270f, -700, -3548);
                    Sticks[0].GetComponent<RectTransform>().localPosition = new Vector3(-250f, -700, -3548);
                }else if (perevorot.perevor == true)
                {
                    Sticks[1].GetComponent<RectTransform>().localPosition = new Vector3(270f, 500, -3548);
                    Sticks[0].GetComponent<RectTransform>().localPosition = new Vector3(-250f, 500, -3548);
                }
                Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                TimerC = 10;
                gameT = 0;
                timeCon.text = TimerC.ToString();
                paus.GetComponent<AnimationStick>().PauseAnim.GetComponent<CircleCollider2D>().enabled = true;
                Time.timeScale = 1f;
                CanvasAd.SetActive(false);
               // this.rewardedAd.LoadAd(request);
                break;
            case "WatchAdT":
                Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                perevorot1.dvig = true;
                paus.GetComponent<AnimationStick>().paus = true;
                backGroundMove.GetComponent<BackGroundMoveT>().enabled = true;
                Ball.GetComponent<RectTransform>().localPosition = new Vector3(-112.6f, -353.4f, -3446);
                if (perevorot1.perevor == false)
                {
                    Sticks[1].GetComponent<RectTransform>().localPosition = new Vector3(270f, -700, -3548);
                    Sticks[0].GetComponent<RectTransform>().localPosition = new Vector3(-250f, -700, -3548);
                }
                else if (perevorot1.perevor == true)
                {
                    Sticks[1].GetComponent<RectTransform>().localPosition = new Vector3(270f, 500, -3548);
                    Sticks[0].GetComponent<RectTransform>().localPosition = new Vector3(-250f, 500, -3548);
                }
                Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                TimerC = 10;
                gameT = 0;
                timeCon.text = TimerC.ToString();
                paus.GetComponent<AnimationStick>().PauseAnim.GetComponent<CircleCollider2D>().enabled = true;
                Time.timeScale = 1f;
                CanvasAd.SetActive(false);
            //    this.rewardedAd.LoadAd(request);
                break;
            case "WatchAdS":

                paus.GetComponent<AnimationStick>().paus = true;
               // backGroundMove.GetComponent<MoveBackG>().enabled = true;
                TimerC = 10;
                gameT = 0;
                timeCon.text = TimerC.ToString();
                paus.GetComponent<AnimationStick>().PauseAnim.GetComponent<CircleCollider2D>().enabled = true;
                Time.timeScale = 1f;
                CanvasAd.SetActive(false);
              //  this.rewardedAd.LoadAd(request);
                break;
        }
    }
  /*   void test()
     {
         paus.GetComponent<AnimationStick>().paus = true;
         backGroundMove.GetComponent<BackGroundMove>().enabled = true;
         Ball.GetComponent<RectTransform>().localPosition = new Vector3(-112.6f, -353.4f, -3446);
                         if (perevorot == false)
                 {
                     Sticks[1].GetComponent<RectTransform>().localPosition = new Vector3(270f, -700, -3548);
                     Sticks[0].GetComponent<RectTransform>().localPosition = new Vector3(-250f, -700, -3548);
                 }
                 else if (perevorot == true)
                 {
                     Sticks[1].GetComponent<RectTransform>().localPosition = new Vector3(270f, 500, -3548);
                     Sticks[0].GetComponent<RectTransform>().localPosition = new Vector3(-250f, 500, -3548);
                 }
         Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
         TimerC = 10;
         gameT = 0;
         timeCon.text = TimerC.ToString();
         paus.GetComponent<AnimationStick>().PauseAnim.GetComponent<CircleCollider2D>().enabled = true;
         Time.timeScale = 1f;
         CanvasAd.SetActive(false);
     }*/
    private void OnMouseDown()
    {
        switch (Action)
        {
            case "Skip":
                GetComponent<Transform>().localScale = new Vector3(0.85f, 0.85f, 0.77f);
                break;
            case "SkipT":
                GetComponent<Transform>().localScale = new Vector3(0.85f, 0.85f, 0.77f);
                break;
            case "WatchAd":
                GetComponent<Transform>().localScale = new Vector3(0.85f, 0.85f, 0.77f);
                break;
            case "WatchAdT":
                GetComponent<Transform>().localScale = new Vector3(0.85f, 0.85f, 0.77f);
                break;
            case "SkipS":
             GetComponent<Transform>().localScale = new Vector3(1f, 1f, 0.77f);
                break;
            case "WatchAdS":
                GetComponent<Transform>().localScale = new Vector3(1f, 1f, 0.77f);
                break;
        }
               
        PutSound.Play();
    }
    private void OnMouseUpAsButton()
    {
        switch (Action)
        {
            case "Skip":  
                CanvasAd.SetActive(false);
                GetComponent<Transform>().localScale = new Vector3(1, 1, 0.77f);
                Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                SceneManager.LoadScene(1);
                break;
            case "SkipS":
                CanvasAd.SetActive(false);
                GetComponent<Transform>().localScale = new Vector3(1.2f, 1.2f, 0.77f);
                Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                SceneManager.LoadScene(3);
                break;
            case "SkipT":
                CanvasAd.SetActive(false);
                GetComponent<Transform>().localScale = new Vector3(1, 1, 0.77f);
                Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                SceneManager.LoadScene(2);
                break;
            case "WatchAd":      
                GetComponent<Transform>().localScale = new Vector3(1f, 1f, 0.77f);
                paus.GetComponent<AnimationStick>().PauseAnim.GetComponent<CircleCollider2D>().enabled = true;
                //test();
                if (this.rewardedAd.IsLoaded())
                {
                    this.rewardedAd.Show();
                    Noadsavailable.SetActive(false);
                }
                else
                {
                    Noadsavailable.SetActive(true);
                }
                    break;
            case "WatchAdT":
                GetComponent<Transform>().localScale = new Vector3(1f, 1f, 0.77f);
                paus.GetComponent<AnimationStick>().PauseAnim.GetComponent<CircleCollider2D>().enabled = true;
                //test();
                if (this.rewardedAd.IsLoaded())
                {
                    this.rewardedAd.Show();
                    Noadsavailable.SetActive(false);
                }
                else
                {
                    Noadsavailable.SetActive(true);
                }
                break;
            case "WatchAdS":
                GetComponent<Transform>().localScale = new Vector3(1.2f, 1.2f, 0.77f);
                paus.GetComponent<AnimationStick>().PauseAnim.GetComponent<CircleCollider2D>().enabled = true;
                //test();
                if (this.rewardedAd.IsLoaded())
                {
                    this.rewardedAd.Show();
                    Noadsavailable.SetActive(false);
                }
                else
                {
                    Noadsavailable.SetActive(true);
                }
                break;
        }
    }
    void Update()
    {
            switch (Action)
            {
                case "WatchAd":
                    if (CanvasAd.activeSelf == true)
                    {
                        gameT += 1 * Time.fixedDeltaTime;
                        if (gameT >= 1)
                        {
                            TimerC--;
                            //Test.text = TimerC.ToString();
                            timeCon.text = TimerC.ToString();
                            gameT = 0;
                        }
                        if (TimerC == 0)
                        {
                            CanvasAd.SetActive(false);
                            GetComponent<Transform>().localScale = new Vector3(1, 1, 0.77f);
                            Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                            SceneManager.LoadScene(1);
                        }
                    }
                    break;
                case "WatchAdT":
                    if (CanvasAd.activeSelf == true)
                    {
                        gameT += 1 * Time.fixedDeltaTime;
                        if (gameT >= 1)
                        {
                            TimerC--;
                            //Test.text = TimerC.ToString();
                            timeCon.text = TimerC.ToString();
                            gameT = 0;
                        }
                        if (TimerC == 0)
                        {
                            CanvasAd.SetActive(false);
                            GetComponent<Transform>().localScale = new Vector3(1, 1, 0.77f);
                            Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                            SceneManager.LoadScene(2);
                        }
                    }
                    break;
            case "WatchAdS":
                if (CanvasAd.activeSelf == true)
                {
                    gameT += 1 * Time.fixedDeltaTime;
                    if (gameT >= 1)
                    {
                        TimerC--;
                        //Test.text = TimerC.ToString();
                        timeCon.text = TimerC.ToString();
                        gameT = 0;
                    }
                    if (TimerC == 0)
                    {
                        CanvasAd.SetActive(false);
                        GetComponent<Transform>().localScale = new Vector3(1.2f, 1.2f, 0.77f);
                        SceneManager.LoadScene(3);
                    }
                }
                break;
        }
        }
    }

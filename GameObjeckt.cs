using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Scripting;
using System;

public class GameObjeckt : MonoBehaviour {
    //public GameObject pLost;
    public GameObject score;
    public GameObject scoretxt;
    public GameObject Bestscoretxt;
    public BackGroundMove backGroundMove;
    private float BestScore;
    public string action;
    public GameObject Ground;
    public GameObject paus;
    public GameObject[] ball;
    public GameObject[] stick;
    public GameObject CanvasAd;
    public bool valM;
    public GameEff eff;
    private int interval = 3;
    public Text Test;
    Vector3 predposSt1;
    Vector3 predposSt2;
    int ii = 0;
    // public bool moveM;

    // int i = 0;
    // public static void Collect();
    public void Start()
    {
        GarbageCollector.GCMode = GarbageCollector.Mode.Enabled;
        GC.Collect();
        // Advertisement.Banner.Hide(true);
        // Monetka = GameObject.FindGameObjectWithTag("Money");
        backGroundMove.GetComponent<BackGroundMove>().enabled = true;
        scoretxt.GetComponent<Text>().text = PlayerPrefs.GetFloat("Height").ToString("0");  
            switch (action)
            {
                case "pause":
                
                GameObject.FindGameObjectWithTag("pause").GetComponent<Collider2D>().enabled = false;
                score.SetActive(true);
                paus.GetComponent<AnimationStick>().paus = false;
                stick[0].GetComponent<Gameplay>().enabled = false;
                  stick[1].GetComponent<Gameplay2>().enabled = false;
                  stick[2].GetComponent<Gameplay>().enabled = false;
                  stick[3].GetComponent<Gameplay2>().enabled = false;
                stick[4].GetComponent<Gameplay>().enabled = false;
                stick[5].GetComponent<Gameplay2>().enabled = false;
                Ground.GetComponent<BackGroundMove>().enabled = false;
                Time.timeScale = 0f;
                break;
            }
        if (PlayerPrefs.GetFloat("Height") > PlayerPrefs.GetFloat("BestScore"))
        {
            BestScore = PlayerPrefs.GetFloat("Height");
            PlayerPrefs.SetFloat("BestScore", BestScore);
            Bestscoretxt.GetComponent<Text>().text = PlayerPrefs.GetFloat("BestScore").ToString("0");
        }
        else { Bestscoretxt.GetComponent<Text>().text = PlayerPrefs.GetFloat("BestScore").ToString("0"); }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ii++;
        if (collision.gameObject.tag == "Stick" && stick[0].GetComponent<Rigidbody2D>().velocity != Vector2.zero || collision.gameObject.tag == "Stick" && stick[1].GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        { Test.text = ii.ToString(); print("put"); }
    }
        private void Update()
    {
        if (Advertisement.Banner.isLoaded == true)
        {
            Advertisement.Banner.Hide(true);
        }


        if (Time.frameCount % interval == 0)
        {
            PlayerPrefs.SetFloat("Height", backGroundMove.h);
          
        }
        Vector3 position = transform.position;
        if (position.y < 0)
        {
            CanvasAd.SetActive(true);
            paus.GetComponent<AnimationStick>().PauseAnim.GetComponent<CircleCollider2D>().enabled = false;
            eff.dvig = false;
            valM = false;
            backGroundMove.GetComponent<BackGroundMove>().enabled = false;
            paus.GetComponent<AnimationStick>().paus = false;
            Time.timeScale = 0f;
            // SceneManager.LoadScene(1);
        }
        if (position.y > 10)
        {
            eff.dvig = false;
            CanvasAd.SetActive(true);
            paus.GetComponent<AnimationStick>().PauseAnim.GetComponent<CircleCollider2D>().enabled = false;
            valM = false;
            backGroundMove.GetComponent<BackGroundMove>().enabled = false;
            paus.GetComponent<AnimationStick>().paus = false;
            Time.timeScale = 0f;
            // SceneManager.LoadScene(1);
        }



    }
 
        void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainCamera");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        
    }
}

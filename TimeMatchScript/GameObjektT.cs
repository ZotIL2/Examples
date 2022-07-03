using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class GameObjektT : MonoBehaviour
{
    public GameObject pLost;
    public GameObject cam;
    public GameObject score;
    public GameObject scoretxt;
    public GameObject Bestscoretxt;
    public BackGroundMoveT backGroundMove;
    private float BestScore;
    public string action;
    public GameObject Ground;
    public GameObject paus;
    public GameObject[] ball;
    public GameObject[] stick;
    public GameObject CanvasAd;
    public bool valM;
    public GameEffT eff;
  //  int i = 0;
    private void Start()
    {
        Advertisement.Banner.Hide(true);
        backGroundMove.GetComponent<BackGroundMoveT>().enabled = true;
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
                Ground.GetComponent<BackGroundMoveT>().enabled = false;
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
    private void Update()
    {
        PlayerPrefs.SetFloat("Height", backGroundMove.h);

        Vector3 position = transform.position;
        if (position.y < 0)
        {
            CanvasAd.SetActive(true);
            paus.GetComponent<AnimationStick>().PauseAnim.GetComponent<CircleCollider2D>().enabled = false;
            valM = false;
            eff.dvig = false;
            backGroundMove.GetComponent<BackGroundMoveT>().enabled = false;
            ball[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            ball[1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            ball[2].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            ball[3].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            paus.GetComponent<AnimationStick>().paus = false;
            Time.timeScale = 0f;
        }
        if (position.y > 10)
        {
            CanvasAd.SetActive(true);
            paus.GetComponent<AnimationStick>().PauseAnim.GetComponent<CircleCollider2D>().enabled = false;
            valM = false;
            eff.dvig = false;
            backGroundMove.GetComponent<BackGroundMoveT>().enabled = false;
            ball[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            ball[1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            ball[2].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            ball[3].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            paus.GetComponent<AnimationStick>().paus = false;
            Time.timeScale = 0f;
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

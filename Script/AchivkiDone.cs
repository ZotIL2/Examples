using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AchivkiDone : MonoBehaviour
{
    public BackGroundMove high;
    public GameObject AchivkiCompl;
    public GameObject[] AchText;
    public string Achivki;
    public float time = 30;
    int index;
    private int interval = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Time30") == 0)
        {
            PlayerPrefs.SetInt("TimeGame", Convert.ToInt32(time));
            PlayerPrefs.SetInt("Time30", 5);
        }
        index =  SceneManager.GetActiveScene().buildIndex;
        // PlayerPrefs.SetInt("TimeGame", Convert.ToInt32(time));
        // PlayerPrefs.SetInt("TimeGame", 1);
        // PlayerPrefs.SetFloat("TimeAll", 0);
        //PlayerPrefs.SetInt("AchivkaDone1", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % interval == 0)
        {
            if (index == 1)
            {
                AchivkiCompl.GetComponent<AchivkiDoneT>().enabled = false;
            }
            // 100 heights
            if ((high.h >= 100 && high.h <= 101.1f) && PlayerPrefs.GetInt("AchivkaDone") == 0)
            {
                AchivkiCompl.GetComponent<Animation>().Play("AchvikiCompl");
                PlayerPrefs.SetInt("AchivkaDone", 5);
            }
            // 500 heights
            if ((high.h >= 500 && high.h <= 500.1f) && PlayerPrefs.GetInt("AchivkaDone4") == 0)
            {
                AchivkiCompl.GetComponent<Animation>().Play("AchvikiCompl");
                PlayerPrefs.SetInt("AchivkaDone4", 5);
            }
            // 1000 heights
            if ((high.h >= 1000 && high.h <= 1000.1f) && PlayerPrefs.GetInt("AchivkaDone5") == 0)
            {
                AchivkiCompl.GetComponent<Animation>().Play("AchvikiCompl");
                PlayerPrefs.SetInt("AchivkaDone5", 5);
            }
            // 100 coins
            if (PlayerPrefs.GetInt("Money") == 100 && PlayerPrefs.GetInt("AchivkaDone1") == 0)
            {
                AchivkiCompl.GetComponent<Animation>().Play("AchvikiCompl");
                PlayerPrefs.SetInt("AchivkaDone1", 5);
            }
            // 2500 coins
            if (PlayerPrefs.GetInt("Money") == 2500 && PlayerPrefs.GetInt("AchivkaDone2") == 0)
            {
                AchivkiCompl.GetComponent<Animation>().Play("AchvikiCompl");
                PlayerPrefs.SetInt("AchivkaDone2", 5);
            }
            // 5000 coins
            if (PlayerPrefs.GetInt("Money") == 5000 && PlayerPrefs.GetInt("AchivkaDone3") == 0)
            {
                AchivkiCompl.GetComponent<Animation>().Play("AchvikiCompl");
                PlayerPrefs.SetInt("AchivkaDone3", 5);
            }
            if (PlayerPrefs.GetInt("TimeGame") == 0 && PlayerPrefs.GetInt("AchivkaDone6") == 0)
            {
                AchivkiCompl.GetComponent<Animation>().Play("AchvikiCompl");
                PlayerPrefs.SetInt("AchivkaDone6", 5);
            }
            switch (Achivki)
            {
                case "100heights":
                    if (PlayerPrefs.GetInt("AchivkaDone") == 5)
                    {
                        AchText[0].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                        AchText[1].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                    }
                    break;
                // 500 heights
                case "500heights":
                    if (PlayerPrefs.GetInt("AchivkaDone4") == 5)
                    {
                        AchText[0].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                        AchText[1].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                    }
                    break;
                // 1000 heights
                case "1000heights":
                    if (PlayerPrefs.GetInt("AchivkaDone5") == 5)
                    {
                        AchText[0].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                        AchText[1].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                    }

                    break;
                // 100 coins
                case "100coins":
                    if (PlayerPrefs.GetInt("AchivkaDone1") == 5)
                    {
                        AchText[0].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                        AchText[1].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                    }
                    break;
                // 2500coins
                case "2500coins":
                    if (PlayerPrefs.GetInt("AchivkaDone2") == 5)
                    {
                        AchText[0].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                        AchText[1].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                    }
                    break;
                // 5000coins
                case "5000coins":
                    if (PlayerPrefs.GetInt("AchivkaDone3") == 5)
                    {
                        AchText[0].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                        AchText[1].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                    }
                    break;
                case "timeGame":
                    if (time <= 0)
                    {
                        time = 0;
                    }
                    AchText[1].GetComponent<Text>().text = $"\nPlay for a total of {PlayerPrefs.GetInt("TimeGame")} minutes in mode Time Game";
                    if (PlayerPrefs.GetFloat("TimeAll") >= 0.8)
                    {
                        time = PlayerPrefs.GetInt("TimeGame");
                        // print("vipol");


                        time -= PlayerPrefs.GetFloat("TimeAll");
                        if (time <= 0)
                        {
                            time = 0;
                        }
                        PlayerPrefs.SetInt("TimeGame", Convert.ToInt32(time));

                        PlayerPrefs.SetFloat("TimeAll", 0);

                    }
                    if (PlayerPrefs.GetInt("AchivkaDone6") == 5)
                    {
                        AchText[0].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                        AchText[1].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                    }
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivkiDonePhone : MonoBehaviour
{
    public GameObject AchivkiCompl;
    public GameObject[] AchText;
    public string Achivki;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("ZamochPhonesun") == 1 && PlayerPrefs.GetInt("Phoneunlock")==1)
        {
            AchivkiCompl.GetComponent<Animation>().Play("AchivkaMagaz");
            PlayerPrefs.SetInt("AchivkaDonePhone", 5);
            PlayerPrefs.SetInt("Phoneunlock", 5);
        }
        if (PlayerPrefs.GetInt("ZamochPhonetree") == 1 && PlayerPrefs.GetInt("Phoneunlock1") == 1)
        {
            AchivkiCompl.GetComponent<Animation>().Play("AchivkaMagaz");
            PlayerPrefs.SetInt("Phoneunlock1", 5);
            PlayerPrefs.SetInt("AchivkaDonePhone1", 5);
        }
        switch (Achivki)
        {
            case "WatchAdSunSet":
                if (PlayerPrefs.GetInt("AchivkaDonePhone") == 5)
                {
                    AchText[0].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                    AchText[1].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                }
                break;
            case "WatchAdAutumn":
                if (PlayerPrefs.GetInt("AchivkaDonePhone1") == 5)
                {
                    AchText[0].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                    AchText[1].GetComponent<Text>().color = new Color(255, 255, 255, 230);
                }
                break;
        }
    }
}

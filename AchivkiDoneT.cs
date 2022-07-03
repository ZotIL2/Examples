using UnityEngine;

public class AchivkiDoneT : MonoBehaviour
{
    public BackGroundMoveT high;
    public GameObject AchivkiCompl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 100 heights
        if ((high.h >= 100 && high.h <= 100.1f) && PlayerPrefs.GetInt("AchivkaDone") == 0)
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
    }
}

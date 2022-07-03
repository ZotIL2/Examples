using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text Tim;
    public int timeLeft;
    public float min,gameT;
    private float TimeAll = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetFloat("TimeAll");
        Tim = GetComponent<Text>() as Text;
        min = 1f;
        timeLeft = 59;
        Tim.text = min.ToString("00") + ":" + timeLeft.ToString("00");
        min--;
    }

    // Update is called once per frame
    void Update()
    {
        gameT += 1 * Time.deltaTime;
        if (gameT >= 1)
        {
            timeLeft -= 1;
            PlayerPrefs.SetFloat("TimeAll", (TimeAll += 1)/60);
            gameT = 0;
        }
        if(timeLeft > 60)
        {
            min++;
            timeLeft = timeLeft - 60;
        }
        if(timeLeft == 0 && min >= 1)
        {
            min--;
            timeLeft = 59;
        }
        if (timeLeft == 0 && min == 0)
        {
            SceneManager.LoadScene(2);
        }
        Tim.text = min.ToString("00") + ":" + timeLeft.ToString("00");
    }
}

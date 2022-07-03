using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayPause : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreM;
    [SerializeField]
    private GameObject PaseM;
    [SerializeField]
    private string action;
    [SerializeField]
    private GameObject main, vibor;
    [SerializeField]
    private AudioSource PutSound;
    [SerializeField]
    private GameObject paus;
    [SerializeField]
    private GameObject MAd;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        if (scoreM.activeSelf == true)
        {
            scoreM.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void OnMouseDown()
    {   if (action != "Pause")
        {
            GetComponent<Transform>().localScale = new Vector3(160f, 160f, 0.77f);
            PutSound.Play();
        }
    }
    void OnMouseUpAsButton()
    {
        switch (action)
        {
            case "Play":
                GetComponent<Transform>().localScale = new Vector3(163.8f, 163.8f, 0.77f);
                paus.GetComponent<AnimationStick>().paus = true;
                scoreM.SetActive(false);
                Time.timeScale = 1f;
                break;
            case "Pause":
                if (scoreM.activeSelf == false && MAd.activeSelf == false)
                {
                    paus.GetComponent<AnimationStick>().paus = false;
                    PaseM.SetActive(true);
                    Time.timeScale = 0f;
                }
                break;
            case "PlayAfterPause":
                paus.GetComponent<AnimationStick>().paus = true;
                GetComponent<Transform>().localScale = new Vector3(163.8f, 163.8f, 0.77f);
                PaseM.SetActive(false);
                Time.timeScale = 1f;
                break;
            case "HomeM":
                GetComponent<Transform>().localScale = new Vector3(163.8f, 163.8f, 0.77f);
                main.SetActive(true);
                vibor.SetActive(false);
                SceneManager.LoadScene(0);
                break;
            case "restart":
                GetComponent<Transform>().localScale = new Vector3(163.8f, 163.8f, 0.77f);
                SceneManager.LoadScene(3);
                break;
        }
    }

}

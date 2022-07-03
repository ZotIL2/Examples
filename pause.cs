using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class pause : MonoBehaviour
{

    public Rigidbody2D body;
    public GameObject pLost;
    public GameObject[] ball;
    public GameObject[] stick;
    public GameObject paus;
    public string action;
    public GameEff DropEff;
   // public MoveMoney move;
    public bool val;
    public bool AnimVkl = true;
    public AudioSource PutSound;
    // public GameObject Monetka;
    private void OnMouseDown()
    {
        switch (action)
        {
            case "pyckCon":
                GetComponent<Transform>().localScale = new Vector3(160f, 160f, 0.77f);
                PutSound.Play();
                break;
        }
    }
    public void OnMouseUpAsButton()
    {
        switch (action)
        {
            case "pause":
                DropEff.dvig = false;
                GameObject.FindGameObjectWithTag("pause").GetComponent<Collider2D>().enabled = false;
                val = false;
                paus.GetComponent<AnimationStick>().paus = false;
                GameObject.Find("BackGround").GetComponent<BackGroundMove>().enabled = false;
                stick[0].GetComponent<Gameplay2>().enabled = false;
                stick[1].GetComponent<Gameplay>().enabled = false;
                stick[2].GetComponent<Gameplay2>().enabled = false;
                stick[3].GetComponent<Gameplay>().enabled = false;
                stick[4].GetComponent<Gameplay2>().enabled = false;
                stick[5].GetComponent<Gameplay>().enabled = false;
                pLost.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "pyck":
                PutSound.Play();
                DropEff.dvig = true;
                val = true;
                paus.GetComponent<AnimationStick>().paus = true;
                GameObject.Find("BackGround").GetComponent<BackGroundMove>().enabled = true;
                GameObject.FindGameObjectWithTag("pause").GetComponent<Collider2D>().enabled =  true; 
                stick[0].GetComponent<Gameplay2>().enabled = true;
                 stick[1].GetComponent<Gameplay>().enabled = true;
                 stick[2].GetComponent<Gameplay2>().enabled = true;
                 stick[3].GetComponent<Gameplay>().enabled = true;
                stick[4].GetComponent<Gameplay2>().enabled = true;
                stick[5].GetComponent<Gameplay>().enabled = true;
                pLost.SetActive(false);
                Time.timeScale = 1f;
                break;
            case "pyckCon":
                GetComponent<Transform>().localScale = new Vector3(163.8f, 163.8f, 0.77f);
                //PutSound.Play();
                val = true;
                DropEff.dvig = true;
                paus.GetComponent<AnimationStick>().paus = true;
                GameObject.Find("BackGround").GetComponent<BackGroundMove>().enabled = true;
                GameObject.FindGameObjectWithTag("pause").GetComponent<Collider2D>().enabled = true;
                stick[0].GetComponent<Gameplay2>().enabled = true;
                stick[1].GetComponent<Gameplay>().enabled = true;
                stick[2].GetComponent<Gameplay2>().enabled = true;
                stick[3].GetComponent<Gameplay>().enabled = true;
                stick[4].GetComponent<Gameplay2>().enabled = true;
                stick[5].GetComponent<Gameplay>().enabled = true;
                pLost.SetActive(false);
                Time.timeScale = 1f;
                break;
        }
    }
}
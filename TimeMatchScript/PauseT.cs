using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;


public class PauseT : MonoBehaviour
{
    public Rigidbody2D body;
    public GameObject pLost;
    public GameObject Timer;
    public GameObject[] ball;
    public GameObject[] stick;
    public GameObject paus;
    public GameEffT DropEff;
    public string action;
    // public MoveMoney move;
    public bool val;
    public AudioSource PutSound;
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
    void OnMouseUpAsButton()
    {

        switch (action)
        {        
            case "pause":
                DropEff.dvig = false;
                GameObject.FindGameObjectWithTag("pause").GetComponent<Collider2D>().enabled = false;
                val = false;
                paus.GetComponent<AnimationStick>().paus = false;
                GameObject.Find("BackGround").GetComponent<BackGroundMoveT>().enabled = false;
                stick[0].GetComponent<Gameplay2>().enabled = false;
                stick[1].GetComponent<Gameplay>().enabled = false;
                stick[2].GetComponent<Gameplay2>().enabled = false;
                stick[3].GetComponent<Gameplay>().enabled = false;
                pLost.SetActive(true);
                Time.timeScale = 0f;
                Timer.GetComponent<Timer>().enabled = false;
                break;
            case "pyck":
                DropEff.dvig = true;
                GameObject.Find("BackGround").GetComponent<BackGroundMoveT>().enabled = true;
                val = true;
                GameObject.FindGameObjectWithTag("pause").GetComponent<Collider2D>().enabled = true;
                Timer.GetComponent<Timer>().enabled = true;
                paus.GetComponent<AnimationStick>().paus = true;
                stick[0].GetComponent<Gameplay2>().enabled = true;
                stick[1].GetComponent<Gameplay>().enabled = true;
                stick[2].GetComponent<Gameplay2>().enabled = true;
                stick[3].GetComponent<Gameplay>().enabled = true;
                pLost.SetActive(false);
                Time.timeScale = 1f;
                break;
            case "pyckCon":
                DropEff.dvig = true;
                GetComponent<Transform>().localScale = new Vector3(163.8f, 163.8f, 0.77f);
                GameObject.Find("BackGround").GetComponent<BackGroundMoveT>().enabled = true;
                val = true;
                GameObject.FindGameObjectWithTag("pause").GetComponent<Collider2D>().enabled = true;
                Timer.GetComponent<Timer>().enabled = true;
                paus.GetComponent<AnimationStick>().paus = true;
                stick[0].GetComponent<Gameplay2>().enabled = true;
                stick[1].GetComponent<Gameplay>().enabled = true;
                stick[2].GetComponent<Gameplay2>().enabled = true;
                stick[3].GetComponent<Gameplay>().enabled = true;
                pLost.SetActive(false);
                Time.timeScale = 1f;
                break;
        }
    }

    }


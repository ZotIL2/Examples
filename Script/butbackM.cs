using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class butbackM : MonoBehaviour
{
    public GameObject main, settings;
    public string action;
    public AudioSource PutSound;
    private void OnMouseDown()
    {
        GetComponent<Transform>().localScale = new Vector3(136f, 136f, 0.77f);
        PutSound.Play();
    }
    void OnMouseUpAsButton()
    {
        switch (action)
        {
            case "butback":
                GetComponent<Transform>().localScale = new Vector3(140f, 140f, 0.77f);
                main.SetActive(true);
                settings.SetActive(false);
                break;
        }
    }
}
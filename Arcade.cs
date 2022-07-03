using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System.Collections;
using System;
public class Arcade : MonoBehaviour
{
    public string action;
    public GameObject money;
    public GameObject money1;
    public GameObject Camera;
    public GameObject DropEff;
    public GameObject AchivkaT;
    public AudioSource PutSound;
    public UnityAdsBanner banner;
    // private string gameid = "3789363";
    // public GameObject particalleaf;

    private void OnMouseDown()
    {
        switch (action)
        {
            case "Arcade":
                GetComponent<Transform>().localScale = new Vector3(1.9f, 1.9f, 0.77f);
                PutSound.Play();
                break;
            case "TimeMatch":
                GetComponent<Transform>().localScale = new Vector3(1.9f, 1.9f, 0.77f);
                PutSound.Play();
                break;
            case "ScrollBall":
                GetComponent<Transform>().localScale = new Vector3(1.9f, 1.9f, 0.77f);
                PutSound.Play();
                break;
        }
    }
    void OnMouseUpAsButton()
    {
        switch (action)
        {
            case "Arcade":
                   StartCoroutine(LoadYourAsyncScene());
                //  particalleaf.GetComponent<ParticleSystem>().Pause();
                Advertisement.Banner.Hide(true);
                banner.bannerView.Destroy();
                // Advertisement.Initialize(gameid, false);
                GetComponent<Transform>().localScale = new Vector3(2f, 2f, 0.77f);
                DropEff.GetComponent<GameEff>().enabled = true;
                DropEff.GetComponent<GameEffT>().enabled = false;
                Camera.GetComponent<GameEff>().enabled = true;
                Camera.GetComponent<GameEffT>().enabled = false;
                money.GetComponent<MoveMoneyT>().enabled = false;
                money.GetComponent<MoveMoney>().enabled = true;
                money1.GetComponent<MoveMoneyT>().enabled = false;
                money1.GetComponent<MoveMoney>().enabled = true;
                AchivkaT.GetComponent<AchivkiDoneT>().enabled = false;
                AchivkaT.GetComponent<AchivkiDone>().enabled = true;
                SceneManager.LoadScene(1);
                break;
            case "TimeMatch":
                banner.bannerView.Destroy();
                StartCoroutine(LoadYourAsyncScene());
                //  particalleaf.GetComponent<ParticleSystem>().Pause();
                Advertisement.Banner.Hide(true);
                //Advertisement.Initialize(gameid, false);
                GetComponent<Transform>().localScale = new Vector3(2f, 2f, 0.77f);
                DropEff.GetComponent<GameEff>().enabled = false;
                DropEff.GetComponent<GameEffT>().enabled = true;
                Camera.GetComponent<GameEff>().enabled = false;
                Camera.GetComponent<GameEffT>().enabled = true;
                money.GetComponent<MoveMoney>().enabled = false;
                money.GetComponent<MoveMoneyT>().enabled = true;
                money1.GetComponent<MoveMoneyT>().enabled = true;
                money1.GetComponent<MoveMoney>().enabled = false;
                AchivkaT.GetComponent<AchivkiDoneT>().enabled = true;
                AchivkaT.GetComponent<AchivkiDone>().enabled = false;
                SceneManager.LoadScene(2);
                break;

            case "ScrollBall":
                banner.bannerView.Destroy();
                StartCoroutine(LoadYourAsyncScene());
                Advertisement.Banner.Hide(true);
                GetComponent<Transform>().localScale = new Vector3(2f, 2f, 0.77f);
                SceneManager.LoadScene(3);
                break;
        }
    }
     IEnumerator LoadYourAsyncScene()
       {
           // The Application loads the Scene in the background as the current Scene runs.
           // This is particularly good for creating loading screens.
           // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
           // a sceneBuildIndex of 1 as shown in Build Settings.

           AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Arcade");
           GC.Collect();
           // Wait until the asynchronous scene fully loads
           while (!asyncLoad.isDone)
           {   
               yield return null;
           }
       }
}

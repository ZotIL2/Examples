using UnityEngine;
using UnityEngine.SceneManagement;

public class vibor : MonoBehaviour
{
    public string action;
    public GameObject Active, nextActvive;
    public AudioSource PutSond;
    private void OnMouseDown()
    {
        switch (action)
        {
            case "vibor":
                GetComponent<Transform>().localScale = new Vector3(0.71f, 0.71f, 0.77f);
                PutSond.Play();
                break;
            case "Achivki":
                PutSond.Play();
                GetComponent<Transform>().localScale = new Vector3(0.55f, 0.55f, 0.55f);
                break;
            case "Exit":
                PutSond.Play();
                GetComponent<Transform>().localScale = new Vector3(0.71f, 0.71f, 0.71f);
                break;
        }
       
    }
    void OnMouseUp()
    {
        switch (action)
        {
            case "vibor":
               // PutSond.Stop();
                GetComponent<Transform>().localScale = new Vector3(0.77f, 0.77f, 0.77f);
                Active.SetActive(false);
                nextActvive.SetActive(true);
                break;
            case "Achivki":
              //  PutSond.Stop();
                GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f, 0.6f);
                Active.SetActive(false);
                nextActvive.SetActive(true);
                break;
            case "Exit":
             //   PutSond.Stop();
                GetComponent<Transform>().localScale = new Vector3(0.77f, 0.77f, 0.77f);
                Application.Quit();
                break;
        }
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public GameObject main,vibor;
    public Rigidbody2D body;
    public GameObject pLost;
    public GameObject[] ball;
    public GameObject[] stick;
    public GameObject paus;
    public bool val;
    public string action;
    public AudioSource PutSound;
    private void Start()
    {
       // if () { // написать переменную prefabs для хранения состояния для включения на момент score если просто начало то показывать пока не нажмут) 
          /*  GameObject.Find("BackGround").GetComponent<BackGroundMove>().enabled = true;
            val = true;
            paus.GetComponent<CircleCollider2D>().enabled = true;
            ball[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            ball[1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            ball[2].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            ball[3].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            stick[0].GetComponent<Gameplay>().enabled = true;
            stick[1].GetComponent<Gameplay2>().enabled = true;
            stick[2].GetComponent<Gameplay>().enabled = true;
            stick[3].GetComponent<Gameplay2>().enabled = true;
            pLost.SetActive(false);
       // }*/
    }
    private void OnMouseDown()
    {
        GetComponent<Transform>().localScale = new Vector3(160f, 160f, 0.77f);
        PutSound.Play();
    }
    void OnMouseUpAsButton()
{
    switch (action)
    {
        case "restart":
                GetComponent<Transform>().localScale = new Vector3(163.8f, 163.8f, 0.77f);
                SceneManager.LoadScene(1); 
                break;
            case "restartTime":
                GetComponent<Transform>().localScale = new Vector3(163.8f, 163.8f, 0.77f);
                SceneManager.LoadScene(2);
                break;
            case "home":
                GetComponent<Transform>().localScale = new Vector3(163.8f, 163.8f, 0.77f);
                main.SetActive(true);
                vibor.SetActive(false);
                SceneManager.LoadScene(0);
                break;

        }
}
}
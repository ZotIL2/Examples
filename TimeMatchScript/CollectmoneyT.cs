using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectmoneyT : MonoBehaviour
{
    public Text money;
    public MoveMoney moveMoney;
    bool newmoney = false;
    public GameObject Money;
    public GameObject Effice;
    public GameObject PlusTime;
    public GameObject PlusTime1;
    // public Text PlusTime;
    bool tim = false;
    int sec = 0;
    public float SpeedM;
    public float grasc = 1.0f;
    public BackGroundMoveT high;
    private float i = 100.0f;
    public GameObject ball;
    //  public GameObjeckt ballsprite;

    private void Start()
    {
        SpeedM = 0.01f;
        Instantiate(Money, new Vector3(UnityEngine.Random.Range(28.2f, 32.1f), UnityEngine.Random.Range(4f, 7.3f)), Quaternion.identity);
        ball = GameObject.FindGameObjectWithTag("Monay");
        PlusTime = GameObject.Find("Timer");

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Monay")
        {
            Destroy(other.gameObject);
            newmoney = true;
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
            money.text = PlayerPrefs.GetInt("Money").ToString();
        }
        if (other.tag == "Effectsice")
        {
            tim = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "TimePlus")
        {
            PlusTime.GetComponent<Timer>().timeLeft += 10;
            PlusTime1.GetComponent<Timer>().timeLeft += 10;
            Destroy(other.gameObject);
        }
        if (other.tag == "TimePlus25")
        {
            PlusTime1.GetComponent<Timer>().timeLeft += 25;
            PlusTime.GetComponent<Timer>().timeLeft += 25;
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {

        if (tim == true)
        {
            sec++;
        }
        if (sec < 35 && tim == true)
        {
            ball.GetComponent<Rigidbody2D>().mass = 1.5f;
            ball.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            ball.GetComponent<Rigidbody2D>().drag = 1.2f;
        }
        else
        {
            ball.GetComponent<Rigidbody2D>().mass = 1.0f;
            ball.GetComponent<Rigidbody2D>().gravityScale = grasc;
            ball.GetComponent<Rigidbody2D>().drag = 0;
            tim = false;
            sec = 0;
        }

        if (high.h >= i && high.h <= i + 0.1)
        {
            i += 100.0f;
            Money.GetComponent<MoveMoney>().speedM += 0.01f;
            SpeedM += 0.01f;
            if (grasc < 2)
            {
                grasc += 0.5f;
            }
            ball.GetComponent<Rigidbody2D>().gravityScale = grasc;
            Instantiate(Effice, new Vector3(UnityEngine.Random.Range(28.3f, 32f), UnityEngine.Random.Range(4f, 7f)), Quaternion.identity);
            high.speed += 0.1f;
        }

        // Money.transform.position = new Vector2(transform.position.x, transform.position.y - Convert.ToSingle(0.1));
        if (newmoney == true)
        {
            Instantiate(Money, new Vector3(UnityEngine.Random.Range(28.2f, 32.1f), UnityEngine.Random.Range(4f, 7.3f)), Quaternion.identity);
            newmoney = false;
        }
    }

}

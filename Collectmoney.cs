using UnityEngine.UI;
using UnityEngine;

public class Collectmoney : MonoBehaviour
{
    public Text money;
    public MoveMoney moveMoney;
    bool newmoney = false;
    public GameObject Money;
    public GameObject Effice;
  // public Text PlusTime;
    bool tim = false;
    int sec = 0;
    public float SpeedM;
    public float grasc = 2.0f;
    public BackGroundMove high;
    private float i = 100.0f;
     public GameObject ball;
    //  public GameObjeckt ballsprite;

    private void Start()
    {
        //PlayerPrefs.SetInt("Money", 98);
        SpeedM = 0.01f;
        Instantiate(Money, new Vector3(UnityEngine.Random.Range(28.2f, 32.1f), UnityEngine.Random.Range(4f, 7.3f),45f), Quaternion.identity);
        //    print("start");
    //    Money.GetComponent<Animation>().Play("Money");
        ball = GameObject.FindGameObjectWithTag("Monay");

    }
    void OnTriggerEnter2D(Collider2D other){
     
        if (other.tag == "Monay") {
            print("OneMon");
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
    }
    private void Update()
    {
      
        if (tim == true)
        {
            sec++;
        }
        if (sec < 35 && tim == true)
        {
            ball.GetComponent<Rigidbody2D>().mass = 10.0f;
            ball.GetComponent<Rigidbody2D>().gravityScale = 0.7f;
            ball.GetComponent<Rigidbody2D>().drag = 1.5f;
        }
        else
        {
            ball.GetComponent<Rigidbody2D>().mass = 10.0f;
            ball.GetComponent<Rigidbody2D>().gravityScale = grasc;
            ball.GetComponent<Rigidbody2D>().angularDrag = 0.3f;
            ball.GetComponent<Rigidbody2D>().drag = 0.5f;
            tim = false;
            sec = 0;
        }

        //print(i);
       if (high.h >= i && high.h <= i + 0.1)
       { 
           // print("Generation");
            i += 100.0f;
            Money.GetComponent<MoveMoney>().speedM += 0.01f;
             SpeedM += 0.01f;
            if (grasc < 3)
           {
               grasc += 0.5f;
           }
           ball.GetComponent<Rigidbody2D>().gravityScale = grasc;
          Instantiate(Effice, new Vector3(UnityEngine.Random.Range(28.3f, 32f), UnityEngine.Random.Range(4f, 7f)), Quaternion.identity);
           high.speed += 0.1f;
        }

        // Money.transform.position = new Vector2(transform.position.x, transform.position.y - Convert.ToSingle(0.1));
        if (newmoney == true) {
           // print("eeboy");
            Instantiate(Money, new Vector3(UnityEngine.Random.Range(28.2f, 32.1f), UnityEngine.Random.Range(4f, 7.3f)), Quaternion.identity);
            newmoney = false;
           // print("pocle="+ newmoney);
        }
    }


}

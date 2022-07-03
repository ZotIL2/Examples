using UnityEngine.UI;
using UnityEngine;

public class CollectMoneyS : MonoBehaviour
{
    public Text money;
    bool newmoney = false;
    public GameObject Money;
    public GameObject Effice;
    // public Text PlusTime;
    bool tim = false;
    int sec = 0;
    public float SpeedM;
    public float grasc = 2.0f;
    public MoveBackG high;
    private float i = 100.0f;
    public GameObject ball;

    //  public GameObjeckt ballsprite;

    private void Start()
    {
        //PlayerPrefs.SetInt("Money", 98);
        SpeedM = 0.01f;
        Money.transform.position = new Vector3(UnityEngine.Random.Range(28.2f, 32.1f), UnityEngine.Random.Range(4f, 7.3f), 45f);
        //    print("start");
        //    Money.GetComponent<Animation>().Play("Money");
        ball = GameObject.FindGameObjectWithTag("Monay");

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Money")
        {
            print("OneMon");
            Money.transform.position = new Vector3(UnityEngine.Random.Range(28.2f, 32.1f), UnityEngine.Random.Range(4f, 7.3f), 45f);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
            money.text = PlayerPrefs.GetInt("Money").ToString();
        }
    }
    private void Update()
    {

        //print(i);
        if (high.h >= i && high.h <= i + 0.1)
        {
            // print("Generation");
            i += 100.0f;
            Money.GetComponent<MoveMoneyS>().speedM += 0.01f;
            SpeedM += 0.01f;
          //  high.speed -= 0.01f;!!!!!!!!!!!!!!!!!!!!!!
            high.speed += 0.1f;
        }

        // Money.transform.position = new Vector2(transform.position.x, transform.position.y - Convert.ToSingle(0.1));
    /*    if (newmoney == true)
        {
            // print("eeboy");
            Instantiate(Money, new Vector3(UnityEngine.Random.Range(28.2f, 32.1f), UnityEngine.Random.Range(4f, 7.3f)), Quaternion.identity);
            newmoney = false;
            // print("pocle="+ newmoney);
        }*/
    }


}


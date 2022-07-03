using UnityEngine;
public class MoveMoney : MonoBehaviour
{
    public GameObject Money;
    public PauseT p;
    public bool val;
    public  float speedM;
    //GameObject EffDrop;
    public bool Eff = false;
    public GameObject CanvasAd;
    private int interval = 5;
    //public GameObjeckt val;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        CanvasAd = GameObject.FindGameObjectWithTag("CanvasAd");
    }
    void Update()
    {
        if (Time.frameCount % interval == 0)
        {
            Eff = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameEff>().Eff;
            CanvasAd = GameObject.FindGameObjectWithTag("CanvasAd");
        }
            //print(Eff);

        if (GameObject.Find("pyck") == null && CanvasAd == null)
        {
            val = true;
        }
        else
        {
           // val = GameObject.Find("pyck").GetComponent<pause>().val;
            val = GameObject.Find("pausePol").GetComponent<pause>().val;
            val = GameObject.FindGameObjectWithTag("Monay").GetComponent<GameObjeckt>().valM;
        }
       
        //if(val.moveM == true)
        //{
        //   Money.GetComponent<Collider2D>().enabled = true;
        // }
        //else
        // {
        //  Money.GetComponent<Collider2D>().enabled =  false;
        //}
       // print("EFF:"+Eff);
       if(val == true && gameObject.tag == "Monay")
        {
            Money.GetComponent<Animation>().Play("Money");
        }else if (val == false && gameObject.tag == "Monay")
        {
            Money.GetComponent<Animation>().Stop("Money");
        }
        if (val == true && Eff == true) {
            Money.transform.position = new Vector2(transform.position.x, transform.position.y + GameObject.FindGameObjectWithTag("Monay").GetComponent<Collectmoney>().SpeedM); 
            if (Money.transform.position.y > 10 && gameObject.tag == "Monay") {
                Instantiate(Money, new Vector3(UnityEngine.Random.Range(28.2f, 32.1f), UnityEngine.Random.Range(2f, 6f),45), Quaternion.identity); 
                Destroy(Money.gameObject); 
            }else if (Money.transform.position.y > 10 && gameObject.tag == "Effectsice") { Destroy(Money.gameObject); }
        }
        if (val == false && Eff == false) {
           
            Money.transform.position = new Vector3(transform.position.x, transform.position.y, 45f);
        }
        else if(val == true && Eff == false) { Money.transform.position = new Vector3(transform.position.x, transform.position.y - GameObject.FindGameObjectWithTag("Monay").GetComponent<Collectmoney>().SpeedM,45f); }
      
        if (Money.transform.position.y < 0 && gameObject.tag == "Monay" && Eff == false)
        {
            Instantiate(Money, new Vector3(UnityEngine.Random.Range(28.2f, 32.1f), UnityEngine.Random.Range(4f, 7.3f), 45), Quaternion.identity);
            Destroy(Money.gameObject);
        }else if(Money.transform.position.y < 0 && gameObject.tag == "Effectsice" && Eff == false) {Destroy(Money.gameObject);}

    }
}

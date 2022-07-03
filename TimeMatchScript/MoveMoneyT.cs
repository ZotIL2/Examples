using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMoneyT : MonoBehaviour
{
    public GameObject Money;
    public PauseT p;
    public bool val;
    public float speedM;
    //GameObject EffDrop;
    public GameObject CanvasAd;
    public bool Eff = false;
    private void Start()
    {
        CanvasAd = GameObject.FindGameObjectWithTag("CanvasAd");
    }
    void Update()
    {
        CanvasAd = GameObject.FindGameObjectWithTag("CanvasAd");
        Eff = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameEffT>().Eff;
        //print(Eff);

        if (GameObject.Find("pyck")== null && CanvasAd == null)
        {
            val = true;
        }
        else
        {
            val = GameObject.Find("pyck").GetComponent<PauseT>().val;
            val = GameObject.Find("pausePol").GetComponent<PauseT>().val;
            val = GameObject.FindGameObjectWithTag("Monay").GetComponent<GameObjektT>().valM;
        }
        if (val == true && gameObject.tag == "Monay")
        {
            Money.GetComponent<Animation>().Play("Money");
        }
        else if (val == false && gameObject.tag == "Monay")
        {
            Money.GetComponent<Animation>().Stop("Money");
        }
       
        if (val == true && Eff == true)
        {
            Money.transform.position = new Vector2(transform.position.x, transform.position.y + GameObject.FindGameObjectWithTag("Monay").GetComponent<CollectmoneyT>().SpeedM);
            if (Money.transform.position.y > 10 && gameObject.tag == "Monay")
            {
                Instantiate(Money, new Vector3(UnityEngine.Random.Range(28.2f, 32.1f), UnityEngine.Random.Range(2f, 6f), 45), Quaternion.identity);
                Destroy(Money.gameObject);
            }
            else if (Money.transform.position.y > 10 && gameObject.tag == "Effectsice") { Destroy(Money.gameObject); }
        }

        if (val == false && Eff == false)
        {
            Money.transform.position = new Vector3(transform.position.x, transform.position.y, 45f);
        }
        else if (val == true && Eff == false) { Money.transform.position = new Vector3(transform.position.x, transform.position.y - GameObject.FindGameObjectWithTag("Monay").GetComponent<CollectmoneyT>().SpeedM, 45f); }

        if (Money.transform.position.y < 0 && gameObject.tag == "Monay" && Eff == false)
        {
            Instantiate(Money, new Vector3(UnityEngine.Random.Range(28.2f, 32.1f), UnityEngine.Random.Range(4f, 7.3f), 45), Quaternion.identity);
            Destroy(Money.gameObject);
        }
        else if (Money.transform.position.y < 0 && gameObject.tag == "Effectsice" && Eff == false) { Destroy(Money.gameObject); }

    }
}

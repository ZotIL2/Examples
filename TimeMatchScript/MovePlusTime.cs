using UnityEngine;

public class MovePlusTime : MonoBehaviour
{
    public GameObject PlusTime;
    public bool val;
    public bool Eff = false;
    public GameObject CanvasAd;
    private void Start()
    {
        CanvasAd = GameObject.FindGameObjectWithTag("CanvasAd");
    }
    void Update()
    {
        Eff = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameEffT>().Eff;
        CanvasAd = GameObject.FindGameObjectWithTag("CanvasAd");
        if (GameObject.Find("pyck") == null && CanvasAd == null)
        {
            val = true;
        }
        else
        {
            val = GameObject.Find("pyck").GetComponent<PauseT>().val;
            val = GameObject.Find("pause").GetComponent<PauseT>().val;
            val = GameObject.FindGameObjectWithTag("Monay").GetComponent<GameObjektT>().valM;
        }
        if (val == true && Eff == true)
        {
            PlusTime.transform.position = new Vector2(transform.position.x, transform.position.y + GameObject.FindGameObjectWithTag("Monay").GetComponent<CollectmoneyT>().SpeedM);
            if (PlusTime.transform.position.y > 10)
            {
                Destroy(PlusTime.gameObject);
            }
        }

        if (val == false && Eff == false)
        {
            PlusTime.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        else if (val == true && Eff == false) { PlusTime.transform.position = new Vector2(transform.position.x, transform.position.y - GameObject.FindGameObjectWithTag("Monay").GetComponent<CollectmoneyT>().SpeedM); }

        if (PlusTime.transform.position.y < 0 && Eff == false)
        {
            Destroy(PlusTime.gameObject);
        }

    }
}

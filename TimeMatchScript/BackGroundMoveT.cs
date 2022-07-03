using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackGroundMoveT : MonoBehaviour
{
    public GameObject txt;
    //public GameObject ball;
    //  public Collectmoney bal;
    public float speed = 0;
    public float h = 0;
    public float visot;
    //float grasc = 1.0f;
    //float i = 100.0f;
    public GameObject Obloka;
    private Vector2 offset = Vector2.zero;
    bool Eff;
    // Start is called before the first frame update
    void Start()
    {    
        txt.GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        Eff = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameEffT>().Eff;
        if (Eff == false)
        {
            Obloka.transform.position = new Vector3(transform.position.x, transform.position.y - GameObject.FindGameObjectWithTag("Monay").GetComponent<CollectmoneyT>().SpeedM, 69.5f);
        }
        else if (Eff == true) { Obloka.transform.position = new Vector3(transform.position.x, transform.position.y + GameObject.FindGameObjectWithTag("Monay").GetComponent<CollectmoneyT>().SpeedM, 69.5f); }
        offset.y += speed * Time.deltaTime;
        h += visot;
        
        txt.GetComponent<Text>().text = h.ToString("0");
        if (Obloka.transform.position.y < -1.3f)
        {
            Obloka.transform.position = new Vector3(UnityEngine.Random.Range(28f, 31.5f), 11.3f, 65.5f);
        }
        if (Obloka.transform.position.y > 11.5f && Eff == true)
        {
            Obloka.transform.position = new Vector3(UnityEngine.Random.Range(28f, 31.5f), -1f, 65.5f);
        }
    }
}

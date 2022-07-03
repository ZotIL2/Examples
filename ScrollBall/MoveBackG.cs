using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBackG : MonoBehaviour
{
    public GameObject Obloka;
    public GameObject txt;
    public float visot;
    public float h = 0;
    public float speed = 0;
    [SerializeField]
    private GameObject scoreM;
    [SerializeField]
    private GameObject PauseM;
    [SerializeField]
    private GameObject MAd;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreM.activeSelf == false && PauseM.activeSelf == false && MAd.activeSelf == false)
        {
            Obloka.transform.position = new Vector3(transform.position.x, transform.position.y - GameObject.FindGameObjectWithTag("Monay").GetComponent<CollectMoneyS>().SpeedM, 69.5f);
           
            //print(h);
            txt.GetComponent<Text>().text = h.ToString("0");
            if (Obloka.transform.position.y < -1.3f)
            {
                Obloka.transform.position = new Vector3(UnityEngine.Random.Range(28f, 31.5f), 11.3f, 65.5f);
            }
            h += visot;
        }
    }
}

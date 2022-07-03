using UnityEngine;
public class MoveMoneyS : MonoBehaviour
{
    public GameObject Money;
    public float speedM;
    [SerializeField]
    private GameObject scoreM;
    [SerializeField]
    private GameObject PauseM;
    [SerializeField]
    private GameObject MAd;
    private void Start()
    {
        scoreM = GameObject.FindGameObjectWithTag("Score");
    }
    void Update()
    {
      
        if (scoreM.activeSelf == false && PauseM.activeSelf == false && MAd.activeSelf == false) {
            Debug.Log("Tesstt");
            Money.transform.position = new Vector3(transform.position.x, transform.position.y - GameObject.FindGameObjectWithTag("Monay").GetComponent<CollectMoneyS>().SpeedM, 45f);
        }
        if (scoreM.activeSelf == false && PauseM.activeSelf == false && gameObject.tag == "Money")
        {
            Money.GetComponent<Animation>().Play("Money");
        }
        else if (scoreM.activeSelf == true || PauseM.activeSelf == true || MAd.activeSelf == true && gameObject.tag == "Money")
        {
            Money.GetComponent<Animation>().Stop("Money");
        }
        if (Money.transform.position.y < 0 && gameObject.tag == "Money")
        {
            Money.transform.position = new Vector3(UnityEngine.Random.Range(28.2f, 32.1f), UnityEngine.Random.Range(4f, 7.3f), 45);
          //  Destroy(Money.gameObject);
        }

    }
}


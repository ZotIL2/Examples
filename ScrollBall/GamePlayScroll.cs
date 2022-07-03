using UnityEngine;
using UnityEngine.EventSystems;

public class GamePlayScroll : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public GameObject Ball;
    bool center = true;
    bool right = false;
    bool left = false;
    bool stateher = false;
    [SerializeField]
    private float speed = 0.5f;
    int countM = 0;
    [SerializeField]
    private GameObject scoreM;
    [SerializeField]
    private GameObject PauseM;
    [SerializeField]
    private GameObject MAd;
    void Start()
    {
        Ball = GameObject.FindGameObjectWithTag("Monay");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
      //  Ball = GameObject.FindGameObjectWithTag("Monay");
        if (scoreM.activeSelf == false && PauseM.activeSelf == false && MAd.activeSelf == false)
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                if (eventData.delta.x > 0 && center == true && stateher == false)
                {
                    stateher = true;
                    Ball.GetComponent<Animation>().Play("ScrollRight");
                    //Ball.GetComponent<Rigidbody2D>().position = new Vector2(31.8f, 2.2f);
                    center = false;
                    right = true;
                    // right
                }
                else if (eventData.delta.x < 0 && right == true && center == false)
                {
                    stateher = false;
                    Ball.GetComponent<Animation>().Play("ScrollBackR");
                    //Ball.GetComponent<Rigidbody2D>().position = new Vector2(30.1f, 2.2f);
                    center = true;
                    right = false;
                }
                else if (eventData.delta.x > 0 && left == true && center == false)
                {
                    stateher = false;
                    Ball.GetComponent<Animation>().Play("ScrollBackL");
                    //  Ball.GetComponent<Rigidbody2D>().position = new Vector2(30.1f, 2.2f);
                    center = true;
                    left = false;
                }
                else if (eventData.delta.x < 0 && center == true && stateher == false)
                {
                    stateher = true;
                    Ball.GetComponent<Animation>().Play("ScrollLeft");
                    // Ball.GetComponent<Rigidbody2D>().position = new Vector2(28.2f, 2.2f);
                    center = false;
                    left = true;
                    center = false;
                    //left
                }
            }
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
     
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class testGameplay : MonoBehaviour
{
    private Vector3 touchPosition;
    public Camera cam;
    public Boundary boundary;
    private Rigidbody2D rb;
    private Vector3 direction;
    public float moveSpeed = 5;
    private Vector2 smoothdirection;
    public float smooth;

    // Use this for initialization
    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("TouchHHHHHH1");
            Touch touch = Input.GetTouch(1);
            touchPosition = cam.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
          
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
            GetComponent<Rigidbody2D>().position = new Vector2(
           Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
           Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
           );
            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("UNNTouch2");
                rb.velocity = Vector2.zero;
            }
        }
    }
}
/*[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;

}


public class testGameplay : MonoBehaviour
{
    public float speed = 10;
    public Boundary boundary;
    private touchpad2 touchpad2;

    Vector2 posit;
    private void Awake()
    {
        posit = Vector2.zero;
    }
    public void FixedUpdate()
    {
        Vector2 posit = touchpad2.GetDirection();
        //posit = posit.normalized;
        // float moveH = Input.GetAxis("Horizontal");
        //float moveV = Input.GetAxis("Vertical");
      GetComponent<Rigidbody2D>().velocity = new Vector2(posit.x, posit.y) * speed; 
        GetComponent<Rigidbody2D>().position = new Vector2(
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
            );

    }
}
*/
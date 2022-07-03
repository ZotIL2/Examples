using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;

}
public class testGameplay1 : MonoBehaviour
{
    private Vector3 touchPosition;
    public Boundary boundary;
    public Camera cam;
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

            Debug.Log("TouchHHHHHH");
            Touch touch = Input.GetTouch(0);
            touchPosition = cam.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            Debug.Log(touchPosition);
            direction = (touchPosition - transform.position);
            Debug.Log("DIR:"+direction);
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
            GetComponent<Rigidbody2D>().position = new Vector2(
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
            );
            if (touch.phase == TouchPhase.Ended) { 
                Debug.Log("UNNTouch");
            rb.velocity = Vector2.zero;
        }
        }
    }
}
    /*public float speed = 5;
    public Boundary boundary;
    Vector2 posit1;
    public touchpad touchpad;
    
    public void FixedUpdate()
    {
       
        Vector2 posit1 = touchpad.GetDirection();
       // posit1 = posit1.normalized;
        // float moveH = Input.GetAxis("Horizontal");
        //float moveV = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(posit1.x, posit1.y) * speed; 
        GetComponent<Rigidbody2D>().position = new Vector2(
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
            );

    }*/

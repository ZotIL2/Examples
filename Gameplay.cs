using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public float speed;
    public Boundary boundary;
    Vector2 position;
    Vector2 positionbetthestiks;
    public Rigidbody2D Rg;
    public bool vkl = false;
    public GameObject stickR;
    private Vector2 move;
    private Vector2 bordervector;
    float dist;

    private void Start()
    {
        speed = PlayerPrefs.GetFloat("SpeedPalka");
    }
    public void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x >= 15 && touch.position.x <= (Screen.width / 2) - 30 && touch.position.y <= Screen.height / 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    dist = Vector3.Distance(stickR.transform.position, transform.position);
                    position.y = Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax);
                    position.x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax);
                    //positionbetthestiks.y = Mathf.Clamp(transform.position.y, dist,0.25f);
                    positionbetthestiks.x = Mathf.Clamp(dist, 1.9f, 5f);
                    bordervector = new Vector2(position.x, position.y);
                    // Get movement of the finger since last frame
                    Vector2 posit = Input.GetTouch(0).deltaPosition;
                    //  print(dist);
                    //  print("DistMin: " + positionbetthestiks.x);
                    // print("x: " + transform.position.x);


                    move = new Vector2(posit.x, posit.y);
                    // posits = new Vector2(transform.position.x, transform.position.y);
                    Rg.MovePosition((Vector2)transform.position + move * speed);
                    if (dist <= 2f)
                    {
                        position.x = transform.position.x;
                        //  print("yesss");
                        // print("pos:" + position.x);
                        if (move.x > 0)
                        {
                            move.x = 0;
                        }
                        if (move.y < 0)
                        {

                            move.y = 0;
                        }
                        Rg.MovePosition(new Vector2(position.x, transform.position.y) + move * speed);
                    }
                    if (transform.position.x >= boundary.xMax || transform.position.x <= boundary.xMin)
                    {
                        //Rg.MovePosition(new Vector2(transform.position.x, transform.position.y));
                        Rg.MovePosition((Vector2)bordervector + move * speed);
                    }
                    if (transform.position.y >= boundary.xMax || transform.position.y <= boundary.xMin)
                    {
                        //Rg.MovePosition(new Vector2(transform.position.x, transform.position.y));
                        Rg.MovePosition((Vector2)bordervector + move * speed);
                    }
                }

            }
            else if (Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                dist = Vector3.Distance(stickR.transform.position, transform.position);
                position.y = Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax);
                position.x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax);
                //positionbetthestiks.y = Mathf.Clamp(transform.position.y, dist,0.25f);
                positionbetthestiks.x = Mathf.Clamp(dist, 1.9f, 5f);
                bordervector = new Vector2(position.x, position.y);
                // Get movement of the finger since last frame
                Vector2 posit = Input.GetTouch(1).deltaPosition;
                //  print(dist);
                // print("DistMin: " + positionbetthestiks.x);
                //print("x: " + transform.position.x);


                move = new Vector2(posit.x, posit.y);
                // posits = new Vector2(transform.position.x, transform.position.y);
                Rg.MovePosition((Vector2)transform.position + move * speed);
                if (dist <= 2f)
                {
                    position.x = transform.position.x;
                    print("yesss");
                    print("pos:" + position.x);
                    if (move.x > 0)
                    {
                        move.x = 0;
                    }
                    if (move.y < 0)
                    {

                        move.y = 0;
                    }
                    Rg.MovePosition(new Vector2(position.x, transform.position.y) + move * speed);
                }
                if (transform.position.x >= boundary.xMax || transform.position.x <= boundary.xMin)
                {
                    //Rg.MovePosition(new Vector2(transform.position.x, transform.position.y));
                    Rg.MovePosition((Vector2)bordervector + move * speed);
                }
                if (transform.position.y >= boundary.xMax || transform.position.y <= boundary.xMin)
                {
                    //Rg.MovePosition(new Vector2(transform.position.x, transform.position.y));
                    Rg.MovePosition((Vector2)bordervector + move * speed);
                }
            }

        }

        // if (Input.touchCount > 0)
        //{ }
        //else { move = new Vector2(0, 0); print("otgal"); }
        // Track a single touch as a direction control.
        // if (Input.touchCount > 0)
        // {\
        //   if (vkl == true)
        //  {
        /*Touch touch = Input.GetTouch(0);

            // print("var" + touch.position.x);
            if (touch.position.x >= 15 && touch.position.x <= (Screen.width / 2) - 30 && touch.position.y <= Screen.height / 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                // Get movement of the finger since last frame
                 Vector2 posit = Input.GetTouch(0).deltaPosition;

                 position.y = boundary.yMin;
                 position.x = boundary.xMin;
                 position.y = Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax);
                 position.x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax);
                // transform.Translate(posit.x * speed, posit.y * speed, 0);
                print(posit);

                print(transform.position.x - stickR.transform.position.x);
                if ((stickR.transform.position.x - transform.position.x) < -2f) {
                    print("Daaaaaaa");
                    Rg.MovePosition(new Vector2(transform.position.x, transform.position.y));
                }

                 /*   if (transform.position.x >= boundary.xMax || transform.position.x <= boundary.xMin)
                    {
                    //   transform.Translate(posit.x * speed, posit.y * speed, 0);
                      Rg.MovePosition(new Vector2(position.x - 0.01f, position.y - 0.01f));

                    }
                    if (transform.position.y >= boundary.yMax || transform.position.y <= boundary.yMin)
                    {
                    //transform.Translate(posit.x * speed, posit.y * speed, 0);
                    Rg.MovePosition(new Vector2(position.x + 0.01f, position.y + 0.01f));
                }

                }
            }
            else
            {
                if (Input.GetTouch(1).phase == TouchPhase.Moved)
                {
                // Get movement of the finger since last frame
                Vector2 posit = Input.GetTouch(1).deltaPosition;
                position.y = boundary.yMin;
                position.x = boundary.xMin;
                position.y = Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax);
                position.x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax);
                // transform.Translate(posit.x * speed, posit.y * speed, 0);
                print(posit);
                Rg.MovePosition(new Vector2(transform.position.x + posit.x * speed, transform.position.y + posit.y * speed));
                if (transform.position.x >= boundary.xMax || transform.position.x <= boundary.xMin)
                {
                    //   transform.Translate(posit.x * speed, posit.y * speed, 0);
                    Rg.MovePosition(new Vector2(position.x - 0.01f, position.y - 0.01f));

                }
                if (transform.position.y >= boundary.yMax || transform.position.y <= boundary.yMin)
                {
                    //transform.Translate(posit.x * speed, posit.y * speed, 0);
                    Rg.MovePosition(new Vector2(position.x + 0.01f, position.y + 0.01f));
                }


            }
        }
        }
   */
    }
}
//}
// Touch touch = Input.GetTouch(1);
/*  public void BeginDrag()
  {
     // OffsetX = (transform.position.x + Input.mousePosition.x);
    //  OffsetY = (transform.position.y + Input.mousePosition.y);

  }*/
// public void Update()
// {
/* if (Input.mousePosition.x > 500 && Input.mousePosition.y > 150)
 {
     transform.position = new Vector3(0, 175);
     print("YES");

 }*/
//   if (touch.phase == TouchPhase.Moved)
//   {
//        print("X = " + touch.position.x);
//        print("Y = " + touch.position.y);
//        transform.position = new Vector3(touch.position.x, touch.position.x) * speed;
//    }
// }

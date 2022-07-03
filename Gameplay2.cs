using UnityEngine;
public class Gameplay2 : MonoBehaviour
{
    // float OffsetX;
    //   float OffsetY;
    public float speed;
    public Boundary boundary;
    public Rigidbody2D Rg;
    Vector2 position;
    public bool vkl = false;
    private Vector2 move;
    private Vector2 bordervector;
    Vector2 positionbetthestiks;
    float dist;
    public GameObject[] stickL;
    public static bool movest = false;
    void Start()
    {
        speed = PlayerPrefs.GetFloat("SpeedPalka");
       // Debug.Log("Screen Width : " + Screen.width);
       // Debug.Log("Screen height : " + Screen.height);
    }
  
    public void FixedUpdate()
    {
        movest = false;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            speed = PlayerPrefs.GetFloat("SpeedPalka");
            if (touch.position.x >= (Screen.width / 2) + 30 && touch.position.x <= Screen.width && touch.position.y <= Screen.height-50)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    movest = true;
                    dist = Vector3.Distance(stickL[1].transform.position, transform.position);
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
                    if (dist <= 2.3f)
                    {
                        position.x = transform.position.x;
                     //   print("yesss");
                       // print("pos:" + position.x);
                        if (move.x < 0)
                        {
                            move.x = 0;
                        }
                        if (move.y > 0)
                        {

                            move.y = 0;
                        }
                        if (move.y > 0 && move.x < 0)
                        {
                            move.x = 0;
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
                movest = true;
                dist = Vector3.Distance(stickL[1].transform.position, transform.position);
                position.y = Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax);
                position.x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax);
                //positionbetthestiks.y = Mathf.Clamp(transform.position.y, dist,0.25f);
                positionbetthestiks.x = Mathf.Clamp(dist, 1.9f, 5f);
                bordervector = new Vector2(position.x, position.y);
                // Get movement of the finger since last frame
                Vector2 posit = Input.GetTouch(1).deltaPosition;
                //print(dist);
               // print("DistMin: " + positionbetthestiks.x);
               // print("x: " + transform.position.x);


                move = new Vector2(posit.x, posit.y);
                // posits = new Vector2(transform.position.x, transform.position.y);
                Rg.MovePosition((Vector2)transform.position + move * speed);
                if (dist <= 2f)
                {
                    position.x = transform.position.x;
                    //print("yesss");
                   // print("pos:" + position.x);
                    if (move.x < 0)
                    {
                        move.x = 0;
                    }
                    if (move.y > 0)
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
    }
        /*
            public void FixedUpdate()
            {
                width = Screen.width;
                height = Screen.height;
                float speed = this.speed * Time.fixedDeltaTime * 10;
                Touch touchs = Input.GetTouch(0);



                /*if (Screen.width == 720 && Screen.height == 1280)
                {
                    if (touchs.position.x >= 650 && touchs.position.x <= 930)
                    {

                        if (Input.GetTouch(0).phase == TouchPhase.Moved)
                        {
                            // Get movement of the finger since last frame

                            Vector2 posit = Input.GetTouch(0).deltaPosition;
                            // 650 do 1180
                            print(touchs.position.x);


                            // print("takss");
                            transform.Translate(posit.x * speed, posit.y * speed, 0);

                        }
                    }
                    else
                    {
                        if (Input.GetTouch(1).phase == TouchPhase.Moved)
                        {
                            // Get movement of the finger since last frame

                            Vector2 posit = Input.GetTouch(1).deltaPosition;
                            // 86 67 
                            //   print(touch.position.x);


                            print("opa");
                            transform.Translate(posit.x * speed, posit.y * speed, 0);
                        }

                    }

                }

                //
                // Track a single touch as a direction control.
              //  if (vkl == true)
               // {

                    if (touchs.position.x >= (Screen.width / 2) + 30 && touchs.position.x <= Screen.width && touchs.position.y <= Screen.height / 2)
                    {

                        if (Input.GetTouch(0).phase == TouchPhase.Moved)
                        {

                            // Get movement of the finger since last frame
                            //print("takss");
                            Vector2 posit = Input.GetTouch(0).deltaPosition;
                            // 650 do 1180
                            //print(touchs.position.x);
                            position.y = boundary.yMin;
                            position.x = boundary.xMin;

                            position.y = Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax);
                            position.x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax);
                        // print("positiony:" + Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax));
                        //print("positionx:" + Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax));
                        // print("positx:" + posit.x);
                        //print("posity:" + posit.y);
                        // print("takss");

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
                        //transform.position = new Vector2(position.x, position.y);
                        //if (position.x  >= transform.position.x || position.y >= transform.position.y)
                        //{
                        //  print("takss");
                        // transform.Translate(position.x, position.y, 0);                      
                        //}
                    }
                    }
                    else
                    {
                    if (Input.GetTouch(1).phase == TouchPhase.Moved)
                    {
                        Vector2 posit = Input.GetTouch(1).deltaPosition;
                        position.y = boundary.yMin;
                        position.x = boundary.xMin;
                        position.y = Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax);
                        position.x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax);
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
                /*  if (touchs.position.x >= 650 && touchs.position.x <= 1180)
                  {

                      if (Input.GetTouch(0).phase == TouchPhase.Moved)
                      {
                          // Get movement of the finger since last frame

                          Vector2 posit = Input.GetTouch(0).deltaPosition;
                          // 650 do 1180
                         // print(touchs.position.x);


                          // print("takss");
                          transform.Translate(posit.x * speed, posit.y * speed, 0);
                      }
                  }
                  else
                  {
                      if (Input.GetTouch(1).phase == TouchPhase.Moved)
                      {
                          // Get movement of the finger since last frame

                          Vector2 posit = Input.GetTouch(1).deltaPosition;
                          // 86 67 
                          print(touchs.position.x);


                          //  print("opa");
                          transform.Translate(posit.x * speed, posit.y * speed, 0);
                      }

                  }
              }*/
   
}
    

//}  



using UnityEngine;
using UnityEngine.Scripting;

public class GameEff : MonoBehaviour
{
    public GameObject[] Stick;
    public GameObject[] ball;
    public GameObject high;
    public GameObject DropEff;
    public bool Eff = false;
   // bool val = false;
    float LoadEff;
   // public Text ran;
    public float speedDR = 0.02f;
    private float i = 100.0f;
  //  private float j = 50.0f;
    public bool perevor = false;
    public bool dvig = true;
    public  Rigidbody2D rigb;
    private int interval = 15;
    void Start()
    {
       // GarbageCollector.GCMode = GarbageCollector.Mode.Disabled;
        rigb = DropEff.GetComponent<Rigidbody2D>();
        high = GameObject.Find("BackGround");
      //  Stick = GameObject.FindGameObjectsWithTag("Stick");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % interval == 0)
        {
            high = GameObject.Find("BackGround");
        }
        if (high.GetComponent<BackGroundMove>().h >= i && high.GetComponent<BackGroundMove>().h <= i + 0.1)
        {
           
            Random.InitState((int)System.DateTime.Now.Ticks);
            LoadEff = Random.Range(0, 3);
            i += 100.0f;
            switch (LoadEff)
            {
                case 0:
                    Eff = false;
                    if (perevor == true)
                    {
                        Stick[0].GetComponent<Gameplay2>().boundary.yMin = 1.5f;
                        Stick[0].GetComponent<Gameplay2>().boundary.yMax = 4f;
                        Stick[1].GetComponent<Gameplay>().boundary.yMin = 1.5f;
                        Stick[1].GetComponent<Gameplay>().boundary.yMax = 4f;
                        Stick[2].GetComponent<Gameplay2>().boundary.yMin = 1.5f;
                        Stick[2].GetComponent<Gameplay2>().boundary.yMax = 4f;
                        Stick[3].GetComponent<Gameplay>().boundary.yMin = 1.5f;
                        Stick[3].GetComponent<Gameplay>().boundary.yMax = 4f;
                        Stick[4].GetComponent<Gameplay2>().boundary.yMin = 1.5f;
                        Stick[4].GetComponent<Gameplay2>().boundary.yMax = 4f;
                        Stick[5].GetComponent<Gameplay>().boundary.yMin = 1.5f;
                        Stick[5].GetComponent<Gameplay>().boundary.yMax = 4f;
                        Stick[6].GetComponent<Gameplay2>().boundary.yMin = 1.5f;
                        Stick[6].GetComponent<Gameplay2>().boundary.yMax = 4f;
                        Stick[7].GetComponent<Gameplay>().boundary.yMin = 1.5f;
                        Stick[7].GetComponent<Gameplay>().boundary.yMax = 4f;
                        Stick[8].GetComponent<Gameplay2>().boundary.yMin = 1.5f;
                        Stick[8].GetComponent<Gameplay2>().boundary.yMax = 4f;
                        Stick[9].GetComponent<Gameplay>().boundary.yMin = 1.5f;
                        Stick[9].GetComponent<Gameplay>().boundary.yMax = 4f;
                        Stick[10].GetComponent<Gameplay2>().boundary.yMin = 1.5f;
                        Stick[10].GetComponent<Gameplay2>().boundary.yMax = 4f;
                        Stick[11].GetComponent<Gameplay>().boundary.yMin = 1.5f;
                        Stick[11].GetComponent<Gameplay>().boundary.yMax = 4f;
                        perevor = false;       
                        Stick[0].GetComponent<Animation>().Play("stickRDown");
                        Stick[1].GetComponent<Animation>().Play("stickLDown");
                        Stick[2].GetComponent<Animation>().Play("stickRDown");
                        Stick[3].GetComponent<Animation>().Play("stickLDown");
                        Stick[4].GetComponent<Animation>().Play("stickRDown");
                        Stick[5].GetComponent<Animation>().Play("stickLDown");
                        Stick[6].GetComponent<Animation>().Play("stickRDown");
                        Stick[7].GetComponent<Animation>().Play("stickLDown");
                        Stick[8].GetComponent<Animation>().Play("stickRDown");
                        Stick[9].GetComponent<Animation>().Play("stickLDown");
                        Stick[10].GetComponent<Animation>().Play("stickRDown");
                        Stick[11].GetComponent<Animation>().Play("stickLDown");
                        ball[0].GetComponent<Collectmoney>().grasc = 1.0f;
                        ball[0].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                        ball[0].GetComponent<Animation>().Play("ballAnimDown");
                        ball[1].GetComponent<Animation>().Play("ballAnimDown");
                        ball[1].GetComponent<Collectmoney>().grasc = 1.0f;
                        ball[1].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                        ball[2].GetComponent<Animation>().Play("ballAnimDown");
                        ball[2].GetComponent<Collectmoney>().grasc = 1.0f;
                        ball[2].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                        ball[3].GetComponent<Animation>().Play("ballAnimDown");
                        ball[3].GetComponent<Collectmoney>().grasc = 1.0f;
                        ball[3].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                        ball[4].GetComponent<Animation>().Play("ballAnimDown");
                        ball[4].GetComponent<Collectmoney>().grasc = 1.0f;
                        ball[4].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                        ball[5].GetComponent<Animation>().Play("ballAnimDown");
                        ball[5].GetComponent<Collectmoney>().grasc = 1.0f;
                        ball[5].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                    }
                    break;
                case 1:
                    Eff = true; 
                    Stick[0].GetComponent<Gameplay2>().boundary.yMin = 4.5f;
                    Stick[0].GetComponent<Gameplay2>().boundary.yMax = 7.5f;
                    Stick[1].GetComponent<Gameplay>().boundary.yMin = 4.5f;
                    Stick[1].GetComponent<Gameplay>().boundary.yMax = 7.5f;
                    Stick[2].GetComponent<Gameplay2>().boundary.yMin = 4.5f; 
                    Stick[2].GetComponent<Gameplay2>().boundary.yMax = 7.5f;
                    Stick[3].GetComponent<Gameplay>().boundary.yMin = 4.5f; 
                    Stick[3].GetComponent<Gameplay>().boundary.yMax = 7.5f;
                    Stick[4].GetComponent<Gameplay2>().boundary.yMin = 4.5f;
                    Stick[4].GetComponent<Gameplay2>().boundary.yMax = 7.5f;
                    Stick[5].GetComponent<Gameplay>().boundary.yMin = 4.5f;
                    Stick[5].GetComponent<Gameplay>().boundary.yMax = 7.5f;
                    Stick[6].GetComponent<Gameplay2>().boundary.yMin = 4.5f;
                    Stick[6].GetComponent<Gameplay2>().boundary.yMax = 7.5f;
                    Stick[7].GetComponent<Gameplay>().boundary.yMin = 4.5f;
                    Stick[7].GetComponent<Gameplay>().boundary.yMax = 7.5f;
                    Stick[8].GetComponent<Gameplay2>().boundary.yMin = 4.5f;
                    Stick[8].GetComponent<Gameplay2>().boundary.yMax = 7.5f;
                    Stick[9].GetComponent<Gameplay>().boundary.yMin = 4.5f;
                    Stick[9].GetComponent<Gameplay>().boundary.yMax = 7.5f;
                    Stick[10].GetComponent<Gameplay2>().boundary.yMin = 4.5f;
                    Stick[10].GetComponent<Gameplay2>().boundary.yMax = 7.5f;
                    Stick[11].GetComponent<Gameplay>().boundary.yMin = 4.5f;
                    Stick[11].GetComponent<Gameplay>().boundary.yMax = 7.5f;
                    perevor = true;
                    Stick[0].GetComponent<Animation>().Play("stickRUp");
                    Stick[1].GetComponent<Animation>().Play("stickLUp");
                    Stick[2].GetComponent<Animation>().Play("stickRUp");
                    Stick[3].GetComponent<Animation>().Play("stickLUp");
                    Stick[4].GetComponent<Animation>().Play("stickRUp");
                    Stick[5].GetComponent<Animation>().Play("stickLUp");
                    Stick[6].GetComponent<Animation>().Play("stickRUp");
                    Stick[7].GetComponent<Animation>().Play("stickLUp");
                    Stick[8].GetComponent<Animation>().Play("stickRUp");
                    Stick[9].GetComponent<Animation>().Play("stickLUp");
                    Stick[10].GetComponent<Animation>().Play("stickRUp");
                    Stick[11].GetComponent<Animation>().Play("stickLUp");
                    ball[0].GetComponent<Animation>().Play("ballAnimUP");
                    ball[0].GetComponent<Collectmoney>().grasc = -1.0f;
                    ball[0].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                    ball[1].GetComponent<Animation>().Play("ballAnimUP");
                    ball[1].GetComponent<Collectmoney>().grasc = -1.0f;
                    ball[1].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                    ball[2].GetComponent<Animation>().Play("ballAnimUP");
                    ball[2].GetComponent<Collectmoney>().grasc = -1.0f;
                    ball[2].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                    ball[3].GetComponent<Animation>().Play("ballAnimUP");
                    ball[3].GetComponent<Collectmoney>().grasc = -1.0f;
                    ball[3].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                    ball[4].GetComponent<Animation>().Play("ballAnimUP");
                    ball[4].GetComponent<Collectmoney>().grasc = -1.0f;
                    ball[4].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                    ball[5].GetComponent<Animation>().Play("ballAnimUP");
                    ball[5].GetComponent<Collectmoney>().grasc = -1.0f;
                    ball[5].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                    break;
                case 2:
                    Eff = false;
                    if (perevor == true)
                    {
                        Stick[0].GetComponent<Gameplay2>().boundary.yMin = 1.5f;
                        Stick[0].GetComponent<Gameplay2>().boundary.yMax = 4f;
                        Stick[1].GetComponent<Gameplay>().boundary.yMin = 1.5f;
                        Stick[1].GetComponent<Gameplay>().boundary.yMax = 4f;
                        Stick[2].GetComponent<Gameplay2>().boundary.yMin = 1.5f;
                        Stick[2].GetComponent<Gameplay2>().boundary.yMax = 4f;
                        Stick[3].GetComponent<Gameplay>().boundary.yMin = 1.5f;
                        Stick[3].GetComponent<Gameplay>().boundary.yMax = 4f;
                        Stick[4].GetComponent<Gameplay2>().boundary.yMin = 1.5f;
                        Stick[4].GetComponent<Gameplay2>().boundary.yMax = 4f;
                        Stick[5].GetComponent<Gameplay>().boundary.yMin = 1.5f;
                        Stick[5].GetComponent<Gameplay>().boundary.yMax = 4f;
                        Stick[6].GetComponent<Gameplay2>().boundary.yMin = 1.5f;
                        Stick[6].GetComponent<Gameplay2>().boundary.yMax = 4f;
                        Stick[7].GetComponent<Gameplay>().boundary.yMin = 1.5f;
                        Stick[7].GetComponent<Gameplay>().boundary.yMax = 4f;
                        Stick[8].GetComponent<Gameplay2>().boundary.yMin = 1.5f;
                        Stick[8].GetComponent<Gameplay2>().boundary.yMax = 4f;
                        Stick[9].GetComponent<Gameplay>().boundary.yMin = 1.5f;
                        Stick[9].GetComponent<Gameplay>().boundary.yMax = 4f;
                        Stick[10].GetComponent<Gameplay2>().boundary.yMin = 1.5f;
                        Stick[10].GetComponent<Gameplay2>().boundary.yMax = 4f;
                        Stick[11].GetComponent<Gameplay>().boundary.yMin = 1.5f;
                        Stick[11].GetComponent<Gameplay>().boundary.yMax = 4f;
                        perevor = false;
                        Stick[0].GetComponent<Animation>().Play("stickRDown");
                        Stick[1].GetComponent<Animation>().Play("stickLDown");
                        Stick[2].GetComponent<Animation>().Play("stickRDown");
                        Stick[3].GetComponent<Animation>().Play("stickLDown");
                        Stick[4].GetComponent<Animation>().Play("stickRDown");
                        Stick[5].GetComponent<Animation>().Play("stickLDown");
                        Stick[6].GetComponent<Animation>().Play("stickRDown");
                        Stick[7].GetComponent<Animation>().Play("stickLDown");
                        Stick[8].GetComponent<Animation>().Play("stickRDown");
                        Stick[9].GetComponent<Animation>().Play("stickLDown");
                        Stick[10].GetComponent<Animation>().Play("stickRDown");
                        Stick[11].GetComponent<Animation>().Play("stickLDown");
                        ball[0].GetComponent<Collectmoney>().grasc = 1.0f;
                        ball[0].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                        ball[0].GetComponent<Animation>().Play("ballAnimDown");
                        ball[1].GetComponent<Animation>().Play("ballAnimDown");
                        ball[1].GetComponent<Collectmoney>().grasc = 1.0f;
                        ball[1].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                        ball[2].GetComponent<Animation>().Play("ballAnimDown");
                        ball[2].GetComponent<Collectmoney>().grasc = 1.0f;
                        ball[2].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                        ball[3].GetComponent<Animation>().Play("ballAnimDown");
                        ball[3].GetComponent<Collectmoney>().grasc = 1.0f;
                        ball[3].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                        ball[4].GetComponent<Animation>().Play("ballAnimDown");
                        ball[4].GetComponent<Collectmoney>().grasc = 1.0f;
                        ball[4].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                        ball[5].GetComponent<Animation>().Play("ballAnimDown");
                        ball[5].GetComponent<Collectmoney>().grasc = 1.0f;
                        ball[5].GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                    }
                   for (int j = 0; j < 2; j++)
                   {
                       Instantiate(DropEff, new Vector3(UnityEngine.Random.Range(28.3f, 32f), UnityEngine.Random.Range(4f, 7f), 45), Quaternion.identity);
                   }
                   //val = true;
                    break;
            }
        }

          //  if (val == true)
       // {
            if (DropEff.transform.position.y < 0)
            {
                Destroy(DropEff);
             //   val = false;
            }
        if (dvig == true) {
            rigb.MovePosition(new Vector2(transform.position.x, transform.position.y - speedDR));
            //DropEff.transform.position = new Vector2(transform.position.x, transform.position.y - speedDR);
        }// }
    }

}

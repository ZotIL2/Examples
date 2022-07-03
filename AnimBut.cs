using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AnimBut : MonoBehaviour
{
    public GameObject AnimButt;
    public string animbuton;
    // Start is called before the first frame update
    public void Start()
    {
        AnimButt.GetComponent<Animation>();
    }
    public void OnMouseDown()
    {

        switch (animbuton)
        {
            case "MainMenu": 
                AnimButt.GetComponent<Animation>().Play("putbut");
                break;
            case "back":
                 AnimButt.GetComponent<Animation>().Play("putbut1");
                break;
            case "Arcade":
                AnimButt.GetComponent<Animation>().Play("putbutAr");
                break;
            case "TimeMutch":
                AnimButt.GetComponent<Animation>().Play("putbutTi");
                break;
        }
    }
}

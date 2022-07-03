using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStick : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public bool paus;
    public GameObject PauseAnim;
    
    void Start()
    {
      //  paus = PauseAnim.GetComponent<pause>().AnimVkl;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //paus = PauseAnim.GetComponent<pause>().val;
       // Debug.Log(paus);
        if (paus == false)
        {
            anim.SetBool("PauseOff", true);
        }
        if (paus == true) { anim.SetBool("PauseOff", false); }
    }
}

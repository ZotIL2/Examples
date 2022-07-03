using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancle : MonoBehaviour
{
    public GameObject Vibor, Phone_sunset;
    public AudioSource PutSound;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        PutSound.Play();
        GetComponent<Transform>().localScale = new Vector3(140f, 140f, 140f);
    }
    private void OnMouseUp()
    {
        Vibor.SetActive(false);
        Phone_sunset.GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Transform>().localScale = new Vector3(148f, 148f, 148f);
    }
}

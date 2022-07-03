using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBlock : MonoBehaviour
{
    [SerializeField]
    private GameObject MAd;
    public GameObject paus;
    public MoveBackG backGroundMove;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block")  // проверка на столкновения
        {
            paus.GetComponent<AnimationStick>().paus = false;
            MAd.SetActive(true);
            Time.timeScale = 0f;
            PlayerPrefs.SetFloat("Height", backGroundMove.h);
        }
    }
}

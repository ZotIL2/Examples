using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueBallS : MonoBehaviour
{
    public GameObject ball_s, ball_m, ball_r, ball_ch, ball_cl, ball_NY,BackGraund, Phone, AddPhonetree, phonewinter, particalleaf, particalSnow;
    int valbal;
    int valstick;
    int valuephone;
    [SerializeField]
    private GameObject[] Blocks;
    private Sprite sprites;
    void Start()
    {
        valbal = PlayerPrefs.GetInt("ballvalue");
        valstick = PlayerPrefs.GetInt("stickvalue");
        valuephone = PlayerPrefs.GetInt("valuephone");
        switch (valbal)
        {
            case 0:
                ball_s.SetActive(true);
                ball_m.SetActive(false);
                ball_r.SetActive(false);
                ball_cl.SetActive(false);
                ball_ch.SetActive(false);
                ball_NY.SetActive(false);
                break;
            case 1:
                ball_s.SetActive(false);
                ball_m.SetActive(true);
                ball_r.SetActive(false);
                ball_cl.SetActive(false);
                ball_ch.SetActive(false);
                ball_NY.SetActive(false);
                break;
            case 2:
                ball_s.SetActive(false);
                ball_m.SetActive(false);
                ball_r.SetActive(true);
                ball_cl.SetActive(false);
                ball_ch.SetActive(false);
                ball_NY.SetActive(false);
                break;
            case 3:
                ball_s.SetActive(false);
                ball_m.SetActive(false);
                ball_r.SetActive(false);
                ball_cl.SetActive(true);
                ball_ch.SetActive(false);
                ball_NY.SetActive(false);
                break;
            case 4:
                ball_s.SetActive(false);
                ball_m.SetActive(false);
                ball_r.SetActive(false);
                ball_cl.SetActive(false);
                ball_ch.SetActive(true);
                ball_NY.SetActive(false);
                break;
            case 7:
                ball_s.SetActive(false);
                ball_m.SetActive(false);
                ball_r.SetActive(false);
                ball_cl.SetActive(true);
                ball_ch.SetActive(false);
                ball_NY.SetActive(false);
                break;
            case 8:
                ball_s.SetActive(false);
                ball_m.SetActive(false);
                ball_r.SetActive(false);
                ball_cl.SetActive(false);
                ball_ch.SetActive(false);
                ball_NY.SetActive(true);
                break;
        }
        switch (valstick)
        {
            case 5:
                foreach (SpriteRenderer g in Blocks[0].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_standart");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -122f);

                }
                foreach (SpriteRenderer g in Blocks[1].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_standart");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -122f);
                }
                foreach (SpriteRenderer g in Blocks[2].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_standart");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -122f);
                }
                foreach (SpriteRenderer g in Blocks[3].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_standart");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -122f);
                }
                break;
            case 6:
                foreach (SpriteRenderer g in Blocks[0].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_retro");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                foreach (SpriteRenderer g in Blocks[1].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_retro");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.96f, -121f);
                }
                foreach (SpriteRenderer g in Blocks[2].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_retro");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.96f, -121f);
                }
                foreach (SpriteRenderer g in Blocks[3].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_retro");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.96f, -121f);
                }
                break;
            case 8:
                foreach (SpriteRenderer g in Blocks[0].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_miami");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                foreach (SpriteRenderer g in Blocks[1].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_miami");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                foreach (SpriteRenderer g in Blocks[2].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_miami");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                foreach (SpriteRenderer g in Blocks[3].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_miami");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                break;
            case 9:
                foreach (SpriteRenderer g in Blocks[0].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_china");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                foreach (SpriteRenderer g in Blocks[1].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_china");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                foreach (SpriteRenderer g in Blocks[2].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_china");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                foreach (SpriteRenderer g in Blocks[3].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_china");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                break;
            case 10:
                foreach (SpriteRenderer g in Blocks[0].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_clasic");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                foreach (SpriteRenderer g in Blocks[1].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_clasic");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                foreach (SpriteRenderer g in Blocks[2].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_clasic");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                foreach (SpriteRenderer g in Blocks[3].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_1_clasic");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -234.579f, -121f);
                }
                break;
            case 11:
                foreach (SpriteRenderer g in Blocks[0].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_2_new year");
                    g.GetComponent<Transform>().rotation = new Quaternion(0,0,-232.3f, -116.15f); 
                }
                foreach (SpriteRenderer g in Blocks[1].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_2_new year");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -232.3f, -116.15f);
                }
                foreach (SpriteRenderer g in Blocks[2].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_2_new year");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -232.3f, -116.15f);
                }
                foreach (SpriteRenderer g in Blocks[3].GetComponentsInChildren<SpriteRenderer>())
                {
                    g.sprite = Resources.Load<Sprite>("stick_2_new year");
                    g.GetComponent<Transform>().rotation = new Quaternion(0, 0, -232.3f, -116.15f);
                }
                break;

        }
      
        switch (valuephone)
        {
            case 0:
                sprites = Resources.Load<Sprite>("Phone_standart");
                Phone.GetComponent<SpriteRenderer>().sprite = sprites;
                sprites = Resources.Load<Sprite>("cloud_PNG");
                BackGraund.GetComponent<SpriteRenderer>().sprite = sprites;
                AddPhonetree.SetActive(false);
                particalleaf.SetActive(false);
                phonewinter.SetActive(false);
                particalSnow.SetActive(false);
                break;
            case 1:
                sprites = Resources.Load<Sprite>("Phone_sunset");
                Phone.GetComponent<SpriteRenderer>().sprite = sprites;
                sprites = Resources.Load<Sprite>("cloud_sun");
                BackGraund.GetComponent<SpriteRenderer>().sprite = sprites;
                AddPhonetree.SetActive(false);
                particalleaf.SetActive(false);
                break;
            case 2:
                sprites = Resources.Load<Sprite>("Phone_tree");
                Phone.GetComponent<SpriteRenderer>().sprite = sprites;
                sprites = Resources.Load<Sprite>("clouds");
                BackGraund.GetComponent<SpriteRenderer>().sprite = sprites;
                AddPhonetree.SetActive(true);
                phonewinter.SetActive(false);
                particalSnow.SetActive(false);
                if (PlayerPrefs.GetInt("VklPartical") == 1)
                {
                    particalleaf.SetActive(true);
                }
                if (PlayerPrefs.GetInt("VklPartical") == 0)
                {
                    particalleaf.SetActive(false);
                }
                break;
            case 3:
                sprites = Resources.Load<Sprite>("PhoneWinter");
                Phone.GetComponent<SpriteRenderer>().sprite = sprites;
                sprites = Resources.Load<Sprite>("clouds");
                BackGraund.GetComponent<SpriteRenderer>().sprite = sprites;
                AddPhonetree.SetActive(false);
                particalleaf.SetActive(false);
                phonewinter.SetActive(true);
                if (PlayerPrefs.GetInt("VklPartical") == 1)
                {
                    particalSnow.SetActive(true);
                }
                if (PlayerPrefs.GetInt("VklPartical") == 0)
                {
                    particalSnow.SetActive(false);
                }
                break;
        }
    }
}


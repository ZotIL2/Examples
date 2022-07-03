using UnityEngine;

public class valueball : MonoBehaviour
{
    public GameObject ball_s, ball_m, ball_r, ball_ch, ball_cl, ball_NY, sticksl, sticksr, stickrl, stickrr, sitckmr, stickml, stickcr, stickcl, stickclasr, stickclasl, stickcNYR, stickcNYL, BackGraund,Phone,AddPhonetree, phonewinter, particalleaf, particalSnow;
    int valbal;
    int valstick;
    int valuephone;
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

        switch (valstick)
        {
            case 5:
                sticksr.SetActive(true);
                sticksl.SetActive(true);
                stickrl.SetActive(false);
                stickrr.SetActive(false);
                sitckmr.SetActive(false);
                stickml.SetActive(false);
                stickcr.SetActive(false);
                stickcl.SetActive(false);
                stickclasr.SetActive(false);
                stickclasl.SetActive(false);
                stickcNYR.SetActive(false);
                stickcNYL.SetActive(false);
                break;
            case 6:
                sticksl.SetActive(false);
                sticksr.SetActive(false);
                sitckmr.SetActive(false);
                stickml.SetActive(false);
                stickcr.SetActive(false);
                stickcl.SetActive(false);
                stickclasr.SetActive(false);
                stickclasl.SetActive(false);
                stickrr.SetActive(true);
                stickrl.SetActive(true);
                stickcNYR.SetActive(false);
                stickcNYL.SetActive(false);
                break;
            case 8:
                sticksl.SetActive(false);
                sticksr.SetActive(false);
                stickrr.SetActive(false);
                stickrl.SetActive(false);
                stickcr.SetActive(false);
                stickcl.SetActive(false);
                stickclasr.SetActive(false);
                stickclasl.SetActive(false);
                sitckmr.SetActive(true);
                stickml.SetActive(true);
                stickcNYR.SetActive(false);
                stickcNYL.SetActive(false);
                break;
            case 9:
                sticksl.SetActive(false);
                sticksr.SetActive(false);
                stickrr.SetActive(false);
                stickrl.SetActive(false);
                sitckmr.SetActive(false);
                stickml.SetActive(false);
                stickclasr.SetActive(false);
                stickclasl.SetActive(false);
                stickcr.SetActive(true);
                stickcl.SetActive(true);
                stickcNYR.SetActive(false);
                stickcNYL.SetActive(false);
                break;
            case 10:
                sticksl.SetActive(false);
                sticksr.SetActive(false);
                stickrr.SetActive(false);
                stickrl.SetActive(false);
                sitckmr.SetActive(false);
                stickml.SetActive(false);
                stickcr.SetActive(false);
                stickcl.SetActive(false);
                stickclasr.SetActive(true);
                stickclasl.SetActive(true);
                stickcNYR.SetActive(false);
                stickcNYL.SetActive(false);
                break;
            case 11:
                sticksl.SetActive(false);
                sticksr.SetActive(false);
                stickrr.SetActive(false);
                stickrl.SetActive(false);
                sitckmr.SetActive(false);
                stickml.SetActive(false);
                stickcr.SetActive(false);
                stickcl.SetActive(false);
                stickclasr.SetActive(false);
                stickclasl.SetActive(false);
                stickcNYR.SetActive(true);
                stickcNYL.SetActive(true);
                break;

        }
    }
}

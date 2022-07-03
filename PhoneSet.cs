using UnityEngine;
using UnityEngine.Audio;
public class PhoneSet : MonoBehaviour
{
    int valuephone;
    public GameObject phonetree, phonewinter,particalleaf,particalSnow;
    public AudioMixerGroup MainMixer;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Sounds") == "off")//on
        {
            MainMixer.audioMixer.SetFloat("EffectsVol", 10); 
        }
        else//off
        {
            MainMixer.audioMixer.SetFloat("EffectsVol", -80);
        }
        valuephone = PlayerPrefs.GetInt("valuephone");
        if (PlayerPrefs.GetInt("IsFirstRunPar") == 0)
        {
            PlayerPrefs.SetInt("VklPartical",1);
            PlayerPrefs.SetInt("IsFirstRunPar", 1);
        }
        if (PlayerPrefs.GetInt("FirstSpeed") == 0)
        {
            PlayerPrefs.SetInt("FirstSpeed", 1);
            PlayerPrefs.SetFloat("SpeedPalka", 0.03f);
            PlayerPrefs.SetString("ation", "Low");
        }

    }

    // Update is called once per frame
    void Update()
    {
        valuephone = PlayerPrefs.GetInt("valuephone");
        switch (valuephone)
        {
            case 0:
                GameObject.FindGameObjectWithTag("phone").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Phone_standart");
                phonetree.SetActive(false);
                particalleaf.SetActive(false);
                phonewinter.SetActive(false);
                particalSnow.SetActive(false);
                break;
            case 1:
                GameObject.FindGameObjectWithTag("phone").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Phone_sunset");
                phonetree.SetActive(false);
                particalleaf.SetActive(false);
                phonewinter.SetActive(false);
                particalSnow.SetActive(false);
                break;
            case 2:
                GameObject.FindGameObjectWithTag("phone").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Phone_tree");
                phonetree.SetActive(true);
                phonewinter.SetActive(false);
                particalSnow.SetActive(false);
                Time.timeScale = 1f;
                if (particalleaf.activeSelf == false && PlayerPrefs.GetInt("VklPartical") == 1) {
                    particalleaf.SetActive(true);

                }
                if (PlayerPrefs.GetInt("VklPartical") == 0) { particalleaf.SetActive(false); }
                    break;
            case 3:
                GameObject.FindGameObjectWithTag("phone").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("phone_winter");
                phonetree.SetActive(false);
                particalleaf.SetActive(false);
                phonewinter.SetActive(true);
                Time.timeScale = 1f;
                if (particalSnow.activeSelf == false && PlayerPrefs.GetInt("VklPartical") == 1)
                {
                    particalSnow.SetActive(true);

                }
                if (PlayerPrefs.GetInt("VklPartical") == 0) { particalSnow.SetActive(false); }
                break;
        }
    }
}

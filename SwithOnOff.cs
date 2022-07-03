using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SwithOnOff : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PanelClose, PanelClose1, PanelClose2;
    public GameObject Music, Partical, Sounds;
    public string action;
    public GameObject myzon;
    public AudioSource PutSound;
    public AudioMixerGroup MainMixer;
    GameObject[] objs;
    private void Awake()
    {  
        if (objs != null)
        {
            objs = GameObject.FindGameObjectsWithTag("MusicBackGround");
            myzon = objs[0];
        }
    }
    void Start()
    {
        if (objs != null && objs.Length > 1)
        {
            
            objs = GameObject.FindGameObjectsWithTag("MusicBackGround");
            myzon = objs[1];
        }
        else { objs = GameObject.FindGameObjectsWithTag("MusicBackGround");  myzon = objs[0]; }
        if (PlayerPrefs.GetString("Sounds") == "off")//on
        {
          //     Debug.Log("on");
            Sounds.GetComponent<Image>().color = new Color32(83, 212, 105, 255);
            MainMixer.audioMixer.SetFloat("EffectsVol", 10);
            PanelClose2.GetComponent<Transform>().localPosition = new Vector3(28f, 0, 0);
        }
        else//off
        {
          //  Debug.Log("OFF");
            MainMixer.audioMixer.SetFloat("EffectsVol", -80);
            Sounds.GetComponent<Image>().color = new Color32(212, 212, 212, 170);
            PanelClose2.GetComponent<Transform>().localPosition = new Vector3(-28, 0, 0);
        }
        if (PlayerPrefs.GetString("Music") == "off")//on
        {
           // Debug.Log("on1");
            Music.GetComponent<Image>().color = new Color32(83, 212, 105, 255);
            PanelClose.GetComponent<Transform>().localPosition = new Vector3(28f, 0, 0);
            myzon.GetComponent<AudioSource>().mute = false;
        }
        else//off
        {
           // Debug.Log("OFF1");
            Music.GetComponent<Image>().color = new Color32(212, 212, 212, 170);
            PanelClose.GetComponent<Transform>().localPosition = new Vector3(-28, 0, 0);
            myzon.GetComponent<AudioSource>().mute = true;

        }
        if (PlayerPrefs.GetString("Partical") == "off") // on
        {
            Partical.GetComponent<Image>().color = new Color32(212, 212, 212, 170);
            PanelClose1.GetComponent<Transform>().localPosition = new Vector3(-28, 0, 0);
          //  print("on");

        }
        else
        {
            Partical.GetComponent<Image>().color = new Color32(83, 212, 105, 255);
            PanelClose1.GetComponent<Transform>().localPosition = new Vector3(28f, 0, 0);
          //  print("off");
           
         //   PlayerPrefs.SetString("Partical", "on");
           // PlayerPrefs.SetInt("VklPartical", 1);
           
        }
        if (gameObject.tag == "Music")
        {
            if (PlayerPrefs.GetString("Music") == "on")
            {
                // Camera.main.GetComponent<AudioListener>().enabled = false;
                myzon.GetComponent<AudioSource>().mute = true;
            }

        }

    }
    private void OnMouseUpAsButton()
    {
        switch (action)
        {
            case "Music":
                if (PlayerPrefs.GetString("Music") == "on")
                {
                    PutSound.Play();
                    PanelClose.GetComponent<Transform>().localPosition = new Vector3(28f, 0, 0);
                    PlayerPrefs.SetString("Music", "off");
                    //Camera.main.GetComponent<AudioListener>().enabled = true;
                    Music.GetComponent<Image>().color = new Color32(83, 212, 105, 255);
                    myzon.GetComponent<AudioSource>().mute = false;
                }
                else
                {
                    PutSound.Play();
                    Music.GetComponent<Image>().color = new Color32(212, 212, 212, 170);
                    PanelClose.GetComponent<Transform>().localPosition = new Vector3(-28, 0, 0);
                    PlayerPrefs.SetString("Music", "on");
                    // Camera.main.GetComponent<AudioListener>().enabled = false;
                    myzon.GetComponent<AudioSource>().mute = true;
                }
                break;
            case "Partical":
                if (PlayerPrefs.GetString("Partical") == "off")
                {
                    PutSound.Play();
                    PanelClose1.GetComponent<Transform>().localPosition = new Vector3(28f, 0, 0);
                    Partical.GetComponent<Image>().color = new Color32(83, 212, 105, 255);
                    PlayerPrefs.SetString("Partical", "on");
                    PlayerPrefs.SetInt("VklPartical",1);
                }
                else
                {
                    PutSound.Play();
                    PanelClose1.GetComponent<Transform>().localPosition = new Vector3(-28, 0, 0);
                    Partical.GetComponent<Image>().color = new Color32(212, 212, 212, 170);
                    PlayerPrefs.SetString("Partical", "off");
                    PlayerPrefs.SetInt("VklPartical", 0);
                }
                break;
            case "Sounds":
                if (PlayerPrefs.GetString("Sounds") == "on")
                {
                    PutSound.Play();
                    PlayerPrefs.SetString("Sounds", "off");
                    Sounds.GetComponent<Image>().color = new Color32(83, 212, 105, 255);
                    MainMixer.audioMixer.SetFloat("EffectsVol", 10);
                    PanelClose2.GetComponent<Transform>().localPosition = new Vector3(28f, 0, 0);
                }
                else
                {
                    PutSound.Play();
                    PlayerPrefs.SetString("Sounds", "on");
                    MainMixer.audioMixer.SetFloat("EffectsVol", -80);
                    Sounds.GetComponent<Image>().color = new Color32(212, 212, 212, 170);
                    PanelClose2.GetComponent<Transform>().localPosition = new Vector3(-28, 0, 0);
                }
                break;
        }
    }

}

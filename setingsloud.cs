using UnityEngine;
using UnityEngine.UI;

public class setingsloud : MonoBehaviour {

    public GameObject myzon;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MusicBackGround");
        if (objs.Length > 1 && objs.Length != 0)
        {
            Destroy(objs[1].gameObject);
        }

        DontDestroyOnLoad(myzon);
    }
    void Start()
    {
        if (PlayerPrefs.GetString("Music") == "off")
        {
            myzon.GetComponent<AudioSource>().mute = false;
        }
        else {
            myzon.GetComponent<AudioSource>().mute = true;
        }

            if (gameObject.name == "Music") {
            if (PlayerPrefs.GetString("Music") == "on")
            {
                myzon.GetComponent<AudioSource>().mute = true;
                // Camera.main.GetComponent<AudioListener>().enabled = false;
            }

        }
    }
   
}

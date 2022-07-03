using UnityEngine;

public class Speed : MonoBehaviour
{
    public GameObject[] speed;
    public string action;
    private bool on;
    public AudioSource PutSound;
    void Start()
    {
        on = true;
        if (PlayerPrefs.GetInt("FirstS") == 0)
        {
            PlayerPrefs.SetInt("FirstS",1);
            PlayerPrefs.SetFloat("SpeedPalka", 0.03f);
            speed[0].GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            speed[0].GetComponent<SpriteRenderer>().color = new Color32(82, 212, 105, 255);
            speed[1].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
            speed[2].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
            speed[2].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            speed[1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            PlayerPrefs.SetString("ation", "Low");
        }
    }
    void Update()
    {
        if (on == true)
        {
            //
            on = false;
            if (PlayerPrefs.GetString("ation") == "Low") {
                PlayerPrefs.SetFloat("SpeedPalka", 0.03f);
          
                speed[0].GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                speed[0].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                speed[1].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed[2].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed[2].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                speed[1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }
            else if (PlayerPrefs.GetString("ation") == "Medium") {
                PlayerPrefs.SetFloat("SpeedPalka", 0.05f);
              
                speed[0].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed[1].GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                speed[2].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed[1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                speed[0].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                speed[2].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            } else if (PlayerPrefs.GetString("ation") == "High") {
                PlayerPrefs.SetFloat("SpeedPalka", 0.07f);
              
                speed[0].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed[1].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed[2].GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                speed[2].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                speed[0].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                speed[1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }
    
        }
    }
    // Update is called once per frame
    void OnMouseUpAsButton()
    {
        switch (action)
        {
            case "Low":
                PlayerPrefs.SetString("ation", "Low");
                PutSound.Play();
                PlayerPrefs.SetFloat("SpeedPalka", 0.03f);
                speed[0].GetComponent<Transform>().localScale = new Vector3(1,1,1);
                speed[0].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                speed[1].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed[2].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed[2].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                speed[1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                break;
            case "Medium":
                PlayerPrefs.SetString("ation", "Medium");
                PlayerPrefs.SetFloat("SpeedPalka", 0.05f);
                PutSound.Play();
                speed[0].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed[1].GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                speed[2].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed[1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                speed[0].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                speed[2].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                break;
            case "High":
                PlayerPrefs.SetString("ation", "High");
                PlayerPrefs.SetFloat("SpeedPalka", 0.07f);
                PutSound.Play();
                speed[0].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed[1].GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed[2].GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                speed[2].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                speed[0].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                speed[1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                break;
        }
        
    }
}

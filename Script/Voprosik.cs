using UnityEngine;

public class Voprosik : MonoBehaviour
{
    public GameObject pole;
    public GameObject[] items;
    public string action;
    public AudioSource PutSound;
    //  int vop = 0;
    //   bool vkl;
    public void Update()  
    {
        //PlayerPrefs.SetInt("IsFirstRun", 0);
        // print(PlayerPrefs.GetInt("IsFirstRun"));
        switch (action)
        {
            case "Shop":
                if (PlayerPrefs.GetInt("IsFirstRun1") == 0)
                {
                    pole.SetActive(true);
                    pole.GetComponentInChildren<Animator>().SetBool("vkl", true);
                    PlayerPrefs.SetInt("IsFirstRun1", 1);
                }
                break;
            case "Arcade":
                if (PlayerPrefs.GetInt("IsFirstRun") == 0)
                {
                    pole.SetActive(true);
                    PlayerPrefs.SetInt("IsFirstRun", 1);
                }
                break;
        }
    }
    /* private void Update()
     {

         if(PlayerPrefs.GetInt("IsFirstRun") == 1)
         {
             PlayerPrefs.SetInt("IsFirstRun", 0);
             pole.SetActive(true);
             vkl = false;
         }
  }   */
    void OnMouseUpAsButton()
    {
        switch(action){
            case"Shop":
            if (!pole.activeSelf)
            {

             //   Advertisement.Banner.Hide(true);
                pole.SetActive(true);
                    pole.GetComponentInChildren<Animator>().Play("advice1");
                    pole.GetComponentInChildren<Animator>().SetBool("vkl", true);
                    PutSound.Play();
                }
            else
            {
                    // Advertisement.Banner.Hide(false);
                    PutSound.Play();
                    pole.SetActive(false);
                pole.GetComponentInChildren<Animator>().SetBool("vkl", false);
            }
                break;
            case "Arcade":
                if (!pole.activeSelf)
                {
                    PutSound.Play();
                    // Advertisement.Banner.Hide(true);
                    items[0].GetComponent<BoxCollider2D>().enabled= false;
                    items[1].GetComponent<BoxCollider2D>().enabled = false;
                    items[2].GetComponent<BoxCollider2D>().enabled = false;
                    items[3].GetComponent<BoxCollider2D>().enabled = false;
                    items[4].GetComponent<BoxCollider2D>().enabled = false;
                    pole.SetActive(true);
                }
                else
                {
                    pole.SetActive(false);
                    PutSound.Play();
                    //Advertisement.Banner.Hide(false);
                    items[0].GetComponent<BoxCollider2D>().enabled = true;
                    items[1].GetComponent<BoxCollider2D>().enabled = true;
                    items[2].GetComponent<BoxCollider2D>().enabled = true;
                    items[3].GetComponent<BoxCollider2D>().enabled = true;
                    items[4].GetComponent<BoxCollider2D>().enabled = true;
                  
                }
                break;
        }
    }
}

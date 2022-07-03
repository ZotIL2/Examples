using UnityEngine;
using UnityEngine.SceneManagement;

public class backv: MonoBehaviour{
    public string action;
    public GameObject menuvibor, magazi;
    public AudioSource PutSound;
    private void OnMouseDown()
    {
        GetComponent<Transform>().localScale = new Vector3(0.48f, 0.48f, 0.77f);
        PutSound.Play();
    }
    void OnMouseUpAsButton(){
        switch (action) {
            case "back":
                GetComponent<Transform>().localScale = new Vector3(0.52f, 0.52f, 0.77f);
                menuvibor.SetActive(true);
                magazi.SetActive(false);
                break;
        }
    }
}
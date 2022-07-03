using UnityEngine;
using UnityEngine.SceneManagement;

public class back1 : MonoBehaviour
{
    public string action;
    public GameObject menuvibor, gamevibor;
    public AudioSource PutSound;
    private void OnMouseDown()
    {
        GetComponent<Transform>().localScale = new Vector3(1f, 1f, 0.77f);
        PutSound.Play();
    }
    void OnMouseUpAsButton()
    {
        switch (action)
        {
            case "back":
                GetComponent<Transform>().localScale = new Vector3(1.2f, 1.2f, 0.77f);
                menuvibor.SetActive(true);
                gamevibor.SetActive(false);
                break;
        }
    }
}
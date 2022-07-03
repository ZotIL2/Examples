using UnityEngine;
using UnityEngine.SceneManagement;

public class magaz: MonoBehaviour
{
    public string action;
    public GameObject menuvibor, magazi;
    public AudioSource PutSound;
    private void OnMouseDown()
    {
        GetComponent<Transform>().localScale = new Vector3(0.71f, 0.71f, 0.77f);
        PutSound.Play();
    }
    void OnMouseUpAsButton()
    {
        switch (action)
        {
            case "magaz":
                GetComponent<Transform>().localScale = new Vector3(0.77f, 0.77f, 0.77f);
                menuvibor.SetActive(false);
                magazi.SetActive(true);
                break;
        }
    }
}
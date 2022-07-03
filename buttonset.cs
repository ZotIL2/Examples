using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonset : MonoBehaviour
{
    public GameObject main, settings;
    public string action;
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
            case "settings":
                GetComponent<Transform>().localScale = new Vector3(0.77f, 0.77f, 0.77f);
                main.SetActive(false);
                settings.SetActive(true);
                break;
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public string action;
    public GameObject main, menuvibor;
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
            case "Back":
                GetComponent<Transform>().localScale = new Vector3(0.77f, 0.77f, 0.77f);
                menuvibor.SetActive(false);
                main.SetActive(true);
                break;
            case "Exit":
                GetComponent<Transform>().localScale = new Vector3(0.77f, 0.77f, 0.77f);
                Application.Quit();
                break;
        }

    }
}
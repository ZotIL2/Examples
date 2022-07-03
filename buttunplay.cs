using UnityEngine;
using UnityEngine.SceneManagement;

public class buttunplay : MonoBehaviour
{

    public string action;
    public GameObject main, menuvibor;
    void OnMouseUpAsButton() {
        switch (action) {
            case "Play":
                main.SetActive(false);
                menuvibor.SetActive(true);
                break;
        }
    }
}
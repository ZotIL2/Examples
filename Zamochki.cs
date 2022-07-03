using UnityEngine;
using UnityEngine.SceneManagement;

public class Zamochki : MonoBehaviour
{

    public GameObject pLost;
    public string action;
    void OnMouseUpAsButton(){
        switch (action){
            case "zamok palma":
                pLost.SetActive(true);
                break;
            case "zamok china":
                pLost.SetActive(true);
                break;

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : MonoBehaviour
{
    public GameObject[] explain;
    public string action;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseUpAsButton()
    {
        switch (action)
        {
            case "back":
                i--;
                explain[--i].SetActive(true);
                explain[++i].SetActive(false);
                if (i <= 0) { i = 0; explain[0].SetActive(true); }
                print(i);
               
                
                break;
            case "forward":
                i++;
                explain[++i].SetActive(true);
                print(i);
                explain[--i].SetActive(false);
                print(i);
                if (i > 5) { i = 4; explain[i].SetActive(true); }
                
               
               
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

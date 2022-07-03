using UnityEngine;
using UnityEngine.UI;

public class CountMoney : MonoBehaviour {
    private Text txt;
    

	void Start () {
        
        txt = GetComponent<Text>();
        txt.text = PlayerPrefs.GetInt("Money").ToString();
    }

}

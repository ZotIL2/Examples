using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBlock : MonoBehaviour
{
    int i = 0;
    int[] j= {0,0,0,0};
    [SerializeField]
    private GameObject[] Blocks;
    public GameObject score;
    public GameObject scoretxt;
    public GameObject Bestscoretxt;
    private float BestScore;
    // private GameObject[] BlockElem;
    private List<GameObject> SpawnBlock = new List<GameObject>();
    List<int> Randomin = new List<int> {};
    int ToTest = 0;
    [SerializeField]
    public MoveBackG move;
    float speed = -0.01f;
    float k = 100;
    int[] Randpos = { 1, 0, 2, 3 };
    System.Random random = new System.Random();
    [SerializeField]
    private GameObject scoreM;
    [SerializeField]
    private GameObject PauseM;
    [SerializeField]
    private GameObject MAd;
    // Start is called before the first frame update
    private void rand()
    {
       
            ToTest = random.Next(0, Blocks.Length);
            if (Randomin.Contains(ToTest))
            {
             rand();  
            }
            else
            {
            Randomin.Add(ToTest);
            }
        
    }
        void Start()
    {
        speed = -0.01f;
        scoretxt.GetComponent<Text>().text = PlayerPrefs.GetFloat("Height").ToString("0");
        if (PlayerPrefs.GetFloat("Height") > PlayerPrefs.GetFloat("BestScore"))
        {
            BestScore = PlayerPrefs.GetFloat("Height");
            PlayerPrefs.SetFloat("BestScore", BestScore);
            Bestscoretxt.GetComponent<Text>().text = PlayerPrefs.GetFloat("BestScore").ToString("0");
        }
        else { Bestscoretxt.GetComponent<Text>().text = PlayerPrefs.GetFloat("BestScore").ToString("0"); }
        for (i = 0; i < 4; i++)
            {
                rand();
            }
        /*  Debug.Log(Blocks.Length);
          for (i = 0; i < Blocks.Length; i++)
          {

              Randpos[i] = random.Next(0, Blocks.Length);
              Randomin[i] = random.Next(0, Blocks.Length);
              earlyR[i] = Randomin[i];
              earlyRP[i] = Randpos[i];

              //   if (Randpos[i] == earlyRP[j] && ch == true)
              // {
              //     Debug.Log("RP:"+earlyRP[j]);
              //     Randpos[i] = random.Next(0, Blocks.Length);
              //    Randpos[i] = random.Next(0, Blocks.Length);
              // }
              //    if (Randomin[i] == earlyR[j] && ch == true)
              //    {
              //        Debug.Log("Erl:"+earlyR[j]);
              //       Randomin[i] = random.Next(0, Blocks.Length);

          }
          for (i = 0; i < Blocks.Length; i++)
          {
              Debug.Log("RI:" + Randomin[i]);
              Debug.Log("RP:" + Randpos[i]);
              Debug.Log("ER:" + earlyR[i]);
              Debug.Log("ERP:" + earlyRP[i]);
          }
          for (i = 1; i < Blocks.Length; i++)
          {
              for (j = 0; j < Blocks.Length; j++)
              {
                      while (Randomin[i] == earlyR[j] && i!=j)
                      {
                          Randomin[i] = random.Next(0, Blocks.Length);
                          Debug.Log("WERE");
                      }
                      while (Randpos[i] == earlyRP[j] &&  i!= j)
                      {
                          Randpos[i] = random.Next(0, Blocks.Length);
                          Debug.Log("WERE2");
                      }
              }
          }
          for (i = 0; i < Blocks.Length; i++)
          {
              Debug.Log("RI:" + Randomin[i]);
              Debug.Log("RP:" + Randpos[i]);
              Debug.Log("ER:" + earlyR[i]);
              Debug.Log("ERP:" + earlyRP[i]);
          }*/
        for (i = 0; i < Blocks.Length; i++)
          {
              GameObject newBlock = Instantiate(Blocks[Randomin[i]]);
              newBlock.transform.position = new Vector3(Blocks[Randomin[i]].GetComponent<Transform>().position.x, Blocks[Randpos[i]].GetComponent<Transform>().position.y, 640);
              SpawnBlock.Add(newBlock);
          }
         

    }

    // Update is called once per frame
    void Update()
    {
        if (move.h >= k && move.h <= k + 0.1)
        {
            Debug.Log("speeddd");
            k += 100;
            speed -= 0.005f;
        }

            if (scoreM.activeSelf == false && PauseM.activeSelf == false && MAd.activeSelf == false) {
            for (i = 0; i < 4; i++)
            {
                SpawnBlock[i].GetComponent<Transform>().position += new Vector3(0f, speed, 0f);
                if (SpawnBlock[i].GetComponent<Transform>().position.y <= -1.0f)
                {
                    j[i] = random.Next(0, Blocks.Length);
                    Debug.Log(j[i]);
                    if (j[2] == j[1])
                    {
                        j[i] = random.Next(0, Blocks.Length);
                        //Debug.Log("Test");
                    }
                    GameObject newBlock = Instantiate(Blocks[j[i]]);
                    newBlock.transform.position = new Vector3(Blocks[j[i]].GetComponent<Transform>().position.x, 5.4f, 640);
                    SpawnBlock.Add(newBlock);
                    Destroy(SpawnBlock[i]);
                    SpawnBlock.Remove(SpawnBlock[i]);

                }
            }
            i = 0;
        }
    }
}

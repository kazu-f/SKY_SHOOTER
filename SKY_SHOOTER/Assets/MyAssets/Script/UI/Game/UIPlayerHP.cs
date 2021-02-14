using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerHP : MonoBehaviour
{
    public GameObject[] icons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //ライフに応じて表示する。
    public void UpdateLifeIcon(int life)
    {
        for(int i = 0;i<icons.Length;i++)
        {
            if(i < life)
            {
                icons[i].SetActive(true);
            }
            else
            {
                icons[i].SetActive(false);
            }
        }
    }
}

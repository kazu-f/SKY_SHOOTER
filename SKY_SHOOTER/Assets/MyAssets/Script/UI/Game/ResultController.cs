using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    public GameObject gameClear;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //ゲームオーバーを表記。
    public void ResultGameOver()
    {
        gameOver.SetActive(true);
    }
    //ゲームクリア―を表記。
    public void ResultGameClear()
    {
        gameClear.SetActive(true);
    }
}

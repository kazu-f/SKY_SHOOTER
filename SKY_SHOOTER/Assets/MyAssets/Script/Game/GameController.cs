using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerHP playerHP;
    public UIPlayerHP plHP_UI;
    public ResultController result;
    public float TitleReturnTime = 2.0f;

    bool BossClearFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //残機表示の更新
        plHP_UI.UpdateLifeIcon(playerHP.GetHP());

        if(playerHP.GetHP() <= 0)
        {
            //ゲームオーバー。
            result.ResultGameOver();
            EndGameScene();
        }
        else if (BossClearFlag)
        {
            //ゲームクリア―。
            result.ResultGameClear();
            EndGameScene();
        }
    }
    //タイトルへ戻る。
    void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    //ボスを倒した。
    public void EnableClearFlag()
    {
        BossClearFlag = true;
    }
    //ゲームシーンを終わる。
    void EndGameScene()
    {
        //Updateを止める。
        enabled = false;

        //2秒後にタイトルへ。
        Invoke("ReturnToTitle", TitleReturnTime);
    }
}

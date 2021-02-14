using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerHP playerHP;
    public UIPlayerHP plHP_UI;
    public float TitleReturnTime = 2.0f;
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
            //Updateを止める。
            enabled = false;

            //2秒後にタイトルへ。
            Invoke("ReturnToTitle", TitleReturnTime);
        }
    }
    //タイトルへ戻る。
    void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

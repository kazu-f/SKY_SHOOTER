using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlagController : MonoBehaviour
{
    public GameObject Boss;
    private GameController controller;
    private BossControlManager bossMgr;
    // Start is called before the first frame update
    void Start()
    {
        //ボスを作成する。
        GameObject go = Instantiate(
            Boss,
            Vector3.zero,
            Quaternion.identity
            );
        //一緒に削除されるように生成したものを子オブジェクトに設定
        go.transform.SetParent(transform, false);
        //ゲームコントローラーを探す。
        controller = FindObjectOfType<GameController>();
        //コントロールを取得。
        bossMgr = go.GetComponent<BossControlManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bossMgr.IsDead())
        {
            controller.EnableClearFlag();
            Destroy(gameObject);
        }
    }
}

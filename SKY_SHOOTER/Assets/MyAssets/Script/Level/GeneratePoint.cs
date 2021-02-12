using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePoint : MonoBehaviour
{
    public GameObject prefab;
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        //プレファブを座標に作成。
        GameObject go = Instantiate(
            prefab,
            Vector3.zero,
            Quaternion.identity
            );
        //一緒に削除されるように生成したものを子オブジェクトに設定
        go.transform.SetParent(transform,false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //ステージエディット中のためにシーンにギズモを表示
    void OnDrawGizmos()
    {
        //ギズモの底辺が地面と同じ高さになるようにオフセット設定。
        Vector3 offset = new Vector3(0.0f, 0.5f, 0.0f);

        //球を表示。
        color.a = 0.5f;
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position + offset, 5.5f);
        Gizmos.color = color;
        Gizmos.DrawRay(transform.position + offset, transform.forward * 10.0f);

        //プレファブ名のアイコンを表示。
        if(prefab != null)
        {
            Gizmos.DrawIcon(transform.position + offset, prefab.name, true);
        }

    }
}

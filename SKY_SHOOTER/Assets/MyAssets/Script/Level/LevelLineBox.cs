using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLineBox : MonoBehaviour
{
    public Vector3 BoxSize;
    public Color BoxColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    //ステージエディット中のためにシーンにギズモを表示
    void OnDrawGizmos()
    {
        Gizmos.color = BoxColor;
        //箱を描画する。
        Gizmos.DrawWireCube(transform.position, BoxSize);
    }
}

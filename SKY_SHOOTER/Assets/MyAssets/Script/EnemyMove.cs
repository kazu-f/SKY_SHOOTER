using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float MOVE_SPEED = 50.0f;          //移動速度。
    public Vector3 MOVE_DIRECTION = Vector3.back;   //移動方向。
    public float RETURN_DISTANCE = 50.0f;     //帰還し始めるプレイヤーとの距離。

    Transform playerTrans;                          //プレイヤーの位置情報。
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //方向だけを取るために単位ベクトル化。
        MOVE_DIRECTION.Normalize();
        //プレイヤーを見つけ出す。
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsNearDistance())
        {
            ReturnEnemy();
        }
        else
        {
            MoveEnemy();
        }
        //プレイヤーより後ろに行ったら消える。
        if(CalcDistance() < 0.0f)
        {
            Destroy(gameObject,1.0f);
        }
    }

    void MoveEnemy()
    {
        Vector3 vMove = MOVE_DIRECTION * MOVE_SPEED;

        rigidbody.velocity = vMove;
    }
    //近くまで来たらどこかへやる。
    void ReturnEnemy()
    {
        //帰っていく向きを決める。
        Vector3 returnDir = transform.position - playerTrans.position;
        returnDir.z = 0.0f;
        returnDir.Normalize();
        if (Math.Abs(returnDir.y) < 0.1f)
        {
            returnDir = Vector3.up;
        }
        returnDir.y *= 4.0f;
        returnDir += Vector3.back;
        returnDir.Normalize();

        //動かしていく。
        Vector3 vMove = returnDir * MOVE_SPEED;
        rigidbody.AddForce(vMove);
    }

    bool IsNearDistance()
    {
        float Distance = CalcDistance(); 

        return Distance < RETURN_DISTANCE;
    }

    float CalcDistance()
    {
        return transform.position.z - playerTrans.position.z;
    }
}

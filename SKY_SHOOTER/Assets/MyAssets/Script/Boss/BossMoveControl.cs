using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossMoveState;

public class BossMoveControl : MonoBehaviour
{
    public Vector2 MoveMaxPos;      //移動上限。
    public Vector2 MoveMinPos;      //移動下限。
    public float MOVE_SPEED;        //移動速度。
    public float MOVE_SECONDS;      //移動時間。
    public float IDLE_SECONDS;      //待機時間。

    private Vector2 MovePos;        //移動先の座標。
    private Rigidbody rigidbody;    //剛体。
    private IBossMoveState currentState = null;
    private IBossMoveState[] m_States;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //ステートを初期化。
        m_States = new IBossMoveState[(int)EnBossMoveState.enStateNum]
        {
            new BossMoveStateIdle(this),
            new BossMoveStateMove(this),
            new BossMoveStateMoveDist(this)
        };
        //待機ステート。
        ChangeState(EnBossMoveState.enStateIdle);
    }

    // Update is called once per frame
    void Update()
    {
        //移動に関する処理を行う。
        currentState.Execute();
    }
    //移動先の座標を設定。
    public void SetMovePos(Vector2 pos)
    {
        MovePos = pos;
    }
    //移動先の座標を取得。
    public Vector2 GetMovePos()
    {
        return MovePos;
    }
    /// <summary>
    /// 移動する。
    /// </summary>
    /// <param name="vMove">移動ベクトル。</param>
    public void MovePosition(Vector2 vMove)
    {
        rigidbody.velocity = vMove;     //移動。
    }
    /// <summary>
    /// 座標を動かす。
    /// </summary>
    /// <param name="pos">座標。</param>
    public void SetPosition(Vector2 pos)
    {
        rigidbody.position = pos;
        transform.position = pos;
    }
    //ステートを切り替える。
    public void ChangeState(EnBossMoveState state)
    {
        if(currentState != null)
        {
            //事後処理。
            currentState.Leave();
        }
        //変更。
        currentState = m_States[(int)state];
        //事前処理。
        currentState.Enter();
    }
    //ショットを撃てるか？
    public bool IsShot()
    {
        return currentState.IsShot();
    }
}

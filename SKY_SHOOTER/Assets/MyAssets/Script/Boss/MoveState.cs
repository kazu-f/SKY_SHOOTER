using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossMoveState 
{
    public enum EnBossMoveState 
    { 
        enStateIdle,
        enStateMove,
        enStateMoveDist,
        enStateNum
    }

    //ステートクラス。
    abstract class IBossMoveState 
    {
        protected BossMoveControl bossMove;

        public IBossMoveState(BossMoveControl con)
        {
            bossMove = con;
        }
        //事前処理。
        public abstract void Enter();
        //事後処理。
        public abstract void Leave();
        //実行処理。
        public abstract void Execute();
        //ショットを打てるかどうか。
        public abstract bool IsShot();
    }

    //待機ステート。
    class BossMoveStateIdle : IBossMoveState
    {
        private float currentTime = 0.0f;       //経過時間。
        public BossMoveStateIdle(BossMoveControl con):
            base(con)
        {
        }
        //事前処理。
        public override void Enter()
        {
            currentTime = 0.0f;
        }
        //事後処理。
        public override void Leave()
        {
        }
        //実行処理。
        public override void Execute()
        {
            currentTime += Time.deltaTime;
            if(currentTime > bossMove.IDLE_SECONDS)
            {
                //ステートを切り替える。
                bossMove.ChangeState(EnBossMoveState.enStateMoveDist);
            }
        }
        //ショットを撃てる。
        public override bool IsShot()
        {
            return true;
        }
    }

    //移動ステート。
    class BossMoveStateMove : IBossMoveState
    {
        private Vector2 MovePos;                //移動先の座標。
        private Vector2 DistMoveDir;                //移動方向。
        private float MoveSpeed;                //移動速度。
        private float MoveCoefficient = 0.0f;   //移動の補完係数。
        public BossMoveStateMove(BossMoveControl con):
            base(con)
        {
        }

        //事前処理。
        public override void Enter()
        {
            MovePos = bossMove.GetMovePos();
            DistMoveDir.x = MovePos.x - bossMove.transform.position.x;
            DistMoveDir.y = MovePos.y - bossMove.transform.position.y;
            DistMoveDir.Normalize();
            MoveSpeed = bossMove.MOVE_SPEED;

            MoveCoefficient = 0.0f;
        }
        //事後処理。
        public override void Leave()
        {
        }
        //実行処理。
        public override void Execute()
        {
            MoveCoefficient += Time.deltaTime * (1.0f / bossMove.MOVE_SECONDS);     //補間係数を進める。
            if(MoveCoefficient> 1.0f)
            {
                MoveCoefficient = 1.0f;     //1.0に定める。
            }
            //現在の速度を求める。
            float speed = Mathf.Lerp(0.0f, MoveSpeed, MoveCoefficient);

            Vector2 currentPos = bossMove.gameObject.transform.position; //現在座標。
            Vector2 vMoveDir = MovePos - currentPos;                       //移動方向のベクトル。
            vMoveDir.Normalize();

            //移動方向が逆。
            if (Vector2.Dot(DistMoveDir, vMoveDir) < 0.0f) 
            {
                bossMove.MovePosition(Vector2.zero);
                bossMove.SetMovePos(MovePos);
                //ステートを切り替える。
                bossMove.ChangeState(EnBossMoveState.enStateIdle);

                return;
            }

            //移動速度を出す。
            Vector2 vMove = vMoveDir * speed;

            bossMove.MovePosition(vMove);
        }
        //ショットを撃てる。
        public override bool IsShot()
        {
            return false;
        }
    }

    //移動先決定ステート。
    class BossMoveStateMoveDist : IBossMoveState
    {
        private Vector2 oldRand = new Vector2(0.5f,0.5f);       //元の座標係数。

        public BossMoveStateMoveDist(BossMoveControl con):
            base(con)
        {
        }

        //事前処理。
        public override void Enter()
        {
        }
        //事後処理。
        public override void Leave()
        {
        }
        //実行処理。
        //移動先を決定する。
        public override void Execute()
        {
            //乱数で0.0～1.0の間の値を取得。
            Vector2 vRand;
            vRand.x = UnityEngine.Random.value;
            vRand.y = UnityEngine.Random.value;
            //ある程度離れた位置を指定する。
            while (Vector2.Distance(vRand, oldRand) < 0.3f)
            {
                vRand.x = UnityEngine.Random.value;
                vRand.y = UnityEngine.Random.value;
            }

            //移動先の座標を指定する。
            Vector2 resPos;
            resPos.x = Mathf.Lerp(bossMove.MoveMinPos.x, bossMove.MoveMaxPos.x, vRand.x);
            resPos.y = Mathf.Lerp(bossMove.MoveMinPos.y, bossMove.MoveMaxPos.y, vRand.y);

            bossMove.SetMovePos(resPos);

            oldRand = vRand;

            bossMove.ChangeState(EnBossMoveState.enStateMove);
        }
        //ショットを撃てる。
        public override bool IsShot()
        {
            return false;
        }
    }
}

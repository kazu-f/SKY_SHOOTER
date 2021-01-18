using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Linq;
using UnityEditor;

public class LockOnTarget : MonoBehaviour
{

    private const int MAX_INDEX = 8;
    private Vector3[] m_oldVecArray = new Vector3[MAX_INDEX];
    private int m_index = 0;
    private Vector3 m_vector = new Vector3(0.0f, 0.0f, 1.0f);

    private GameObject TargetObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AddVector();
        CalcVector();
        DistTarget();
    }
    //ベクトルの追加。
    private void AddVector()
    {
        //ベクトルを作成。
        Vector3 vec = new Vector3(0.0f, 0.0f, 1.0f);
        if (CrossPlatformInputManager.GetButton("LeftButton"))
        {
            vec.x = -1.0f;
        }
        if (CrossPlatformInputManager.GetButton("RightButton"))
        {
            vec.x = 1.0f;
        }
        if (CrossPlatformInputManager.GetButton("DownButton"))
        {
            vec.y = -1.0f;
        }
        if (CrossPlatformInputManager.GetButton("UpButton"))
        {
            vec.y = 1.0f;
        }
        vec.Normalize();
        //記録。
        m_oldVecArray[m_index] = vec;

        //数値を進める。
        m_index = (m_index + 1) % MAX_INDEX;
    }
    //ターゲットを探す方向ベクトルを計算する。
    private void CalcVector()
    {
        //ベクトルを平均化。
        Vector3 vec = new Vector3(0.0f,0.0f,0.0f);
        for(int i = 0;i<MAX_INDEX;i++)
        {
            vec += m_oldVecArray[i];
        }
        vec.Normalize();

        m_vector = vec;
    }
    //ターゲットを決定する。
    private void DistTarget()
    {
        const float LENGTH = 30.0f;
        float minLen = float.MaxValue;
        const float MAXDISTANCE = 500.0f;
        GameObject Target = null;
        //敵を全て取得。
        var enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(var Ene in enemys)
        {
            //必要なパラメータを作成。
            Vector3 ePos = Ene.transform.position;
            Vector3 toEne = ePos - transform.position;
            //軌道上との距離を測る。
            float distance = Vector3.Dot(m_vector, toEne);
            //距離の除外。
            if(distance > MAXDISTANCE
                || distance < 0.0f)
            {
                continue;
            }
            //軌道上の座標を求める。
            Vector3 rayPos = m_vector * distance + transform.position;
            float len = Vector3.Distance(rayPos, ePos);
            //距離が一定以下。
            if(len < LENGTH
                &&len < minLen)
            {
                Target = Ene.gameObject;
                minLen = len;
            }
        }

        //コライダーに衝突する。
        if(Target != null)
        {
            var enemyMove = Target;
            TargetObject = enemyMove.gameObject;
        }
        else
        {
            TargetObject = null;
        }
    }
    //ターゲットを取得。
    public GameObject GetTarget()
    {
        return TargetObject;
    }
}

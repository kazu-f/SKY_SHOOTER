using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Linq;

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
        //レイを飛ばす。
        Ray shotRay = new Ray(transform.position, m_vector);    //レイ。
        RaycastHit hit;                                         //レイの衝突したオブジェクト。
        const int distance = 500;                               //レイを飛ばす距離。
        const int radius = 20;                                  //レイの球体の半径。

        float minLen = float.MaxValue;
        Collider colTarget = null;
        if(Physics.SphereCast(transform.position,radius, m_vector, out hit, distance))
        {
            //Rayが当たったオブジェクトのタグを調べる。
            if (hit.collider.tag == "EnemyCollider")
            {
                //距離を測る。
                float len = Vector3.Distance(hit.collider.transform.position, hit.point);
                //距離がより近いほうを検索。
                if(len < minLen)
                {
                    colTarget = hit.collider;
                    minLen = len;
                }
            }
        }
        //コライダーに衝突する。
        if(colTarget != null)
        {
            var enemyMove = colTarget.gameObject.GetComponentInParent<EnemyMove>();
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

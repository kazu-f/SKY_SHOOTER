using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IHPControl : MonoBehaviour
{
    public int m_HP = 3;
    public string BulletTag;

    protected Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == BulletTag)
        {
            //HPを減らす。
            Damage();

            //当たった弾を消しておく。
            Destroy(other.gameObject);

            //HPが0になったか？
            if (IsDead())
            {
                DeathAircraft();
            }
        }
    }

    //ダメージを受ける。
    protected abstract void Damage();
    //消す処理。
    protected abstract void DeathAircraft();

    //HPが0以下になったかどうか。
    protected bool IsDead()
    {
        return m_HP <= 0;
    }
}

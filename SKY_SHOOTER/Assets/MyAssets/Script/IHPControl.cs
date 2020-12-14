using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IHPControl : MonoBehaviour
{
    public int m_HP = 3;

    protected Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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

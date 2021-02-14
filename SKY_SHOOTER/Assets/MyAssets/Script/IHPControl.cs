using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IHPControl : MonoBehaviour
{
    public int m_HP = 3;
    public string BulletTag;
    public GameObject Damage_Particle;
    public GameObject Death_Particle;

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
            //エフェクトを再生。
            DamageEffect(other.transform.position);

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
    //ダメージのエフェクトを出す。
    protected void DamageEffect(Vector3 pos)
    {
        //エフェクトを生成。
        Instantiate(
            Damage_Particle,
            pos,
            Quaternion.identity
            );
    }
    //死亡時のエフェクトを出す。
    protected void DeathEffect()
    {
        //エフェクトを生成。
        Instantiate(
            Death_Particle,
            transform.position,
            Quaternion.identity
            );
    }
    //消す処理。
    protected abstract void DeathAircraft();

    //HPが0以下になったかどうか。
    protected bool IsDead()
    {
        return m_HP <= 0;
    }
    //HPを取得。
    public int GetHP()
    {
        return m_HP;
    }
}

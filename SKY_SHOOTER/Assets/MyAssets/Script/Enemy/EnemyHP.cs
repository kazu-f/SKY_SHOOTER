using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int m_HP = 3;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PBullet")
        {
            //HPを減らす。
            m_HP--;

            //当たった弾を消しておく。
            Destroy(other.gameObject);

            //HPが0になったか？
            if (IsDead())
            {
                DeathEnemy();
            }
        }
    }
    //Enemyを消す処理。
    void DeathEnemy()
    {
        Destroy(gameObject);
    }
    //HPが0以下になったかどうか。
    bool IsDead()
    {
        return m_HP <= 0;
    }
}

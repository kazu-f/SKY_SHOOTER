using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : IHPControl
{
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EBullet")
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
    protected override void Damage()
    {
        m_HP--;
    }
    //Playerを消す処理。
    protected override void DeathAircraft()
    {
        Destroy(gameObject);
    }
}

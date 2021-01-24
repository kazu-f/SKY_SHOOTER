using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : IHPControl
{
    // Update is called once per frame
    void Update()
    {
        
    }

    //ダメージを受ける。
    protected override void Damage()
    {
        m_HP--;
    }
    //Bossを消す処理。
    protected override void DeathAircraft()
    {
        Destroy(gameObject);
    }
}

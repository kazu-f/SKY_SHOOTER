using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : IHPControl
{
    public float CoolTime = 3.0f;
    float currentTime = 0.0f;
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
    }

    //ダメージを受ける。
    protected override void Damage()
    {
        if (IsDamageCoolTime())
        {
            m_HP--;
            currentTime = 0.0f;
        }
    }
    //Playerを消す処理。
    protected override void DeathAircraft()
    {
        DeathEffect();
        Destroy(gameObject);
    }

    //ダメージ後無敵中か？
    public bool IsDamageCoolTime()
    {
        return CoolTime < currentTime;
    }
}

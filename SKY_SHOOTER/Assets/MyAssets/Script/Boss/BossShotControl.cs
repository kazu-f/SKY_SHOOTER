using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotControl : ShotControl
{
    public Transform[] SHOT_POINT;
    private Transform playerTransform;
    bool isShot = false;
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーを見つけ出す。
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (CountInterval()
            && isShot
            && playerTransform != null)
        {
            Shot();
        }
    }

    protected override void Shot()
    {
        //弾を撃つ方向を決める。
        //Vector3 vDir = playerTransform.position - SHOT_POINT[0].position;
        //vDir.Normalize();

        //全ての発射点から撃つ。
        foreach (var trans in SHOT_POINT)
        {
            GameObject bullet = Instantiate(
                BulletObject,
                trans.position,
                Quaternion.identity
                );

            Vector3 vDir = playerTransform.position - trans.position;
            vDir.Normalize();
            var bulletComp = bullet.GetComponent<Bullet>();
            bulletComp.SetDirection(vDir);
        }

        currentInterval = ShotInterval;
    }

    public void SetShotFlag(bool flag)
    {
        isShot = flag;
    }
}

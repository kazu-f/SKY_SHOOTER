using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotControl : ShotControl
{
    public Transform[] SHOT_POINT;
    public float[] ShotDegX;
    public float[] ShotDegY;
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

        Vector3 vDir = playerTransform.position - SHOT_POINT[0].position;
        //全ての発射点から撃つ。
        foreach (var trans in SHOT_POINT)
        {
            vDir.Normalize();
            for(int i = 0;i<ShotDegX.Length;i++)
            {
                for(int j = 0;j<ShotDegY.Length;j++)
                {
                    GenerateShot(trans.position, vDir, ShotDegX[i], ShotDegY[j]);
                }
            }
        }

        currentInterval = ShotInterval;
    }
    //角度をつけてショットする。
    void GenerateShot(Vector3 pos,Vector3 baseDir,float degX,float degY)
    {
        GameObject bullet = Instantiate(
            BulletObject,
            pos,
            Quaternion.identity
            );
        //角度をつける。
        Vector3 result = Quaternion.Euler(degY, degX, 0) * baseDir;
        result.Normalize();

        Quaternion bulletRot = new Quaternion();
        bulletRot.SetLookRotation(result);
        bullet.transform.rotation = bulletRot;

        var bulletComp = bullet.GetComponent<Bullet>();
        bulletComp.SetDirection(result);
    }

    public void SetShotFlag(bool flag)
    {
        isShot = flag;
    }
}

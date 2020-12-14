using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShotControl : ShotControl
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CountInterval()
            && CrossPlatformInputManager.GetButton("Fire1"))
        {
            Shot();
        }
    }

    protected override void Shot()
    {
        GameObject bullet = Instantiate(
            BulletObject,
            transform.position,
            Quaternion.identity
            );

        var bulletComp = bullet.GetComponent<Bullet>();
        Vector3 vDir = new Vector3(0.0f, 0.0f, 1.0f);
        bulletComp.SetDirection(vDir);

        currentInterval = ShotInterval;
    }
}

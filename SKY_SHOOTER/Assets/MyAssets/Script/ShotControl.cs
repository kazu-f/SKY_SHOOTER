using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShotControl : MonoBehaviour
{
    public GameObject BulletObject;
    public float ShotInterval = 2.0f;
    protected float currentInterval = 0.0f;


    protected abstract void Shot();

    //ショットの間隔を開ける
    protected bool CountInterval()
    {
        currentInterval -= Time.deltaTime;
        if (currentInterval < 0.0f)
        {
            return true;
        }

        return false;
    }
}

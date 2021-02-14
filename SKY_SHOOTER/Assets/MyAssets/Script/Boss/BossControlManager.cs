using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControlManager : MonoBehaviour
{
    public BossMoveControl moveControl;
    public BossShotControl shotControl;
    public BossHP          hpControl;

    public float IdleTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitingTime(IdleTime));
    }

    // Update is called once per frame
    void Update()
    {
        if(hpControl.GetHP() > 0)
        {
            shotControl.SetShotFlag(moveControl.IsShot());
        }
        else
        {

        }
    }
    IEnumerator WaitingTime(float time)
    {
        moveControl.enabled = false;
        shotControl.enabled = false;
        hpControl.enabled = false;
        yield return new WaitForSeconds(time);
        moveControl.enabled = true;
        shotControl.enabled = true;
        hpControl.enabled = true;
    }
    public bool IsDead()
    {
        return hpControl.GetHP() <= 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControlManager : MonoBehaviour
{
    public BossMoveControl moveControl;
    public BossShotControl shotControl;
    public BossHP          hpControl;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hpControl.m_HP > 0)
        {
            shotControl.SetShotFlag(moveControl.IsShot());
        }
        else
        {

        }
    }
}

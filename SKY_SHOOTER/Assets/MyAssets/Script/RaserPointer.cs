using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaserPointer : MonoBehaviour
{
    public Color TargetColor;
    public float LINE_WEIDTH = 0.5f;
    private LockOnTarget m_lockOn;
    private LineRenderer raserPointer;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<LineRenderer>();
        raserPointer = GetComponent<LineRenderer>();
        m_lockOn = gameObject.GetComponent<LockOnTarget>();
        raserPointer.startWidth = LINE_WEIDTH;
        raserPointer.endWidth = LINE_WEIDTH;
        raserPointer.material = new Material(Shader.Find("Sprites/Default"));
        raserPointer.startColor = TargetColor;
        raserPointer.endColor = TargetColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_lockOn == null) return;
        if (m_lockOn.GetTarget() == null)
        {
            DisableRaserPointer();
            return;
        }
        else
        {
            EnableRaserPointer();
        }
        Vector3 enemyPos = m_lockOn.GetTarget().transform.position;
        //ラインを引く。
        raserPointer.SetPosition(0, transform.position);
        raserPointer.SetPosition(1, enemyPos);
    }
    //レーザーポインターを表示する。
    public void EnableRaserPointer()
    {
        raserPointer.enabled = true;
    }
    //レーザーポインターを非表示にする。
    public void DisableRaserPointer()
    {
        raserPointer.enabled = false;
    }
}

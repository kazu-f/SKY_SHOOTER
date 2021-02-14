using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaserPointer : MonoBehaviour
{
    public Renderer AIMTargetRenderer;
    public Color TargetLineColor;
    public Color TargetColor;
    public Color IdleLineColor;
    public Color IdleColor;
    public float LINE_WEIDTH = 0.5f;
    private LockOnTarget m_lockOn;
    private LineRenderer raserPointer;
    private Renderer AIMTarget;

    // Start is called before the first frame update
    void Start()
    {
        //照準を作成。
        AIMTarget = Instantiate(AIMTargetRenderer, transform);
        gameObject.AddComponent<LineRenderer>();
        raserPointer = GetComponent<LineRenderer>();
        m_lockOn = gameObject.GetComponent<LockOnTarget>();
        raserPointer.startWidth = LINE_WEIDTH;
        raserPointer.endWidth = LINE_WEIDTH;
        raserPointer.material = new Material(Shader.Find("Sprites/Default"));
    }

    // Update is called once per frame
    void Update()
    {
        if (m_lockOn == null) return;
        if (m_lockOn.GetTarget() == null)
        {
            const float Distance = 140.0f;
            Vector3 targetPos = transform.position + transform.forward * Distance;
            Vector3 LineEndPos = transform.position + transform.forward * Distance * 0.8f;
            //ラインを引く。
            raserPointer.SetPosition(0, transform.position);
            raserPointer.SetPosition(1, LineEndPos);
            raserPointer.startColor = IdleLineColor;
            raserPointer.endColor = IdleLineColor;

            //照準を表示する。
            AIMTarget.transform.position = targetPos;

            AIMTarget.material.color = IdleColor;
        }
        else
        {
            Vector3 enemyPos = m_lockOn.GetTarget().transform.position;
            Vector3 LineDir = enemyPos - transform.position;    //向き。
            float Length = LineDir.magnitude;                   //距離。
            LineDir.Normalize();
            Vector3 LineEndPos = transform.position + LineDir * Length * 0.8f;
            //ラインを引く。
            raserPointer.SetPosition(0, transform.position);
            raserPointer.SetPosition(1, LineEndPos);
            raserPointer.startColor = TargetLineColor;
            raserPointer.endColor = TargetLineColor;

            //照準を表示する。
            AIMTarget.transform.position = enemyPos;

            AIMTarget.material.color = TargetColor;
        }
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

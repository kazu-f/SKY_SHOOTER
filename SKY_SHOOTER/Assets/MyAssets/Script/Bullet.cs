using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MOVE_SPEED;
    Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        //moveDir = new Vector3(0.0f,0.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(
            moveDir.x * MOVE_SPEED,
            moveDir.y * MOVE_SPEED,
            moveDir.z * MOVE_SPEED
            );
    }

    public void SetDirection(Vector3 vDir)
    {
        moveDir = vDir;
    }
}

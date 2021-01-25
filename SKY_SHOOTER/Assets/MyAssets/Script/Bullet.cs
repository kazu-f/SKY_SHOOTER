using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MOVE_SPEED;
    Vector3 moveDir;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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

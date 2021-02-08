using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveController : MonoBehaviour
{
    public float MOVE_SPEED = 50.0f;
    public float MOVE_Z;
    public Vector2 MOVE_MAXPOS;
    public Vector2 MOVE_MINPOS;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();

    }

    void CharacterMove()
    {
        Vector3 vMove = new Vector3(0, 0, 0);

        if (CrossPlatformInputManager.GetButton("LeftButton"))
        {
            vMove.x = -MOVE_SPEED;
        }
        if (CrossPlatformInputManager.GetButton("RightButton"))
        {
            vMove.x = MOVE_SPEED;
        }
        if (CrossPlatformInputManager.GetButton("DownButton"))
        {
            vMove.y = -MOVE_SPEED;
        }
        if (CrossPlatformInputManager.GetButton("UpButton"))
        {
            vMove.y = MOVE_SPEED;
        }
        vMove.z = MOVE_Z;

        //vMove.x = MOVE_SPEED * CrossPlatformInputManager.GetAxis("Horizontal");
        //vMove.y = MOVE_SPEED * CrossPlatformInputManager.GetAxis("Vertical");

        Rigidbody rigi = GetComponent<Rigidbody>();
        rigi.velocity = vMove;

        MoveLimits();
    }

    void MoveLimits()
    {
        Vector3 newPos;
        newPos.x = Mathf.Clamp(transform.position.x, MOVE_MINPOS.x, MOVE_MAXPOS.x);
        newPos.y = Mathf.Clamp(transform.position.y, MOVE_MINPOS.y, MOVE_MAXPOS.y);
        newPos.z = transform.position.z;

        transform.position = newPos;
    }
}

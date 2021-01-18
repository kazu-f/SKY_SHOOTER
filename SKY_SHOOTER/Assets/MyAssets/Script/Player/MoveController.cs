using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveController : MonoBehaviour
{
    public float MOVE_SPEED = 50.0f;
    public float MOVE_Z;


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

        //vMove.x = MOVE_SPEED * CrossPlatformInputManager.GetAxis("Horizontal");
        //vMove.y = MOVE_SPEED * CrossPlatformInputManager.GetAxis("Vertical");

        Rigidbody rigi = GetComponent<Rigidbody>();
        rigi.velocity = vMove;
    }
}

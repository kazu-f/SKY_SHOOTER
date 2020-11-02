using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float MOVE_SPEED;
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
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            vMove.x = -MOVE_SPEED;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            vMove.x = MOVE_SPEED;
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            vMove.y = MOVE_SPEED;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            vMove.y = -MOVE_SPEED;
        }

        Rigidbody rigi = GetComponent<Rigidbody>();
        rigi.velocity = vMove;
    }
}

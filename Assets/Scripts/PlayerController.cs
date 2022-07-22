using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //public GameObject self;
    public float speed = 0;
    public float degree = 10;
    private float movementX;
    private float movementY;
    public float timeCount = 0.0f;
    private Vector3 transitionVector;

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        //if (Lib.isPositive(movementVector.x))
        //{
        //    rightKeyPressed = true;
        //}
        //if (Lib.isNegative(movementVector.x))
        //{
        //    leftKeyPressed = false;
        //}
        //if (Lib.isZero(movementVector.x))
        //{
        //    leftKeyPressed = false;
        //    rightKeyPressed = false;
        //}
        //if (Lib.isPositive(movementVector.y))
        //{
        //    upKeyPressed = true;
        //}
        //if (Lib.isNegative(movementVector.y))
        //{
        //    downKeyPressed = false;
        //}
        //if (Lib.isZero(movementVector.y))
        //{
        //    upKeyPressed = false;
        //    downKeyPressed = false;
        //}

        movementX = movementVector.x;
        movementY = movementVector.y;
        Debug.Log("movementX: " + movementX + ", movementY: " + movementY);
        Debug.Log(movementValue.Get());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rigid = GetComponent<Rigidbody>();

        //currentFrameCount++;
        Vector3 movement = new Vector3(movementX, 0.0f, movementY) * 2;
        if (movement == transitionVector)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Lib.VectorToQuadernion(movement), timeCount);
            rigid.rotation = Quaternion.Lerp(transform.rotation, Lib.VectorToQuadernion(movement * 3), timeCount * speed);
            //rigid.AddRelativeTorque(Quaternion.Lerp(transform.rotation, Lib.VectorToQuadernion(movement), timeCount * speed));
            //rigid.AddRelativeTorque(movement);
            timeCount = timeCount + Time.deltaTime;
        }
        else
        {
            transitionVector = movement;
            timeCount = 0.0f;
        }
        //transform.eulerAngles = (movement * speed) / 2f;
    }
}

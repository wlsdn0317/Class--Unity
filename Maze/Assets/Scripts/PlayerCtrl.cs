using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    public float sensitivity = 500f;

    float rotationX = 0.0f;
    float rotationY = 0.0f;

    float hAxis;
    float vAxis;

    CharacterController player;
    Vector3 moveVec;
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (player.isGrounded)
        {
            hAxis = Input.GetAxisRaw("Horizontal");
            vAxis = Input.GetAxisRaw("Vertical");

            moveVec = new Vector3(hAxis, 0, vAxis).normalized;
            moveVec = transform.TransformDirection(moveVec);
            moveVec *= speed;
        }
        player.Move(moveVec * Time.deltaTime);

        MouseSencer();
    }

    void MouseSencer()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        rotationX += x * sensitivity * Time.deltaTime;
        rotationY += y * sensitivity * Time.deltaTime;

        if (rotationY > 30)
        {
            rotationY = 30;
        }
        else if (rotationY < -30)
        {
            rotationY = -30;
        }
        transform.eulerAngles = new Vector3(-rotationY, rotationX, 0.0f);
    }
}

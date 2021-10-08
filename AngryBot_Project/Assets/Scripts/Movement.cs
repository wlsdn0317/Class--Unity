using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class Movement : MonoBehaviourPunCallbacks
{
    CharacterController controller;
    Transform transform;
    Animator animator;
    Camera camera;

    Plane plane;
    Ray ray;
    Vector3 hitPoint;

    public float moveSpeed = 10f;

    PhotonView pv; //포톤뷰 컴포넌트 캐시 처리위한 변수
    CinemachineVirtualCamera virtualCamera;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        camera = Camera.main;

        pv = GetComponent<PhotonView>();
        virtualCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();

        if (pv.IsMine) //내것인지 남것인지 판단
        {
            //내거에 카메라 초점을 맞차라
            virtualCamera.Follow = transform;
            virtualCamera.LookAt = transform;
        }

        //가상의 바닥을 플레이어의 위치를 기준으로 생성
        plane = new Plane(transform.up, transform.position);
    }

    float h => Input.GetAxis("Horizontal");
    float v => Input.GetAxis("Vertical");

    private void Move()
    {
        Vector3 cameraForward = camera.transform.forward;
        Vector3 cameraRight = camera.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        Vector3 moveDir = (cameraForward * v) + (cameraRight * h);
        moveDir.Set(moveDir.x, 0f, moveDir.z);

        controller.SimpleMove(moveDir * moveSpeed);

        float forward = Vector3.Dot(moveDir, transform.forward);
        float strafe = Vector3.Dot(moveDir, transform.right);

        animator.SetFloat("Forward", forward);
        animator.SetFloat("Strafe", strafe);
    }

    void Turn()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        float enter = 0f;
        plane.Raycast(ray, out enter);
        hitPoint = ray.GetPoint(enter);

        Vector3 lookDir = hitPoint - transform.position;
        lookDir.y = 0;
        transform.localRotation = Quaternion.LookRotation(lookDir);

    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine) //내것인지 남것인지 판단
        {
            Move();
            Turn();
        }
    }
}

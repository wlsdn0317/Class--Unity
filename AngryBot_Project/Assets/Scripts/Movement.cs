using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class Movement : MonoBehaviourPunCallbacks, IPunObservable
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

    //수신된 데이터
    Vector3 receivePos;
    Quaternion receiveRot;
    //수신된 좌표로 이동 및 회전할 속도
    public float damping = 10f;

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
        else //남의것의 경우 수신된 데이터로 조작해줘야됨
        {
            transform.position = Vector3.Lerp(transform.position, receivePos, Time.deltaTime * damping);
            transform.rotation = Quaternion.Slerp(transform.rotation, receiveRot, Time.deltaTime * damping);
        }
    }

    //데이터 송/수신에 쓰이는 콜백 함수
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //본인 캐릭터인 경우 자신의 데이터를 다른 유저에게 송신
        if (stream.IsWriting) //송신
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else //수신
        {
            receivePos = (Vector3)stream.ReceiveNext();
            receiveRot = (Quaternion)stream.ReceiveNext();
        }
        //int a = 5;
        //int b = 0;

        //try
        //{
        //    print(a / b); //컴퓨터가 실행은 되지만
        //}
        //catch (System.Exception e)
        //{
        //    //Exception 클래스는 가장 대장
        //    //모든 문제점을 포함하고 있는 카테고리
        //    //하위에 세세한 문제점들이 개별 명시되어있음
        //}

        //finally
        //{
        //    //예외가 발생하든 안하든 무조건 실행하는 것
        //}
        //에러가 발생한다고 = 블루스크린 같은거(런타임 에러)
        //실시간 에러가 발생 >>대처가 필요
        //try(문제가 발생할 코드를 집어넣고)
        //catch(해결 방법 또는 대처 방법)
    }
}

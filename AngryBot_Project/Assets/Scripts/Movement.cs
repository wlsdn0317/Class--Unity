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

    PhotonView pv; //����� ������Ʈ ĳ�� ó������ ����
    CinemachineVirtualCamera virtualCamera;

    //���ŵ� ������
    Vector3 receivePos;
    Quaternion receiveRot;
    //���ŵ� ��ǥ�� �̵� �� ȸ���� �ӵ�
    public float damping = 10f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        camera = Camera.main;

        pv = GetComponent<PhotonView>();
        virtualCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();

        if (pv.IsMine) //�������� �������� �Ǵ�
        {
            //���ſ� ī�޶� ������ ������
            virtualCamera.Follow = transform;
            virtualCamera.LookAt = transform;
        }

        //������ �ٴ��� �÷��̾��� ��ġ�� �������� ����
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
        if (pv.IsMine) //�������� �������� �Ǵ�
        {
            Move();
            Turn();
        }
        else //���ǰ��� ��� ���ŵ� �����ͷ� ��������ߵ�
        {
            transform.position = Vector3.Lerp(transform.position, receivePos, Time.deltaTime * damping);
            transform.rotation = Quaternion.Slerp(transform.rotation, receiveRot, Time.deltaTime * damping);
        }
    }

    //������ ��/���ſ� ���̴� �ݹ� �Լ�
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //���� ĳ������ ��� �ڽ��� �����͸� �ٸ� �������� �۽�
        if (stream.IsWriting) //�۽�
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else //����
        {
            receivePos = (Vector3)stream.ReceiveNext();
            receiveRot = (Quaternion)stream.ReceiveNext();
        }
        //int a = 5;
        //int b = 0;

        //try
        //{
        //    print(a / b); //��ǻ�Ͱ� ������ ������
        //}
        //catch (System.Exception e)
        //{
        //    //Exception Ŭ������ ���� ����
        //    //��� �������� �����ϰ� �ִ� ī�װ�
        //    //������ ������ ���������� ���� ��õǾ�����
        //}

        //finally
        //{
        //    //���ܰ� �߻��ϵ� ���ϵ� ������ �����ϴ� ��
        //}
        //������ �߻��Ѵٰ� = ��罺ũ�� ������(��Ÿ�� ����)
        //�ǽð� ������ �߻� >>��ó�� �ʿ�
        //try(������ �߻��� �ڵ带 ����ְ�)
        //catch(�ذ� ��� �Ǵ� ��ó ���)
    }
}

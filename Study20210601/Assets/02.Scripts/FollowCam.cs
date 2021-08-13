using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; //ī�޶� ������ ���
    public float moveDamping = 15f; //�̵��ӵ� ���
    public float rotateDamping = 10f;//ȸ���ӵ� ���
    public float distance = 5f;//���� ������ �Ÿ�
    public float height = 4f;//���� ������ ����
    public float targetOffset = 2f;//���� ��ǥ�� ������

    Transform tr;

    [Header("�� ��ֹ� ����")]
    public float heightAboveWall = 7f;
    public float colliderRadius = 1.8f;
    public float overDamping = 5f;
    public float originHeight;
    void Start()
    {
        tr = GetComponent<Transform>();
        originHeight = height;
    }

    private void Update()
    {
        //��ü ������ �浹ü�� �浹 ���� �˻�
        if (Physics.CheckSphere(tr.position, colliderRadius))
        {
            height = Mathf.Lerp(height, heightAboveWall, Time.deltaTime * overDamping);
        }
        else
        {
            height = Mathf.Lerp(height, originHeight, Time.deltaTime * overDamping);
        }
    }

    //�ݹ��Լ� - ȣ���� �������� �ʾƵ� �˾Ƽ� �۵��ϴ� �Լ�
    //�̺�Ʈ Ʈ���� �� �������� ������ ����.
    void LateUpdate()
    {
        var camPos = target.position
                               - (target.forward * distance)
                               + (target.up * height);
        tr.position = Vector3.Slerp(tr.position,
                                                    camPos,
                                                    Time.deltaTime * moveDamping);
        tr.rotation = Quaternion.Slerp(tr.rotation,
                                                         target.rotation,
                                                         Time.deltaTime * rotateDamping);
        //������ �߹ٴ��� �Ĵٺ��� ī�޶� �����¸�ŭ ����(������)�� ������ ����
        tr.LookAt(target.position + (target.up * targetOffset));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //DrawWireSphere(��ġ, ����)
        //������ �̷���� ������ ����� �׸�(���信�� ǥ�õ�, ����׿�)
        Gizmos.DrawWireSphere(target.position + (target.up * targetOffset), 
                                                0.1f);
        //���� ī�޶�� ���� ���� ���̿� ���� �׸�
        //DrawLine(��� ����, ���� ����)
        //��߰� �������� ���̿� ���� �׸�
        Gizmos.DrawLine(target.position + (target.up * targetOffset),
                                     transform.position);

        //ī�޶� ����� �ִ� �浹ü ǥ���ϱ� ���� �����
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, colliderRadius);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;            //ī�޶� ������ ���
    public float moveDamping = 15f;     //�̵��ӵ� ���
    public float rotateDamping = 10f;   //ȸ���ӵ� ���
    public float distance = 5f;         //���� ������ �Ÿ�
    public float height = 4f;           //���� ������� ����
    public float targetOffset = 2f;     //���� ��ǥ�� ������

    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    //�ݹ��Լ� - ȣ���� �������� �ʾƵ� �˾Ƽ� �۵��ϴ� �Լ�.
    //�̺�Ʈ Ʈ���� �� �������� ������ ����.
    // Update is called once per frame
    void LateUpdate()
    {
        var camPos = target.position                        //���� ��� ��ġ
                      - (target.forward * distance)         //���� ��� �Ÿ�
                      + (target.up * height);               //���� ������ ����
        tr.position = Vector3.Slerp(tr.position,                        //Slerp �����Լ�
                                     camPos,
                                     Time.deltaTime * moveDamping);    //���� ��ġ //������ �̵�
        tr.rotation = Quaternion.Slerp(tr.rotation,
                                       target.rotation,
                                       Time.deltaTime * rotateDamping);//���ʹϾ� ȸ�� //������ ȸ��
        tr.LookAt(target.position + (target.up*targetOffset)); //������ �߹ٴ��� �Ĵٺ��� ī�޶� �����¸�ŭ ����(������)�� ������ ����



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //DrawWireSphere(��ġ,����)
        //������ �̷���� ������ ����� �׸�(���信�� ǥ�õ�,.����׿�)
        Gizmos.DrawWireSphere(target.position + (target.up * targetOffset), 0.1f);
        //���� ī�޶�� ���� ���� ���̿� ���� �׸�
        //DrawLine(��߽���, ��������)
        //��߰� �������� ���̿� ���� �׸�
        Gizmos.DrawLine(target.position + (target.up * targetOffset), transform.position);
    }
}

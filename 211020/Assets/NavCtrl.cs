using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//�׺�Ž��� ������ ai�� using���� �����;� �Ѵ�.

public class NavCtrl : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        //�׺���̼� �󿡼� ������Ʈ�� �̵���
        //������Ʈ�� �����̰�, ���ӿ�����Ʈ�� ��ǥ��
        //������Ʈ�� ���� ����ȴ�.

        //������ �׺���̼� ����� ���� ���
        //�׺���̼��� �����ӿ� ������ �� �� �ִ�
        //������ٵ� ������� �ʾƾ� �Ѵ�.

        //����, ������Ʈ�� ����ϴ� ������Ʈ�� ��ǥ��
        //������ �����ؾ��ϴ� ��찡 �ִٸ�
        //������Ʈ�� ��ǥ�� �������� �ʰ�(position = ��ǥ�� ������� �ʴ´�.)
        //������Ʈ�� ��ǥ�� �����Ѵ�.
        //agent.Warp(Vector3.zero);
        //������Ʈ�� ��ǥ�� ������ �����Ҷ���
        //warp�Լ��� ����Ѵ�.
    }

    void Update()
    {
        agent.SetDestination(target.position);

        //off mesh link
        //���� ���������� �̾������� ���� �׺���̼� ���̸�
        //�������ִ� ���
        //drop height : ���������� ���������� �������ִ� ���
        //jump distance : ���� ���̿��� ���� ������ �ִ� ���� ���̸�
        //              �����ؼ� �ǳʰ� �� �ֵ��� �������ִ� ���
        //              �ǳʰ� ��ġ�� ���� ���̰� ������ �������� �ʴ´�.
    }
}

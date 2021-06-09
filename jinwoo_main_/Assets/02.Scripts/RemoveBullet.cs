using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{

    public GameObject sparkEffect;//����ũ ������
    private void OnCollisionEnter(Collision collision)//collision�� ���ؼ� �浹�� ��ü�� � �� ����
    {
            //�浹�� �߻��� ��� �߿��� BULLET �±׸� ����
        if (collision.collider.tag == "BULLET")//�浹�ѹ�ü.�ݶ��̴���������.�ױ�
        {
            //����ũ ����Ʈ �Լ� ȣ��
            ShowEffect(collision);


            //�浹�� �߻��� ������Ʈ ����
            Destroy(collision.gameObject);
           //collision.gameObject.SetActive(false);
        }
        
    }

    void ShowEffect(Collision coll)
    {
        //�浹 ������ ������ �������.
        //�浹 �� �߻��� ������ ��ġ ����
        ContactPoint contact = coll.contacts[0];
        //FromToRotation(ȸ����Ű���� �ϴ� ����, Ÿ�� ����)
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
        //�浹�� �� �� �������� ȿ�� ����(Z)��
        //��������(�Ѿ��� ����� ���� -Z)�������� ������ ����
        //Instantiate(����ũ����Ʈ��, ��������������, rot�������� ������ ����)
        //�Ѿ��� �߻�� ��ġ�� �̵�(�巳�뿡�� ���� �� �Ѿ��ڱ� ����)
        Vector3 point = contact.point + (-contact.normal * 0.03f);
        GameObject spark = Instantiate(sparkEffect, point, rot);
        //���������� ����Ʈ�� �θ�� �巳���� ����
        spark.transform.SetParent(this.transform);
    }
}

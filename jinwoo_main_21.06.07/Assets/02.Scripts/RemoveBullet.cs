using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)//collision�� ���ؼ� �浹�� ��ü�� � �� ����
    {
            //�浹�� �߻��� ��� �߿��� BULLET �±׸� ����
        if (collision.collider.tag == "BULLET")//�浹�ѹ�ü.�ݶ��̴���������.�ױ�
        {
            //�浹�� �߻��� ������Ʈ ����
            Destroy(collision.gameObject);
           //collision.gameObject.SetActive(false);
        }
        
    }
}

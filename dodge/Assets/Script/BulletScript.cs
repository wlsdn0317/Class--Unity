using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float speed = 8f;
    Rigidbody bulletRigidbody;


    
    void Start()
    {
        bulletRigidbody = this.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = this.transform.forward*3;
        //Vector3.forward
        //���Ⱚ�� ��Ÿ���ִ� Vector3.forward~ ������ ��������
        //���Ӿ��� �������� �ϴ� ������ �ʴ� ���Ⱚ�̱� ������
        //�����̴� ����� ����ִ� ��� ������ ���ϵ�, ������ �������� �ֵ�
        //�׻� �Ȱ��� �������� �̵��ϰ� �ȴ�.

        //this.transform.forward
        //����3���� ���Ⱚ�� �������� �Ǹ�
        //��� ��Ȳ���� ������ �ʴ� ������ �������� ������ ������
        //Ư���� ���ӿ�����Ʈ(���)���κ��� ������ �������� �Ǹ�
        //�ش� ����� �ٶ󺸴� ������ �������� �Ͽ�
        //�յڻ����¿찡 ������ �ȴ�.
        //��� ��쿡�� ���Ծ��� ������ �ƴ�
        //����� ��� �ٶ󺸴��Ŀ� ���� �׹����� ���������� ���ϴ�
        //������� ������ �ȴ�.

        Destroy(this.gameObject, 3f);
        //Destroy�Լ��� �Ű������� ��� ������Ʈ�� �ð��� �ְ� �Ǹ�
        //�ش� �ð��� ������ �ڵ����� ������ �ȴ�.

    }

   
    void Update()
    {
        
    }
    
    //����� collider��
    // �ٸ� ���� �ε�������(enter)
    //��� �ִ� ���� ���(stay)
    //��Ҵ� ���� ��������(Exit)
    //�ڵ����� ����Ǵ� �Լ�
    private void OnCollisionEnter(Collision collision) 
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        //Destroy�Լ� : �Ű������� ���޹��� �����
        //�������ִ� �Լ�
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }

    








    }

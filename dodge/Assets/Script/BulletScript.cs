using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  BulletScript : MonoBehaviour
{
    float speed = 8f;
    Rigidbody bulletRigidbody;
    GameManager gm;
    
    //������ Hp��
    //�Ѿ��� ó������ ����ȭ�鿡 �������� �ʱ� ������
    //����ȭ�鿡 �����ϴ� ����� public������ �Է¹���ä��
    //������ �� ����.
    //(�Ѿ��� �ٸ� ������ �����ɼ��� �ֱ� ������)
    //���� �����Ϳ��� ����� �־��ִ°� �ƴ�
    //��ũ��Ʈ���� �ɵ������� �ش� ����� ã�Ƽ� ������ �� �ֵ��� �ؾ��Ѵ�.


    void Start()
    {
        GameObject target = GameObject.Find("gManager");
        GameObject other = GameObject.Find("Player");
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        
        bulletRigidbody = this.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = this.transform.forward * 3;
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

        Destroy(this.gameObject, 10f);
        //Destroy�Լ��� �Ű������� ��� ������Ʈ�� �ð��� �ְ� �Ǹ�
        //�ش� �ð��� ������ �ڵ����� ������ �ȴ�.

        
        //GameObject.Find("����� �̸�")
        //�ش� �̸��� ���� ���ӿ�����Ʈ�� ���Ӿ����� ã�Ƽ�
        //��ȯ���ִ� �Լ�
        if (target != null)
        {
            //ã������ ����� �����Ҷ��� ������Ʈ�� ������
            gm = target.GetComponent<GameManager>();
        }
        //Find�Լ��� ������ �̸��� ���� ����� �������� ������
        //null�� ��ȯ�ϱ� ������
        //����� �����Ҷ��� �ڵ尡 �����ϵ���
        //���ǹ��� ���ؼ� ������ ���ش�.
    }


    void Update()
    {



    }

    //����� collider��
    // �ٸ� ���� �ε�������(enter)
    //��� �ִ� ���� ���(stay)
    //��Ҵ� ���� ��������(Exit)
    //�ڵ����� ����Ǵ� �Լ�

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            player.hp -= 1;

           
            //����Ƽ���� �⺻������ �����Ǵ� ������Ʈ �Ӹ� �ƴ϶�
            //����ڰ� ���� ��ũ��Ʈ ���� ������Ʈ�� ����� �ȴ�.
            //���� getComponent�� ��ũ��Ʈ�� ������ �� �ִ�.

            //��ũ��Ʈ�󿡼� ����� ������ �����Ϸ���
            //�ش� ��ũ��Ʈ�� ���� ���ӿ�����Ʈ���Լ�
            //getComponent�� �ش� ��ũ��Ʈ�� �����;� ������ �� �ִ�.

            if (player.hp <= 0)
            {
                player.die();
                gm.gameOver();

            }


            //��ũ��Ʈ �󿡼� Ư�� ����� �����ϴ� �ڵ尡 �����Ѵٸ�
            //�ش� �ڵ�� �ݵ�� ���� �������� ���۽��Ѿ� �Ѵ�.
            //������ ������κ��� �����ϴ� �ڵ尡 �����Ѵٸ�
            //�ش� �ڵ��� ������ ���������� �̷������ ���� �� �ֱ� ����
            Destroy(this.gameObject);
        }
        //Destroy�Լ� : �Ű������� ���޹��� �����
        //�������ִ� �Լ�

        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }









}

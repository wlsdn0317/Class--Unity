using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    float g_Velocity;//�߷°��ӵ�
                     //�ð��� �������� ������

    Rigidbody2D rb;
    //�÷��̾� ������� ������ٵ�

    bool hittable;
    //�÷��̾��� �������� ���θ� �˷��ִ� ����

    public int hp = 3;
    //�÷��̾��� ���� ü�� ��ġ

    public GameManager gm;
    //���ӸŴ��� ��ü�� �����Ͽ� ���Ӿ� ���� ȣ���ϵ��� ��

    public GameObject[] hpImage;
    //�÷��̾��� ü�¾������� ������ ���ӿ�����Ʈ �迭
    //C#������ �迭�� ��Ÿ���� ���ȣ��
    //�������� �ƴ� �ڷ��� �ڿ� �ٴ´�.
    //�迭�� ũ�⿪�� �����Ҷ��� �־����� �ʴ´�.
    //�迭�� ũ��� �迭�� �ʱ�ȭ�ɶ� ������ �ȴ�.
    


    void Start()
    {
        g_Velocity = 0;
        rb = this.GetComponent<Rigidbody2D>();
        hittable = true;
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //���콺 Ű�� ���콺�� ���� ������ ���̰� ���� ������
            //Ű����ó�� Keycode�� ������� �ʰ�
            //���ڷ� ����Ѵ�.
            //0:����, 1:������, 2:��Ŭ��


            rb.AddForce(Vector2.up *2,ForceMode2D.Impulse);
            //���ʹ������� ���� ���Ѵ�.
            
            //AddForce�� �Ű������� �߰��� ���� �� ������
            //�ش� �Ű������� �������� �������� ��Ÿ����.
            //ForeceMode.Impulse�� ���������� ���� ���� ���ϸ�
            //ForceMode.Force�� ���� ��ü�� ��� �۶߸��� ����̴�.
            //Impulce�� ���� ���ӿ��� ������ ������ �� ����ϸ�
            //Force�� ĳ���͸� �̵���ų�� ����Ѵ�.
        }
    }

    void makeGravity()
    {
        //������ٵ� �̿����� �ʰ�
        //�ڵ带 ���� ���� �߷��� �����ϴ� ���

        g_Velocity += Time.deltaTime;
        //�ð��� ����ؼ� �߷°��ӵ��� �����Ѵ�.

        this.transform.position += Vector3.down * g_Velocity;
        //�÷��̾��� ��ǥ�� �߷°��ӵ� ũ�⸸ŭ
        //�Ʒ��� ��������.
    }

    public void call_Hit()
    {
        StartCoroutine(isHit());
        //�ڷ�ƾ�Լ��� ������
        //�Լ��� �����Ų(StartCoroutine)��ü����
        //���ӵǱ� ������
        //�ش� ��ü�� �����Ǹ� �Լ��� ������ ���߿� �����ȴ�.
        //���� ����� �����Ǵ� �������
        //�������� �ʴ� ��󿡼� �Լ��� �θ����� ����� ���� ����.
    }

    IEnumerator isHit()
    {
        

        if (hittable == true)//�÷��̰� ���� �� �ִ� ���¸�
        {
            hp--;
            //��ֹ��� �浿�����Ƿ� ü���� 1 ���ҽ�Ų��.

            if(hp <= -1)
            {
                //ü���� ��� �����ϸ�
                gm.gameOverFunc();
                //���ӸŴ������Լ� ���ӿ��� �Լ��� ȣ��
            }

            damage();
            //ü���� ���ҵ� �ڿ� �������� ���ִ� �Լ��� ����

            hittable = false;
            //�÷��̾ �浿�߱⶧����
            //�ߺ��浹���� �ʵ���
            //hittable�� false�� ����

            //�÷��̾ ��ֹ��� �ε������� �����ų �ڷ�ƾ �Լ�
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    this.GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().enabled = true;
                }
                yield return new WaitForSeconds(0.1f);
            }
            hittable = true;
            //������ ������(������ ������) �ٽ� �浹 ������ ���·�
            //bool���� ��������ش�.
        }
        else
        {
            yield return null;
        }
    }

    void damage()
    {
        if (hp >= 0)
        {
            hpImage[hp].SetActive(false);
        }
    }
    




}

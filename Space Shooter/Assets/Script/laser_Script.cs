using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_Script : MonoBehaviour
{
    public GameObject laserEff;
    //�������� ���� �ε������� �ε����� ȿ���� ��Ÿ����
    //�ִϸ��̼� ������Ʈ

    Vector3 dir= Vector3.up;//�������� ���ư����� ���Ⱚ�� �����ϴ� ����

    string targetTag= "enemy";//�������� �浹�� ����� �±װ�
                              //�ʱⰪ�� enemy
    public void setTaegetTag(string str)
    {
        targetTag = str;
    }

    void Start()
    {

       
        Destroy(this.gameObject, 4.0f);
    }

    
    void Update()
    {
        this.transform.position += this.transform.up *Time.deltaTime*3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {//����� �ε�����

            Vector2 contactPoint = collision.ClosestPoint(this.transform.position);
            //�ݶ��̴����� �浹�� �Ͼ����
            //�浿�� ������ ��ǥ�� ��ȯ���ִ� �Լ�


            GameObject eff = Instantiate(laserEff, contactPoint, Quaternion.identity);
            Destroy(eff, 0.2f);

            if (collision.tag == "Player")
            {
                collision.GetComponent<PlayerController>().damaged();
            }
            else
            {
                collision.GetComponent<enemy_Script>().drop_boltItem();
                Destroy(collision.gameObject);//���� ����
            }




            
            Destroy(this.gameObject);//�Ѿ˵� ����
        }
    }



    public void setDir(Vector3 v)
    {
        //public�� �ƴϰԵ� dir������ ����
        //�ٲ��ִ� �Լ�
        dir = v;
        //public�� �ƴ� ������ �ܺο��� ������ �� ���⶧����
        //�ܺο����� ������ �������� ���� �Լ��� ���� �����ϰ�
        //������ �������� �����ϴ� ���� �ش� ��ũ��Ʈ���� �ϵ��� ����.
    }
}

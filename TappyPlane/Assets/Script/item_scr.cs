using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_scr : MonoBehaviour
{
    public int bonus =0;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * 5;
        //�����۵� ��ֹ�ó�� �����ʿ��� �������� �����̵��� ����� �ش�.

        if(this.transform.position.x<= -8)
        {
            //�������� ȭ�� ������ ������
            Destroy(this.gameObject);
            //������ ����
            //Destroy���� �Ű�������this�� ������
            //�ش� ������Ʈ�� �ƴ϶� ��ũ��Ʈ(������Ʈ)�� ������ �ǰ�
            //���ӿ�����Ʈ�� ����ؼ� ���� �ȴ�.
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Plane")
        {
            GameObject gmObj = GameObject.Find("GameManager");
            //���ӿ��� �����ϴ� �Ŵ��� ������Ʈ�� Ž��

            if (gmObj != null)
            {
                //���ӸŴ����� �����Ҷ�
                GameManager gm = gmObj.GetComponent<GameManager>();
                //���ӸŴ������Լ� �Ŵ��� ��ũ��Ʈ�� �����ͼ�
                gm.score += bonus;
                //�Ŵ��� ��ũ��Ʈ�� ������ ����
            }



            //�÷��̾ �������� name���� tag�� ���°� ����.
            Destroy(this.gameObject);
        }
    }
}

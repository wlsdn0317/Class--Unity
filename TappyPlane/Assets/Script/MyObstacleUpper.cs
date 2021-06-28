using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObstacleUpper : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position += Vector3.left * 4 * Time.deltaTime;
        //��ֹ��� �������� �̵�
        if(this.transform.position.x <= -4)
        {
            //���� ȭ�� ������ ������ ������
            Vector3 resetPos = this.transform.position;
            resetPos.x += 8;
            //������ ȭ�� ������ �̵�
            resetPos.y = Random.Range(1.5f, 2.5f);
            //���̸� �����ϰ�
            this.transform.position = resetPos;
            //������ ��ǥ�� ����

            //transform.Position�� x,y,z����
            //���� ���� �ٲܼ� ���� ������
            //��ó�� ������ ������ �����ϰ�
            //��ġ�� ������ �ڿ� �ٽ� �������ְ� �ִ�.

           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Plane")
        {
            Debug.Log("Hit");

            collision.GetComponent<PlayerScr>().call_Hit();
            //�ڷ�ƾ �Լ��� �Լ��� �ܼ��� ȣ�⸸ �ؼ��� ���������� �������� ������
            //�ݵ�� StartCoroutine�� ���ؼ� �Լ��� ������Ѿ� �Ѵ�.
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObstacle : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position += Vector3.left * 4 * Time.deltaTime;

        if(this.transform.position.x < -8)
        {
            //��ֹ��� ȭ�� ������ ������ ������ ��
            Destroy(this.gameObject);
            //�ڱ��ڽ��� ������ ����
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Plane")
        {
            Debug.Log("Hit");

            collision.GetComponent<PlayerScr>().call_Hit();
            //�ڷ�ƾ �Լ��� �Լ��� �ܼ��� ȣ�⸸ �ؼ��� ���������� �������� ������
            //�ݵ�� StartCoroutine�� ���ؼ� �Լ��� ������Ѿ� �Ѵ�.
        }
    }
}

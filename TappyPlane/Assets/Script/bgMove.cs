using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMove : MonoBehaviour
{
    public Transform targetPos;
    //����� ȭ�� ������ ������ ������
    //���� ȭ�鿡 ���̴� ��� �ڷ� �ٽ� �̵��ؾ� �ϱ� ������
    //�ش� ����� ������ �־�� �ڷ� ���� �ִ�.


    public float limitPos;//������ �������� �Ǵ��ϴ� X��ǥ
    public float movePos;//������ �������� �̵��ϴ� X��ǥ
    public float movingSpeed; //����� �̵��ӵ�
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime*movingSpeed;
        if (this.transform.position.x <= limitPos)
        {
            this.transform.position += Vector3.right * movePos;
        }
    }
}

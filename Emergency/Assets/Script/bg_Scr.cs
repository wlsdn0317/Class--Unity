using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bg_Scr : MonoBehaviour
{
    public Transform targetPos;
    public float limitPos;//������ ���� y��ǥ
    public float movePos;//�̵��ϴ� y��ǥ
    public float movingSpeed;//�̵��ӵ�
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * movingSpeed;//�ð�*���ǵ� �ӵ��� ȭ�� �̵�
        if (this.transform.position.y <= limitPos)
        {
            this.transform.position += Vector3.up * movePos;
        }
    }
}

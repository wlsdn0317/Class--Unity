using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    float rotate_speed = 50;
    //���� ȸ�� �ӵ�

    void Start()
    {
        
    }

  
    void Update()
    {
        this.transform.Rotate(0,rotate_speed*Time.deltaTime, 0);

        //���������� ���̵��� �ٲٰ� �ʹٸ�
        //���� ȸ���ӵ��� ������ ��濡�� �Ѿ��� ���ƿ��� �ϰų�
        //�Ѿ��� �߻��ֱ⸦ ª���ؼ� ���� �Ѿ��� �����ǰ� �ϰų�
        //�÷������� ü���� �����ؼ� ��ȸ�� ���� �ְų�
        //�÷��̾��� �̵��ӵ��� �����ؼ� ���̵��� ������ �� �ִ�.

        //�̿ܿ��� �Ѿ��� ũ�⸦ �ٲٰų�, �Ѿ��� �ӵ��� �ٲٴ� ��
        //�������� ������� ������ ���̵��� �������� �� �ִ�.
    }
}

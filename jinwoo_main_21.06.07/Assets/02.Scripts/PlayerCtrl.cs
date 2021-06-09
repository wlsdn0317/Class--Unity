using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//���� Ŭ����
//Ŭ���� ����ȭ
//Ŭ������ ��� ������ �޸� ����ȭ �����
//�ν����Ϳ� ǥ�õ�
[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runF;
    public AnimationClip runB;
    public AnimationClip runL;
    public AnimationClip runR;
}




public class PlayerCtrl : MonoBehaviour
{
    //����������
    //Ptivate�� �ۼ��� ��ũ��Ʈ ���ο����� ����
    //Public�� ���� �ܺ� ��𿡼��� �� �� ����.
    //�⺻ ���´� Private��
    //�߰��� Protected ��� ���������ڰ� ����.
    private float h = 0f;
    private float v = 0f;
    float r = 0f;//���콺 �� �޾Ƽ� ȸ�� ��Ű�� ���� ����
     



    Transform tr;   //Ʈ������ ������Ʈ ���� ����
                    //Public���� ����� ������ Inspector â�� �����.
    public float moveSpeed = 10f;
    public float rotSpeed = 150f;

    public PlayerAnim playerAnim;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
       //Ʈ������ ������Ʈ�� tr ���� ����
        tr = GetComponent<Transform>(); //Ʈ�������� �������ؼ� ������Ʈ���� ������û
        anim = GetComponent<Animation>();
        anim.clip = playerAnim.idle;
        anim.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        h = Input.GetAxis("Horizontal"); //input(unity)�Ŵ����� ��ϵ��մ� ����� ������ ���°�
        v = Input.GetAxis("Vertical");
        //print("H�� -" + h + " V�� - " + v);
        r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h); //Vector3 : ��ġ=x,y,z 3������ �ٰ���������
        
        moveDir = moveDir.normalized; //���� ����ȭ
                                      //�밢���̵��� �Ϲ����� �̵����� ũ�Ⱑ Ŀ�� ���� ������
                                      //�̸� �ذ������� ������ ũ�⸦ �����ϰ� 1�� ����ȭ ��Ŵ

       
        tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);    //Space.self ���� �������� �� �� �� ���⼳��
        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);
        //print(Vector3.Magnitude(Vector3.forward + Vector3.right));
        //print(Vector3.Magnitude((Vector3.forward + Vector3.right).normalized));

        //�ִϸ��̼� ���� ����
        if (v >= 0.1f)//���� 
        {
            //CrossFade(�ִϸ��̼� �̸�, ��ȯ �ð�)
            anim.CrossFade(playerAnim.runF.name, 0.3f);
        }
        else if (v <= -0.1f)//����
        {
            anim.CrossFade(playerAnim.runB.name, 0.3f);
        }
        else if (h >= 0.1f)//������
        {
            anim.CrossFade(playerAnim.runR.name, 0.3f);
        }
        else if(h<= -0.1f)//����
        {
            anim.CrossFade(playerAnim.runL.name, 0.3f);
        }
        else//���� �� idle ���·� ��ȯ
        {
            anim.CrossFade(playerAnim.idle.name, 0.3f);
        }            
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bSpawner : MonoBehaviour
{
    public GameObject bullet;
    //������ �Ѿ��� �������� ������ ����

    float bulletDelay = 0;
    //�Ѿ��� �����ϴ� ������;

    public Transform playerTrans;
    //�Ѿ��� �߻��� ����� �÷��̾��� ��ġ��
    //Ȯ���ϱ� ���� �÷��̾ ������ ������.

    void Start()
    {
        
    }

  
    void Update()
    {
        //������Ʈ �Լ��� 1�����ӿ� 1�� ����ȴ�.
        
        bulletDelay += Time.deltaTime;
        //time.deltatime : ���������ӿ��� ������������
        //����Ǳ���� �ɸ� �ð��� �����´�.

        if(bulletDelay >= 1f)
        {
            //�Ҽ����� ���ǹ����� ����� ���
            //���ذ��� ==���� ������ üũ�ϴ°��� ��ǻ� �Ұ���
            //�Ҽ��� ���ϰ� ����ؼ� ������ �߻��ϱ� ������
            //== ���ٴ� ������ ���ؼ� ������ �ִ°��� ����.
            
            bulletDelay -= 1f;
            //���ذ��� 3�ʰ� �Ѿ��� ������
            //3�ʸ� �ð����� ���ְ�
            //�ٽ� ī��Ʈ�� �ϵ��� ����� �ش�.

            Vector3 dir = playerTrans.position - this.transform.position;
            //������ �������� ���ϴ� ���͸� ���Ϸ���
            //������ - ����� ��ǥ









           GameObject tmp = Instantiate(bullet,this.transform);
            //�������̳� ���ӿ�����Ʈ �����͸� �̿��ؼ� 
            //������ ����� ������Ʈ�� �������ִ� �Լ�

            //������ ���ӿ�����Ʈ�� ��ȯ�ϱ� ������
            //�Ű������� ����� ��ȯ�� ���ӿ�����Ʈ�� �����ϸ�
            //������ ���ӿ�����Ʈ�� �����͸� �Ϻ� ������ �� �ִ�.
            tmp.transform.position -= Vector3.up * 1;


            tmp.transform.forward = dir;
            //�Ѿ��� '��'������
            //������ ���� �������� ���� 
        }
    }
}

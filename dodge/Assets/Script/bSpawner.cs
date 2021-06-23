using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bSpawner : MonoBehaviour
{
    public GameObject bullet;
    
    //������ �Ѿ��� �������� ������ ����

    float bulletDelay = 0;
    //�Ѿ��� �߻��ϰ� ���� �ð�;

    public Transform playerTrans;
    //�Ѿ��� �߻��� ����� �÷��̾��� ��ġ��
    //Ȯ���ϱ� ���� �÷��̾ ������ ������.

    float nextDelay = 0.3f;
    //�Ѿ� �߻翡 �ʿ��� �ð�(�ʱ갪)
    public GameObject player;
    public GameObject SpecialBullet;
    public GameObject healbullet;
    void Start()
    {
        PlayerController pc = player.GetComponent<PlayerController>();
    }

  
    void Update()
    {
        //������Ʈ �Լ��� 1�����ӿ� 1�� ����ȴ�.
        GameObject htmp;
        GameObject tmp;
        bulletDelay += Time.deltaTime;
        //time.deltatime : ���������ӿ��� ������������
        //����Ǳ���� �ɸ� �ð��� �����´�.

        if(bulletDelay >= nextDelay)
        {
            //�Ҽ����� ���ǹ����� ����� ���
            //���ذ��� ==���� ������ üũ�ϴ°��� ��ǻ� �Ұ���
            //�Ҽ��� ���ϰ� ����ؼ� ������ �߻��ϱ� ������
            //== ���ٴ� ������ ���ؼ� ������ �ִ°��� ����.
            
            bulletDelay -= nextDelay;
            //���ذ��� 3�ʰ� �Ѿ��� ������
            //3�ʸ� �ð����� ���ְ�
            //�ٽ� ī��Ʈ�� �ϵ��� ����� �ش�.

            nextDelay = Random.Range(0.5f, 1.0f);
            //Random.Range(�ּҰ�,�ִ밪)
            //������ ���� ���� ������ ���ڸ� �����ϴ� �Լ�
            //rand()�Լ��� �ٸ��� �Ǽ������� ���ڸ� �����Ѵ�.

            Vector3 dir = playerTrans.position - this.transform.position;
            //������ �������� ���ϴ� ���͸� ���Ϸ���
            //������ - ����� ��ǥ







           
            //�������̳� ���ӿ�����Ʈ �����͸� �̿��ؼ� 
            //������ ����� ������Ʈ�� �������ִ� �Լ�

            //Instantiate �Լ��� ��� ���ӿ�����Ʈ�� ���纻�� ������ִ� �Լ���
            //�Ű������� ��� �־��ִ��Ŀ� ���� ������Ʈ�� ����� ����� �޶�����.
            
            //1.�Ű������� ������ ���ӿ�����Ʈ(������)�� �־��ָ�
            //0,0,0��ġ�� 0,0,0������ ��� ������Ʈ�� �����Ͽ�
            
            //2.�Ű������� ������ ���ӿ�����Ʈ��, �ٸ����ӿ�����Ʈ�� ������
            //�ι�°�� �־��� ���ӿ�����Ʈ�� �ڽ����� ����� ���������
           
            //3.�Ű������� ������ ���ӿ�����Ʈ, ��ǥ, ������ �־��ָ�
            //������ ��ǥ�� ������ ������ ���ӿ�����Ʈ�� ���������



            //������ ���ӿ�����Ʈ�� ��ȯ�ϱ� ������
            //�Ű������� ����� ��ȯ�� ���ӿ�����Ʈ�� �����ϸ�
            //������ ���ӿ�����Ʈ�� �����͸� �Ϻ� ������ �� �ִ�.
            

            
            
            //�Ѿ��� '��'������
            //������ ���� �������� ���� 

           
           

            int r = Random.Range(1, 4);
            switch (r)
            {
                case 1:
                    tmp = Instantiate(bullet, this.transform.position, this.transform.rotation);
                    tmp.transform.position -= Vector3.up * 1.5f;
                    tmp.transform.forward = dir;
                    break;
                case 2:
                    tmp = Instantiate(SpecialBullet, this.transform.position, this.transform.rotation);
                    tmp.transform.position -= Vector3.up * 1.5f;
                    tmp.transform.forward = dir;
                    break;
                case 3:
                    tmp = Instantiate(healbullet, this.transform.position, this.transform.rotation);
                    tmp.transform.position -= Vector3.up * 1.5f;
                    tmp.transform.forward = dir;
                    break;
            }



        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Script : MonoBehaviour
{
    GameObject targetPos;
    //�� ĳ���Ͱ� ��ǥ�� �ؾ��ϴ� ����� ��ġ == �÷��̾�

    Vector3 dir;//���� �̵� ����

    float delay = 1;//�Ѿ��� �������� �߻�Ǵ� �ֱ�
    float pressTime = 0;
    public GameObject Laser;

    public GameObject[] bolts;





    void Start()
    {
        targetPos = GameObject.Find("Player");
        //��ǥ���� ã�Ƽ� ������ ����

        
        //��ǥ���� ���� ������ ���ؼ� ������ ����
        //���� : ��ǥ����ġ - ������ġ
    }


    void Update()
    {
        if (targetPos != null)
            //target �� �÷��̾ �����Ҷ���
            //���ʹ̰� �÷��̾� �������� �����̰�
            //�÷��̾� �������� �Ѿ��� �߻��Ѵ�.
            //�÷��̾ �Ѿ��� �°� �����ȴٸ�
            //���̻� �̵���, �߻絵 ���� �ʰ� �ȴ�.
        
        {



            dir = targetPos.transform.position - this.transform.position;
            //������ ����� ������Ʈ�� �־��ָ�
            //�ǽð����� Ÿ�ٰ� �ڽ��� ��ġ�� ��������
            //���ο� ������ ����ؼ� �̵��ϱ� ������
            //����źó�� �����ϴ� ������Ʈ�� ���� �� �ִ�.

            //���Ϳ��� ����� ũ�Ⱑ ��� ������ �Ǿ� �־
            //�ܼ� ���͸� �̿��ؼ� �̵��� ��Ű�� �Ǹ�
            //ũ��(�Ÿ�)�� ���� �̵��ӵ��� ���̰� �߻��ϰ� �ȴ�.
            //�׷��� ����� ���Ϳ��� ũ�⸦ �����ϰ�
            //���⸸�� ������ �̵��� ���Ѿ� �ϴµ�
            //�̶� �ʿ��� ���� ������ normalize(��������)�̴�.

            if (Vector3.Distance(this.transform.position, targetPos.transform.position) > 1)
            {
                //Vector3.Distance(1,2) : �κ��� ������ '�Ÿ�'�� �����ִ� �Լ�
                //�Ÿ����� float������ ��ȯ�ȴ�.

                dir.z = 0;
                dir = dir.normalized;
                //�������ʹ� ������ ũ�⸦ 1�� ������ �����̴�.
                //�׷��� ��� �������ʹ� ������ ũ�⸦ ������
                //���� ���⸸ ���̰� ���� �ȴ�.


                //this.transform.position += dir * Time.deltaTime * 1f;
                //�� ����Ⱑ �÷��̾� �������� ����������


                this.transform.forward = dir;
                //�ش� ������Ʈ�� ���� ������ ����
                this.transform.position += this.transform.forward * Time.deltaTime;
                //�̵������� �ش� ������Ʈ�� �ٶ󺸸� ����(forward)���� �̵���Ŵ

                pressTime += Time.deltaTime;
                if (pressTime >= delay)
                {
                    pressTime -= delay;
                    //�����̽��ٸ� ������ delay�ʸ��� �Ѿ��� �߻��.
                    GameObject obj = Instantiate(Laser, this.transform.position, Quaternion.identity);
                    //�÷��̾� ��ġ���� �������� �߻�
                    obj.transform.up = this.transform.forward;
                    //�������� ������� == ���ʹ��� �������
                    //�������� up == ���ʹ��� foward�� �ǵ��� ���� ����

                    obj.GetComponent<laser_Script>().setTaegetTag("Player");
                    //���ʹ̰� ������ �Ѿ��� ���ʹ̰� �ƴ� �÷��̾��
                    //�ε������� ������ �ȴ�.

                }




            }
            // Quaternion q = Quaternion.LookRotation(targetPos.transform.position);
            //Quaternion.LookRotation
            //������ ��� �������� ���ϴ� �������� �ڵ����� ������ִ� �Լ�
            // this.transform.rotation = q;
        }
        
    }
    public void drop_boltItem()
    {
        int r = Random.Range(0, 3);
        Instantiate(bolts[r], this.transform.position, Quaternion.identity);
    }
}

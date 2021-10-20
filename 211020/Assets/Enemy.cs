using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eStatus
{
    IDLE,   //���
    WANDER, //�ֺ� ��ȸ
    CHASE,  //����
    ATTACK, //����
    RUN,    //����
}
public class Enemy : MonoBehaviour
{
    public eStatus myStatus = eStatus.IDLE;

    public Transform target; //���Ͱ� �ν��� ���

    public int hp = 10;

    public Vector3 wanderingPos = Vector3.zero;//��ȸ�Ҷ��� ������

    float waitingTime = 0; //idle�̳� wandering�� ���ð�
    float attackDelay = 0;  //���� �����̰�
    void Start()
    {
        
    }

    void Update()
    {
        changeStatus();
        Action();
    }

    void changeStatus()
    {
        //������ ��ȭ���� �켱������ �����ϸ�
        //�켱�� �Ǿ�� �ϴ� ���´�
        //�ڵ�󿡼� ���� �ۼ����ִ� ���� ����.
        if (hp <= 3)
        {
            myStatus = eStatus.RUN;
        }
        else if (Vector3.Distance(this.transform.position, target.position) < 1)
        {
            myStatus = eStatus.ATTACK;
        }
        else if (Vector3.Distance(this.transform.position, target.position) < 5)
        {
            //Ÿ�ٰ��� �Ÿ��� 5 ���ϸ�
            myStatus = eStatus.CHASE;
            //Ÿ���� ����
        }
        else
        {
            waitingTime += Time.deltaTime;
            if (waitingTime > 3)
            {
                waitingTime -= 3;
                int i = Random.Range(0, 2);
                if (i == 0)
                {
                    myStatus = eStatus.IDLE;
                }
                else if (i == 1)
                {
                    wanderingPos = new Vector3(Random.Range(-25.0f,25.0f), 0.5f, Random.Range(-25.0f, 25.0f));
                    //���ο� ��Ȳ�� �����Ҷ� ���� ��Ȳ�� ��������
                    //���Ӱ� �������ش�.
                    //�������� �ʵ� ���� ������ ������ �ϱ� ������
                    //���� ���� ���� ��ǥ�� �̵������� ���� ���� �����Ѵ�.
                    myStatus = eStatus.WANDER;
                }
            }
        }
    }

    void Action()
    {
        if (myStatus == eStatus.CHASE)
        {
            Vector3 dir = target.position - this.transform.position;
            dir = dir.normalized;
            this.transform.Translate(dir * Time.deltaTime);
        }
        else if (myStatus == eStatus.RUN)
        {
            Vector3 dir = target.position - this.transform.position;
            dir = dir.normalized;
            if (Vector3.Distance(this.transform.position, target.position) < 5)
            {
                this.transform.Translate(-dir * Time.deltaTime);

            }
            else
            {
                myStatus = eStatus.IDLE;
                hp += 1;
            }

            //player �ݴ�������� ����
        }
        else if (myStatus == eStatus.WANDER)
        {
            Vector3 dir = wanderingPos - this.transform.position;
            dir = dir.normalized;
            this.transform.Translate(dir * Time.deltaTime);
            //�����̵��� ��ġ�� ���Ⱚ�� ����ϰ�
            //�ش� ��ġ�� �̵���Ų��.

            if (Vector3.Distance(wanderingPos, this.transform.position) < 0.1f)
            {
                waitingTime = 3;
                //�ð��� �� ������ ���� �������� �����ߴٸ�
                //�ð����� �ִ�ġ�� �༭
                //�ٽ� idle�̳� wandering�� üũ�ϵ���
                //����� �ش�.
            }
        }
        else if (myStatus == eStatus.ATTACK)
        {
            attackDelay -= Time.deltaTime;
            if (attackDelay <= 0)
            {
                Player player = target.GetComponent<Player>();
                player.hp--;
                attackDelay = 3;
            }
        }
    }

    
        
    
}

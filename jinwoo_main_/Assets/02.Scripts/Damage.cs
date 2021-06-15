using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    const string bulletTag = "BULLET";
    float iniHp = 100f; //�ʱ� ü��
    public float currHp; //���� ü��
    
    //��������Ʈ ����
    public delegate void PlayerDieHandler();
    //��������Ʈ�� Ȱ���� �̺�Ʈ ����
    public static event PlayerDieHandler OnPlayerDieEvent;







    // Start is called before the first frame update
    void Start()
    {
        currHp = iniHp;    
    }

    //�浹�� �ƴ϶� ������ ��쿡 ����ϴ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        //�浹�� ��ü�� �±� ��
        if(other.tag == bulletTag)
        {
            Destroy(other.gameObject);
            currHp -= 5; //ü��5����
            print("����ü�� -" + currHp);
            
            if(currHp <= 0f)
            {
                //�÷��̾� ��� �Լ� ȣ��
                PlayerDie();
            }
        }
    }

    void PlayerDie()
    {
        OnPlayerDieEvent();



        //print("�÷��̾� ���");
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("ENEMY");

        //for(int i = 0; i < enemies.Length; i++)
        //{
        //    //�Լ� ȣ�� ����� ������ ����.
        //    //�Ʒ��� ���� ���� ȣ�� �ϴ� ���
        //    //enemies[i].GetComponent<EnemyAI>().OnPlayerDie();
        //    //�Ʒ��� ���� SendMessage�� ȣ���ϴ� ���
        //    enemies[i].SendMessage("OnPlayerDie",SendMessageOptions.DontRequireReceiver);
        //    //����° ��������Ʈ ȣ�� ���
        //}



    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

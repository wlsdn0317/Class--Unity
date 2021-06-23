using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    const string bulletTag = "BULLET";

    float hp = 100f; //ü��
    GameObject bloodEffect; //���� ȿ�� ����

    // Start is called before the first frame update
    void Start()
    {
        //Load �Լ��� ���������� Resources ����
        //�����͸� �ҷ����� �Լ���
        //Load<����������>("������ ���");
        //�ֻ��� ��δ� Resources ������ ex)C ����̺�
        //������ ��δ� ���� ������ + ���ϸ����� ��Ȯ�ϰ� Ǯ��θ� ����
        bloodEffect = Resources.Load<GameObject>("Blood");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == bulletTag)
        {
            //���� ȿ�� �Լ� ȣ��
            ShowBloodEffect(collision);
            //�Ѿ� ����
            Destroy(collision.gameObject);
            hp -= collision.gameObject.GetComponent<BulletCtrl>().damage;
            //ü���� 0 ���ϰ� �Ǹ� ���� �׾��ٰ� �Ǵ�
            if(hp <= 0)
            {
                //���� ��ȯ ����
                GetComponent<EnemyAI>().state = EnemyAI.State.DIE;
            }
        }
    }

    void ShowBloodEffect(Collision coll)
    {
        //�浹 ��ġ �� ��������
        Vector3 pos = coll.contacts[0].point;
        //�浹 ��ġ�� ���� ����(�Ѿ��� ����� ����)���ϱ�
        Vector3 _normal = coll.contacts[0].normal;
        //�Ѿ��� ����� ���Ⱚ ���
        Quaternion rot = Quaternion.FromToRotation(Vector3.back, _normal);
        //���� ȿ�� ���� ����
        GameObject blood = Instantiate<GameObject>(bloodEffect, pos, rot);
        //1���� ����
        Destroy(blood, 1f);
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
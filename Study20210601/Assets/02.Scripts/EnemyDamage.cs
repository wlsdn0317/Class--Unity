using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    const string bulletTag = "BULLET";

    float hp = 100f; //ü��
    GameObject bloodEffect; //���� ȿ�� ����

    float initHp = 100f;//�ֱ⼳�� ü��
    public GameObject hpBarPrefab;
    public Vector3 hpBaroffset = new Vector3(0, 2.2f, 0);
    Canvas uiCanvas;    //�θ� �� ĵ���� ��ü
    Image hpBarImage;   //����� ��ġ

    void Start()
    {
        //Load �Լ��� ���������� Resources ����
        //�����͸� �ҷ����� �Լ���
        //Load<����������>("������ ���");
        //�ֻ��� ��δ� Resources ������ ex) C ����̺�
        //������ ��δ� ���� ������ + ���ϸ���� ��Ȯ�ϰ� Ǯ��θ� ���
        bloodEffect = Resources.Load<GameObject>("Blood");
        setHpBar();
    }

    void setHpBar()
    {
        uiCanvas = GameObject.Find("UI Canvas").GetComponent<Canvas>();
        GameObject hpBar = Instantiate(hpBarPrefab, uiCanvas.transform);
        hpBarImage = hpBar.GetComponentsInChildren<Image>()[1];

        var _hpBar = hpBar.GetComponent<EnemyHpBar>();
        //_hpBar�� �����ؾ��� ������� Enemy ����
        _hpBar.targetTr = gameObject.transform;
        _hpBar.offset = hpBaroffset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == bulletTag)
        {
            //���� ȿ�� �Լ� ȣ��
            ShowBloodEffect(collision);
            //�Ѿ� ����
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);

            hp -= collision.gameObject.GetComponent<BulletCtrl>().damage;

            hpBarImage.fillAmount = hp / initHp;

            //ü���� 0 ���ϰ� �Ǹ� ���� �׾��ٰ� �Ǵ�
            if(hp <= 0)
            {
                //���� ��ȯ ����
                GetComponent<EnemyAI>().state = EnemyAI.State.DIE;
                hpBarImage.GetComponentsInParent<Image>()[1].color = Color.clear;

                //�̱��� �г��� Ȱ���Ͽ� ���� �׾��� �� ���ھ� ����
                GameManager.instance.IncKillCount();
                //���� �ִϸ��̼� ���� �����ִ� �ݶ��̴� ��Ȱ��ȭ
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }

    void ShowBloodEffect(Collision coll)
    {
        //�浹 ��ġ �� ��������
        Vector3 pos = coll.contacts[0].point;
        //�浹 ��ġ�� ���� ����(�Ѿ��� ����� ����) ���ϱ�
        Vector3 _normal = coll.contacts[0].normal;
        //�Ѿ��� ����� ���Ⱚ ���
        Quaternion rot = Quaternion.FromToRotation(Vector3.back, _normal);
        //���� ȿ�� ���� ����
        GameObject blood = Instantiate(bloodEffect, pos, rot);
        //1�� �� ����
        Destroy(blood, 1f);
    }

    void Update()
    {
        
    }
}

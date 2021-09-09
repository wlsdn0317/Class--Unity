using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pooling : MonoBehaviour
{
    //������Ʈ Ǯ��(Object Pooling)
    //���α׷������� �⺻������ ������Ʈ�� ������ ������
    //�ϴµ� �������� ���� ó���� �ʿ��ϴ�.
    //������ ���� Ʋ�� ������Ʈ�� ������ ������
    //���� �ֱ�� �ݺ��Ѵٸ� cpu�� �������� ���ϰ� ��������
    //��ü���� ���� �����ս��� �������� �ȴ�.
    //�׷��� ������Ʈ�� �Ź� �����ϰ� ���� ����� ���� �ƴ϶�
    //���� ��� ����� ��Ȱ��ȭ ��Ű��
    //���� ���, ��Ȱ��ȭ�ƴ� ����� �ٽ� �����ͼ�
    //Ȱ��ȭ���� ��Ȳ���� �� �ֵ��� ����� ��ğ�
    //������Ʈ Ǯ���̶�� �θ���.
    static private pooling inst = null;
    public GameObject bulletPref;   //Ǯ������ �����ϰ�
                                    //������ ��� ������Ʈ�� ������

    Queue<GameObject> bullets = new Queue<GameObject>();
                                    //Ǯ���� �����ϰ� �ִ� ������Ʈ��
                                    //������ �ʾҰų�
                                    //����� ���� ������Ʈ

    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    static public pooling Inst
    {
        get
        {
            if(inst == null)
            {
                return null;
            }
            else
            {
                return inst;
            }
        }
    }

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject b= Instantiate(bulletPref);
            bullets.Enqueue(b);
            //������ �Ѿ��� ť�� �ְ�
            b.SetActive(false);
            //���� ������� ���� �Ѿ��̱� ������
            //active�� ���ش�.
            b.transform.SetParent(this.transform);
            //�Ѿ��� �θ� �������� ����ȭ �Ǿ� ������ �ȵǱ� ������
            //��������� �Ѿ��� �θ�� Ǯ�� ��ü�� �ȴ�.
        }   
    }
    public GameObject getBullet()
    {
        if (bullets.Count == 0)
        {
            //��������� ������ ������
            //==�̹� ��� �Ѿ��� ������̸�
            //���ο� �Ѿ��� ���� �����Ѵ�.
            GameObject tmp = Instantiate(bulletPref);
            tmp.transform.SetParent(null);
            return tmp;
        }
        else
        {
            GameObject tmp = bullets.Dequeue();
            //����� ���� �Ѿ��� ������
            tmp.SetActive(true);
            //Ȱ��ȭ��Ű��
            tmp.transform.SetParent(null); 
            return tmp;
            //�Ѿ��� �Լ��� �θ������� ��ȯ���� ������ �Ѵ�.
        }
    }

    public void returnBullet(GameObject tmp)
    {
        //����� ���� ��ü�� ��ȯ�޴� �Լ�
        tmp.SetActive(false);
        //��ü�� ��Ȱ��ȭ ��Ű��
        bullets.Enqueue(tmp);
        //ť�� �־��ְ�
        tmp.transform.SetParent(this.transform);
        //�θ� �ٽ� Ǯ������ �ٲ��ش�
    }


    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mySingle : MonoBehaviour
{
    //������ü�� �̿��� �̱��� ����
    //�̱���: ���α׷��� �����ϴ� ����
    //���� �ϳ��� �����ؾ��ϴ� ����� ��������
    //(���� ��ȯ�ǵ�, �ٸ� Ŭ�������� �ش� ����� ����ؾ� �ϵ�)
    //;��� ��Ȳ���� ����� �ϳ����� ���� ����ϵ���
    //���ִ� ���α׷� ����(������ ����)

    static private mySingle instance = null;
    //Ŭ������ü�� ���������� �����ϰ� null�� �ʱ�ȭ�Ѵ�.
    //�Ϲ������� Ŭ������ü�� ���������� �����Ҷ���
    //private�� �����Ѵ�.

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            //static ������ null�̶�� ����
            //�ش� �Լ��� ���°� ó���̶� ���̱� ������
            //(�ش� Ŭ������ü�� ���� ó�� ������)
            //static���� instance�� �ڱ��ڽ��� �ִ´�.
            //�ٸ� ���������� �Ȱ� Ŭ������ü ���̱� ������
            //����Ƽ ���ӿ�����Ʈ�� ���� �Ѿ�� �����ȴ�.
            //�׷��� Ŭ������ �Բ� ���ӿ�����Ʈ�� �������� �ʵ���
            //DonDestroyOnLoad�� �ش� Ŭ���� ��ü�� ������Ʈ�� ������
            //���ӿ�����Ʈ�� �߰��Ͽ� ������ ������.
        }
        else
        {
            Destroy(this.gameObject);
            //�̹� instance�� �����Ѵٸ�
            //�ߺ��� ��ü�� �������� �ʵ���
            //������ ������Ʈ�� �����Ѵ�.
        }
    }

    static public mySingle Instance
    {
        //�̱������� ���� Ŭ���� ��ü instance��
        //Ŭ������ ���ԵǾ� �ֱ� ������
        //����Ϸ��� Ŭ������ �����ؾ� �Ѵ�.
        //�׷��� �̹� ������ Ŭ������ ������
        //�ߺ������� �������� �����ϱ� ������
        //���Ե� instance�� ����� �� ���ٴ� ����� �����.
        //������ �̸� �ذ��ϱ� ���ؼ�
        //��ü�� ������ �ʾƵ� �ش� ������ ������ �� �ֵ���
        //static���� �Լ��� �����.
        get{
            if (instance == null)
            {
                //Ŭ������ü�� �ѹ��� �������� ���ٸ�
                //�������� ���ϵ��� null�� ��ȯ
                return null;
            }
            return instance;
        } 
    }

    public int i;
    public int i2;

    public void printLog()
    {
        Debug.Log("i:" +i);
        Debug.Log("i2:" +i2);

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

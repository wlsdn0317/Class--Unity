using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //��������Ʈ�� ����ؼ� CalcDelegate��������Ʈ ����
    //�����ϰ��� �ϴ� �Լ��� �Ű������� ��ġ����ߵ�
    delegate void CalcDelegate(int num);
    CalcDelegate cd;


    void Start()
    {
        //�Ϲ����� �Լ� ȣ���� �Լ����� ������ �� ȣ����        
        //OnePlus(1);
        //TwoPlus(1);

        cd = OnePlus;
        cd(1); //��������Ʈ ȣ��

        cd = TwoPlus;
        cd(1);//��������Ʈ ȣ��
    }

    void OnePlus(int num)
    {
        int result = num + 1;
        print(result);
    }

    void TwoPlus(int num)
    {
        int result = num + 2;
        print(result);
    }
}

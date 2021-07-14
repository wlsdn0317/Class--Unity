using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //델리게이트를 사용해서 CalcDelegate델리게이트 생성
    //연결하고자 하는 함수의 매개변수는 일치해줘야됨
    delegate void CalcDelegate(int num);
    CalcDelegate cd;


    void Start()
    {
        //일반적인 함수 호출은 함수명을 일일히 다 호출함        
        //OnePlus(1);
        //TwoPlus(1);

        cd = OnePlus;
        cd(1); //델리게이트 호출

        cd = TwoPlus;
        cd(1);//델리게이트 호출
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    const string bulletTag = "BULLET";
    float iniHp = 100f; //초기 체력
    public float currHp; //현재 체력
    
    //델리게이트 선언
    public delegate void PlayerDieHandler();
    //델리게이트를 활용한 이벤트 선언
    public static event PlayerDieHandler OnPlayerDieEvent;







    // Start is called before the first frame update
    void Start()
    {
        currHp = iniHp;    
    }

    //충돌이 아니라 관통일 경우에 사용하는 함수
    private void OnTriggerEnter(Collider other)
    {
        //충돌한 물체의 태그 비교
        if(other.tag == bulletTag)
        {
            Destroy(other.gameObject);
            currHp -= 5; //체력5감소
            print("현재체력 -" + currHp);
            
            if(currHp <= 0f)
            {
                //플레이어 사망 함수 호출
                PlayerDie();
            }
        }
    }

    void PlayerDie()
    {
        OnPlayerDieEvent();



        //print("플레이어 사망");
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("ENEMY");

        //for(int i = 0; i < enemies.Length; i++)
        //{
        //    //함수 호출 방법은 다음과 같다.
        //    //아래와 같이 직접 호출 하는 방법
        //    //enemies[i].GetComponent<EnemyAI>().OnPlayerDie();
        //    //아래와 같이 SendMessage로 호출하는 방법
        //    enemies[i].SendMessage("OnPlayerDie",SendMessageOptions.DontRequireReceiver);
        //    //세번째 델리게이트 호출 방법
        //}



    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

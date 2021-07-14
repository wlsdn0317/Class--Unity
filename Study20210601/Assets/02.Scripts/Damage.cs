using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    const string bulletTag = "BULLET";
    float iniHp = 100f; //초기 체력
    public float currHp; //현재 체력

    //델리게이트 선언
    public delegate void PlayerDieHandler();
    //델리게이트를 활용한 이벤트 선언
    public static event PlayerDieHandler OnPlayerDieEvent;

    public Image bloodScreen;
    public Image hpBar;
    readonly Color initColor = new Vector4(0, 1f, 0, 1f);
    Color currColor;

    void Start()
    {
        currHp = iniHp;
        hpBar.color = initColor;
        currColor = initColor;
    }

    void DisplayHpbar()
    {
        if ((currHp / iniHp) > 0.5f) //현재 체력이 50퍼 보다 클때
            //녹색 > 노란색
            currColor.r = (1 - (currHp / iniHp)) * 2.0f;
        else //0% 까지는 노란색 >  빨간색
            currColor.g = (currHp / iniHp) * 2f;

        hpBar.color = currColor; //체력 게이지 색상 적용
        hpBar.fillAmount = (currHp / iniHp); //체력 게이지 크기 조정
    }

    //충돌이 아니라 관통일 경우에 사용하는 함수
    private void OnTriggerEnter(Collider other)
    {
        //충돌한 물체의 태그 비교
        if (other.tag == bulletTag)
        {
            Destroy(other.gameObject);

            StartCoroutine(ShowBloodScreen());

            currHp -= 5; //체력 5감소
            //print("현재 체력 - " + currHp);

            DisplayHpbar();

            if (currHp <= 0f)
            {
                //플레이어 사망 함수 호출
                PlayerDie();
            }
        }
    }

    void PlayerDie()
    {
        OnPlayerDieEvent();
        //싱글턴 패턴을 활용하여 게임이 종료되었음을 바로 전달하도록 함
        GameManager.instance.isGameOver = true;

        //print("플레이어 사망");
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("ENEMY");

        //for(int i = 0; i < enemies.Length; i++)
        //{
        //    //함수 호출 방법은 다음과 같다.
        //    //아래와 같이 직접 호출 하는 방법
        //    //enemies[i].GetComponent<EnemyAI>().OnPlayerDie();
        //    //아래와 같이 SendMessage로 호출하는 방법
        //    enemies[i].SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        //    //세번 째 델리게이트 호출방법
        //}

    }

    IEnumerator ShowBloodScreen()
    {
        bloodScreen.color = new Color(1, 0, 0, Random.Range(0.2f, 0.3f));
        yield return new WaitForSeconds(0.1f);
        bloodScreen.color = Color.clear; //깨끗히 지우기
    }

    void Update()
    {
        
    }
}

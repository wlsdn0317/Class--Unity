using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    float g_Velocity;//중력가속도
                     //시간이 지날수록 증가함

    Rigidbody2D rb;
    //플레이어 비행기의 리지드바디

    bool hittable;
    //플레이어의 무적상태 여부를 알려주는 변수

    public int hp = 3;
    //플레이어의 현재 체력 수치

    public GameManager gm;
    //게임매니저 객체를 참조하여 게임어 등을 호출하도록 함

    public GameObject[] hpImage;
    //플레이어의 체력아이콘을 저장할 게임오브젝트 배열
    //C#에서는 배열을 나타내는 대괄호가
    //변수명이 아닌 자료형 뒤에 붙는다.
    //배열의 크기역시 선언할때는 넣어주지 않는다.
    //배열의 크기는 배열이 초기화될때 결정이 된다.
    


    void Start()
    {
        g_Velocity = 0;
        rb = this.GetComponent<Rigidbody2D>();
        hittable = true;
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //마우스 키는 마우스에 따라서 갯수에 차이가 나기 때문에
            //키보드처럼 Keycode를 사용하지 않고
            //숫자로 사용한다.
            //0:왼쪽, 1:오른쪽, 2:휠클릭


            rb.AddForce(Vector2.up *2,ForceMode2D.Impulse);
            //위쪽방향으로 힘을 가한다.
            
            //AddForce에 매개변수를 추가로 넣을 수 있으며
            //해당 매개변수는 어떤방식으로 가할지를 나타낸다.
            //ForeceMode.Impulse는 순간적으로 강한 힘을 가하며
            //ForceMode.Force는 힘을 전체에 고루 퍼뜨리는 방식이다.
            //Impulce는 보통 게임에서 점프를 구현할 때 사용하며
            //Force는 캐릭터를 이동시킬때 사용한다.
        }
    }

    void makeGravity()
    {
        //리지드바디를 이용하지 않고
        //코드를 통해 직접 중령을 구현하는 방법

        g_Velocity += Time.deltaTime;
        //시간에 비례해서 중력가속도가 증가한다.

        this.transform.position += Vector3.down * g_Velocity;
        //플레이어의 좌표가 중력가속도 크기만큼
        //아래로 내려간다.
    }

    public void call_Hit()
    {
        StartCoroutine(isHit());
        //코루틴함수의 실행은
        //함수를 실행시킨(StartCoroutine)주체에게
        //종속되기 때문에
        //해당 주체가 삭제되면 함수의 실행이 도중에 정지된다.
        //따라서 대상이 삭제되는 구조라면
        //삭제되지 않는 대상에서 함수를 부르도록 만드는 편이 좋다.
    }

    IEnumerator isHit()
    {
        

        if (hittable == true)//플레이가 때릴 수 있는 상태면
        {
            hp--;
            //장애물과 충동했으므로 체력을 1 감소시킨다.

            if(hp <= -1)
            {
                //체력이 모두 감소하면
                gm.gameOverFunc();
                //게임매니저에게서 게임오버 함수를 호출
            }

            damage();
            //체력이 감소된 뒤에 아이콘을 꺼주는 함수를 실행

            hittable = false;
            //플레이어가 충동했기때문에
            //중복충돌하지 않도록
            //hittable을 false로 변경

            //플레이어가 장애물과 부딪혔을때 실행시킬 코루틴 함수
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    this.GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().enabled = true;
                }
                yield return new WaitForSeconds(0.1f);
            }
            hittable = true;
            //무적이 끝나면(점멸이 끝나면) 다시 충돌 가능한 상태로
            //bool값을 변경시켜준다.
        }
        else
        {
            yield return null;
        }
    }

    void damage()
    {
        if (hp >= 0)
        {
            hpImage[hp].SetActive(false);
        }
    }
    




}

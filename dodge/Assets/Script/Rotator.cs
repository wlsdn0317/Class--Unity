using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    float rotate_speed = 50;
    //맵의 회전 속도

    void Start()
    {
        
    }

  
    void Update()
    {
        this.transform.Rotate(0,rotate_speed*Time.deltaTime, 0);

        //닷지게임의 난이도를 바꾸고 싶다면
        //맵의 회전속도를 높여서 사방에서 총알이 날아오게 하거나
        //총알의 발사주기를 짧게해서 많은 총알이 생성되게 하거나
        //플레리어의 체력을 적게해서 기회를 적게 주거나
        //플레이어의 이동속도를 조절해서 난이도를 변경할 수 있다.

        //이외에도 총알의 크기를 바꾸거나, 총알의 속도를 바꾸는 등
        //여러가지 방법으로 게임의 난이도를 조절해줄 수 있다.
    }
}

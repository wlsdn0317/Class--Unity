using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bSpawner : MonoBehaviour
{
    public GameObject bullet;
    //생성할 총알의 프리팹을 저장할 변수

    float bulletDelay = 0;
    //총알을 생성하는 딜레이;

    public Transform playerTrans;
    //총알을 발사할 대상인 플레이어의 위치를
    //확인하기 위해 플레이어를 변수로 가진다.

    void Start()
    {
        
    }

  
    void Update()
    {
        //업데이트 함수는 1프레임에 1번 실행된다.
        
        bulletDelay += Time.deltaTime;
        //time.deltatime : 이전프레임에서 현재프에임이
        //실행되기까지 걸린 시간을 가져온다.

        if(bulletDelay >= 1f)
        {
            //소수점을 조건문에서 사용할 경우
            //기준값과 ==으로 조건을 체크하는것은 사실상 불가능
            //소숫점 이하가 계속해서 오차가 발생하기 때문에
            //== 보다는 범위를 통해서 조건을 주는것이 좋다.
            
            bulletDelay -= 1f;
            //기준값인 3초가 넘었기 때문에
            //3초를 시간에서 빼주고
            //다시 카운트를 하도록 만들어 준다.

            Vector3 dir = playerTrans.position - this.transform.position;
            //목적지 방향으로 향하는 벡터를 구하려면
            //목적지 - 출발지 좌표









           GameObject tmp = Instantiate(bullet,this.transform);
            //프리팹이나 게임오브젝트 데이터를 이용해서 
            //동일한 복사된 오브젝트를 생성해주는 함수

            //생성된 게임오브젝트를 반환하기 때문에
            //매개변수를 만들어 반환된 게임오브젝트를 저장하면
            //생성된 게임오브젝트의 데이터를 일부 수정할 수 있다.
            tmp.transform.position -= Vector3.up * 1;


            tmp.transform.forward = dir;
            //총알의 '앞'방향을
            //위에서 구한 방향으로 변경 
        }
    }
}

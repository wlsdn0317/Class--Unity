using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eStatus
{
    IDLE,   //대기
    WANDER, //주변 배회
    CHASE,  //추적
    ATTACK, //공격
    RUN,    //도망
}
public class Enemy : MonoBehaviour
{
    public eStatus myStatus = eStatus.IDLE;

    public Transform target; //몬스터가 인식한 대상

    public int hp = 10;

    public Vector3 wanderingPos = Vector3.zero;//배회할때의 목적지

    float waitingTime = 0; //idle이나 wandering의 대기시간
    float attackDelay = 0;  //공격 딜레이값
    void Start()
    {
        
    }

    void Update()
    {
        changeStatus();
        Action();
    }

    void changeStatus()
    {
        //상태의 변화에는 우선순위가 존재하며
        //우선시 되어야 하는 상태는
        //코드상에서 먼저 작성해주는 편이 좋다.
        if (hp <= 3)
        {
            myStatus = eStatus.RUN;
        }
        else if (Vector3.Distance(this.transform.position, target.position) < 1)
        {
            myStatus = eStatus.ATTACK;
        }
        else if (Vector3.Distance(this.transform.position, target.position) < 5)
        {
            //타겟과의 거리가 5 이하면
            myStatus = eStatus.CHASE;
            //타겟을 추적
        }
        else
        {
            waitingTime += Time.deltaTime;
            if (waitingTime > 3)
            {
                waitingTime -= 3;
                int i = Random.Range(0, 2);
                if (i == 0)
                {
                    myStatus = eStatus.IDLE;
                }
                else if (i == 1)
                {
                    wanderingPos = new Vector3(Random.Range(-25.0f,25.0f), 0.5f, Random.Range(-25.0f, 25.0f));
                    //새로운 방황을 시작할때 마다 방황의 목적지를
                    //새롭게 설정해준다.
                    //목적지는 필드 범위 내에서 잡혀야 하기 때문에
                    //랜덤 범위 역시 좌표를 이동가능한 범위 내로 제한한다.
                    myStatus = eStatus.WANDER;
                }
            }
        }
    }

    void Action()
    {
        if (myStatus == eStatus.CHASE)
        {
            Vector3 dir = target.position - this.transform.position;
            dir = dir.normalized;
            this.transform.Translate(dir * Time.deltaTime);
        }
        else if (myStatus == eStatus.RUN)
        {
            Vector3 dir = target.position - this.transform.position;
            dir = dir.normalized;
            if (Vector3.Distance(this.transform.position, target.position) < 5)
            {
                this.transform.Translate(-dir * Time.deltaTime);

            }
            else
            {
                myStatus = eStatus.IDLE;
                hp += 1;
            }

            //player 반대방향으로 도주
        }
        else if (myStatus == eStatus.WANDER)
        {
            Vector3 dir = wanderingPos - this.transform.position;
            dir = dir.normalized;
            this.transform.Translate(dir * Time.deltaTime);
            //랜덤이동할 위치로 방향값을 계산하고
            //해당 위치로 이동시킨다.

            if (Vector3.Distance(wanderingPos, this.transform.position) < 0.1f)
            {
                waitingTime = 3;
                //시간이 다 지나기 전에 목적지에 도착했다면
                //시간값을 최대치로 줘서
                //다시 idle이나 wandering을 체크하도록
                //만들어 준다.
            }
        }
        else if (myStatus == eStatus.ATTACK)
        {
            attackDelay -= Time.deltaTime;
            if (attackDelay <= 0)
            {
                Player player = target.GetComponent<Player>();
                player.hp--;
                attackDelay = 3;
            }
        }
    }

    
        
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Script : MonoBehaviour
{
    GameObject targetPos;
    //적 캐릭터가 목표로 해야하는 대상의 위치 == 플레이어

    Vector3 dir;//적의 이동 방향

    float delay = 1;//총알이 연속으로 발사되는 주기
    float pressTime = 0;
    public GameObject Laser;

    public GameObject[] bolts;





    void Start()
    {
        targetPos = GameObject.Find("Player");
        //목표물을 찾아서 변수에 저장

        
        //목표물로 가는 방향을 구해서 변수로 저장
        //방향 : 목표물위치 - 현재위치
    }


    void Update()
    {
        if (targetPos != null)
            //target 즉 플레이어가 존재할때만
            //에너미가 플레이어 방향으로 움직이고
            //플레이어 방향으로 총알을 발사한다.
            //플레이어가 총알을 맞고 삭제된다면
            //더이상 이동도, 발사도 하지 않게 된다.
        
        {



            dir = targetPos.transform.position - this.transform.position;
            //방향의 계산을 업데이트에 넣어주면
            //실시간으로 타겟과 자신의 위치를 기준으로
            //새로운 방향을 계산해서 이동하기 때문에
            //유도탄처럼 동작하는 오브젝트를 만들 수 있다.

            //벡터에는 방향과 크기가 모두 포함이 되어 있어서
            //단순 벡터를 이용해서 이동을 시키게 되면
            //크기(거리)에 따라 이동속도에 차이가 발생하게 된다.
            //그래서 계산한 벡터에서 크기를 배제하고
            //방향만을 가지고 이동을 시켜야 하는데
            //이때 필요한 것이 벡터의 normalize(단위벡터)이다.

            if (Vector3.Distance(this.transform.position, targetPos.transform.position) > 1)
            {
                //Vector3.Distance(1,2) : 두벡터 사이의 '거리'를 구해주는 함수
                //거리값은 float형으로 반환된다.

                dir.z = 0;
                dir = dir.normalized;
                //단위벡터는 벡터의 크기를 1로 통일한 벡터이다.
                //그래서 모든 단위벡터는 동일한 크기를 가지며
                //오직 방향만 차이가 나게 된다.


                //this.transform.position += dir * Time.deltaTime * 1f;
                //적 비행기가 플레이어 방향으로 내려오도록


                this.transform.forward = dir;
                //해당 오브젝트의 정면 방향을 변경
                this.transform.position += this.transform.forward * Time.deltaTime;
                //이동방향은 해당 오브젝트가 바라보면 정면(forward)으로 이동시킴

                pressTime += Time.deltaTime;
                if (pressTime >= delay)
                {
                    pressTime -= delay;
                    //스페이스바를 누르면 delay초마다 총알이 발사됨.
                    GameObject obj = Instantiate(Laser, this.transform.position, Quaternion.identity);
                    //플레이어 위치에서 레이저를 발사
                    obj.transform.up = this.transform.forward;
                    //레이저의 진행방향 == 에너미의 진행방향
                    //레이저의 up == 에너미의 foward가 되도록 값을 변경

                    obj.GetComponent<laser_Script>().setTaegetTag("Player");
                    //에너미가 생성한 총알은 에너미가 아닌 플레이어와
                    //부딪혔을때 삭제가 된다.

                }




            }
            // Quaternion q = Quaternion.LookRotation(targetPos.transform.position);
            //Quaternion.LookRotation
            //지정한 대상 방향으로 향하는 각도값을 자동으로 계산해주는 함수
            // this.transform.rotation = q;
        }
        
    }
    public void drop_boltItem()
    {
        int r = Random.Range(0, 3);
        Instantiate(bolts[r], this.transform.position, Quaternion.identity);
    }
}

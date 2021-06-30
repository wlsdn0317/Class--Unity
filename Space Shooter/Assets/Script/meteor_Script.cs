using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor_Script : MonoBehaviour
{

    GameObject targetPos;
    //적 캐릭터가 목표로 해야하는 대상의 위치 == 플레이어

    Vector3 dir;//적의 이동 방향


    void Start()
    {
        targetPos = GameObject.Find("Player");
        //목표물을 찾아서 변수에 저장
        dir = targetPos.transform.position - this.transform.position;
        //목표물로 가는 방향을 구해서 변수로 저장
        //방향 : 목표물위치 - 현재위치
        dir.z = 0;
        dir = dir.normalized;

    }




    void Update()
    {
        this.transform.forward = dir;
        //해당 오브젝트의 정면 방향을 변경
        this.transform.position += this.transform.forward * Time.deltaTime;
        //이동방향은 해당 오브젝트가 바라보면 정면(forward)으로 이동시킴
        if (this.transform.position.y <= -6)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().damaged();
            Destroy(this.gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;            //카메라가 추적할 대상
    public float moveDamping = 15f;     //이동속도 계수
    public float rotateDamping = 10f;   //회전속도 계수
    public float distance = 5f;         //추적 대상과의 거리
    public float height = 4f;           //추적 대생과의 높이
    public float targetOffset = 2f;     //추적 좌표의 오프셋

    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    //콜백함수 - 호출을 따로하지 않아도 알아서 작동하는 함수.
    //이벤트 트리거 등 여러가지 사용법이 있음.
    // Update is called once per frame
    void LateUpdate()
    {
        var camPos = target.position                        //추적 대상 위치
                      - (target.forward * distance)         //추적 대상 거리
                      + (target.up * height);               //추적 대상과의 높이
        tr.position = Vector3.Slerp(tr.position,                        //Slerp 보간함수
                                     camPos,
                                     Time.deltaTime * moveDamping);    //벡터 위치 //원만한 이동
        tr.rotation = Quaternion.Slerp(tr.rotation,
                                       target.rotation,
                                       Time.deltaTime * rotateDamping);//쿼터니언 회전 //원만한 회전
        tr.LookAt(target.position + (target.up*targetOffset)); //기존의 발바닥을 쳐다보던 카메라를 오프셋만큼 윗쪽(정수리)를 보도록 수정



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //DrawWireSphere(위치,지름)
        //선으로 이루어진 구형의 모양을 그림(씬뷰에만 표시됨,.디버그용)
        Gizmos.DrawWireSphere(target.position + (target.up * targetOffset), 0.1f);
        //메인 카메라와 추적 지점 사이에 선을 그림
        //DrawLine(출발시점, 도착지점)
        //출발과 도착지점 사이에 선을 그림
        Gizmos.DrawLine(target.position + (target.up * targetOffset), transform.position);
    }
}

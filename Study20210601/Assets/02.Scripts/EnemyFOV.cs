using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{

    public float viewRange = 15f; //적의 추적 사정 거리 범위
    [Range(0, 360)]
    public float viewAngle = 120f; //시야각 최소 0~360

    Transform enemyTr;
    Transform playerTr;
    int playerLayer;
    int obstacleLayer;
    int layerMask;

    private void Start()
    {
        enemyTr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").transform;

        playerLayer = LayerMask.NameToLayer("PLAYER");
        obstacleLayer = LayerMask.NameToLayer("OBSTACLE");
        layerMask = 1 << playerLayer | 1 << obstacleLayer;
    }

    public bool isTracePlayer()
    {
        bool isTrace = false;

        Collider[] colls = Physics.OverlapSphere(enemyTr.position
                                                 , viewRange
                                                 , 1 << playerLayer);
        if(colls.Length == 1) //플레이어가 존재한다면
        {
            Vector3 dir = (playerTr.position - enemyTr.position).normalized;
            //적의 시야각에 들어왔는지 판단
            if (Vector3.Angle(enemyTr.forward, dir) < viewAngle * 0.5f)
            {
                isTrace = true;
            }
        }
        return isTrace;
    }
    public bool isViewPlayer()
    {
        bool isView = false;
        RaycastHit hit;

        Vector3 dir = (playerTr.position - enemyTr.position).normalized;

        if(Physics.Raycast(enemyTr.position,dir,out hit, viewRange, layerMask))
        {
            isView = (hit.collider.CompareTag("PLAYER"));
        }
        return isView;
    }


    public Vector3 CirclePoint(float angle)
    {
        //로컬 좌표계 기준으로 설정하기 위해 
        //적 캐릭터의 회전값중 Y값 더함
        angle += transform.eulerAngles.y;
        //angle = 60도 >>> 라디안 값으로 변환
        //각도(디그리) >>라디안 값으로 변환하는 함수가 Mathf.Deg2Rad
        Vector3 viewAngle = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad)
                                        , 0
                                        , Mathf.Cos(angle * Mathf.Deg2Rad));

        return viewAngle;
    }
}

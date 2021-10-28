using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//네비매쉬를 쓰려면 ai를 using으로 가져와야 한다.

public class NavCtrl : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        //네비게이션 상에서 에이전트의 이동은
        //에이전트가 움직이고, 게임오브젝트의 좌표는
        //에이전트를 따라서 변경된다.

        //때문에 네비게이션 기능을 쓰는 경우
        //네비게이션의 움직임에 영향을 줄 수 있는
        //리지드바디를 사용하지 않아야 한다.

        //만약, 에이전트를 사용하는 오브젝트의 좌표를
        //강제로 변경해야하는 경우가 있다면
        //오브젝트의 좌표를 변경하지 않고(position = 좌표는 사용하지 않는다.)
        //에이전트의 좌표를 변경한다.
        //agent.Warp(Vector3.zero);
        //에이전트의 좌표를 강제로 변경할때는
        //warp함수를 사용한다.
    }

    void Update()
    {
        agent.SetDestination(target.position);

        //off mesh link
        //서로 직접적으로 이어져있지 않은 네비게이션 사이를
        //연결해주는 기능
        //drop height : 높은곳에서 낮은곳으로 연결해주는 기능
        //jump distance : 같은 높이에서 서로 떨어져 있는 지형 사이를
        //              점프해서 건너갈 수 있도록 연결해주는 기능
        //              건너갈 위치의 높이 차이가 있으면 생성되지 않는다.
    }
}

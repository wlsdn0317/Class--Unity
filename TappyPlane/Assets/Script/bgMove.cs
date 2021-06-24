using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMove : MonoBehaviour
{
    public Transform targetPos;
    //배경이 화면 밖으로 나가게 됐을때
    //현재 화면에 보이는 배경 뒤로 다시 이동해야 하기 때문에
    //해당 배경을 가지고 있어야 뒤로 갈수 있다.


    public float limitPos;//밖으로 나갔는지 판단하는 X좌표
    public float movePos;//밖으로 나갔을때 이동하는 X좌표
    public float movingSpeed; //배경의 이동속도
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime*movingSpeed;
        if (this.transform.position.x <= limitPos)
        {
            this.transform.position += Vector3.right * movePos;
        }
    }
}

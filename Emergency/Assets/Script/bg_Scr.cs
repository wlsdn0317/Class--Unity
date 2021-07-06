using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bg_Scr : MonoBehaviour
{
    public Transform targetPos;
    public float limitPos;//밖으로 나간 y좌표
    public float movePos;//이동하는 y좌표
    public float movingSpeed;//이동속도
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * movingSpeed;//시간*스피드 속도로 화면 이동
        if (this.transform.position.y <= limitPos)
        {
            this.transform.position += Vector3.up * movePos;
        }
    }
}

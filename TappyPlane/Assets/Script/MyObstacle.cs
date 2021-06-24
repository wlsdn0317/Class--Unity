using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObstacle : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position += Vector3.left * 4 * Time.deltaTime;

        if(this.transform.position.x < -8)
        {
            //장애물이 화면 밖으로 완전히 나갔을 때
            Destroy(this.gameObject);
            //자기자신을 스스로 삭제
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Plane")
        {
            Debug.Log("Hit");

            collision.GetComponent<PlayerScr>().call_Hit();
            //코루틴 함수는 함수를 단순히 호출만 해서는 정상적으로 동작하지 않으며
            //반드시 StartCoroutine을 통해서 함수를 실행시켜야 한다.
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObstacleUpper : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position += Vector3.left * 4 * Time.deltaTime;
        //장애물을 왼쪽으로 이동
        if(this.transform.position.x <= -4)
        {
            //왼쪽 화면 밖으로 완전히 나가면
            Vector3 resetPos = this.transform.position;
            resetPos.x += 8;
            //오른쪽 화면 밖으로 이동
            resetPos.y = Random.Range(1.5f, 2.5f);
            //높이를 랜덤하게
            this.transform.position = resetPos;
            //설정된 좌표를 대입

            //transform.Position의 x,y,z값을
            //각각 따로 바꿀수 없기 때문에
            //위처럼 별도의 변수에 저장하고
            //수치를 수정한 뒤에 다시 대입해주고 있다.

           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Plane")
        {
            Debug.Log("Hit");

            collision.GetComponent<PlayerScr>().call_Hit();
            //코루틴 함수는 함수를 단순히 호출만 해서는 정상적으로 동작하지 않으며
            //반드시 StartCoroutine을 통해서 함수를 실행시켜야 한다.
        }
    }

}

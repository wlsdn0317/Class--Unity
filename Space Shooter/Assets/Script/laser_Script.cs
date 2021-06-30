using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_Script : MonoBehaviour
{
    public GameObject laserEff;
    //레이저가 적과 부딪혔을때 부딪히는 효과를 나타내줄
    //애니메이션 오브젝트

    Vector3 dir= Vector3.up;//레이저가 날아가야할 방향값을 저장하는 변수

    string targetTag= "enemy";//레이저가 충돌할 대상의 태그값
                              //초기값은 enemy
    public void setTaegetTag(string str)
    {
        targetTag = str;
    }

    void Start()
    {

       
        Destroy(this.gameObject, 4.0f);
    }

    
    void Update()
    {
        this.transform.position += this.transform.up *Time.deltaTime*3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {//상대방과 부딪히면

            Vector2 contactPoint = collision.ClosestPoint(this.transform.position);
            //콜라이더간의 충돌이 일어났을때
            //충동한 지점의 좌표를 반환해주는 함수


            GameObject eff = Instantiate(laserEff, contactPoint, Quaternion.identity);
            Destroy(eff, 0.2f);

            if (collision.tag == "Player")
            {
                collision.GetComponent<PlayerController>().damaged();
            }
            else
            {
                collision.GetComponent<enemy_Script>().drop_boltItem();
                Destroy(collision.gameObject);//상대방 삭제
            }




            
            Destroy(this.gameObject);//총알도 삭제
        }
    }



    public void setDir(Vector3 v)
    {
        //public이 아니게된 dir변수의 값을
        //바꿔주는 함수
        dir = v;
        //public이 아닌 변수는 외부에서 접근할 수 없기때문에
        //외부에서는 변수에 대입해줄 값만 함수를 통해 전달하고
        //실제로 변수값을 변경하는 것은 해당 스크립트에서 하도록 만듬.
    }
}

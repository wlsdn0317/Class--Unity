using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float speed = 8f;
    Rigidbody bulletRigidbody;


    
    void Start()
    {
        bulletRigidbody = this.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = this.transform.forward*3;
        //Vector3.forward
        //방향값을 나타내주는 Vector3.forward~ 종류의 변수들은
        //게임씬을 기준으로 하는 변하지 않는 방향값이기 때문에
        //움직이는 대상이 어디있는 어느 방향을 향하든, 누구의 잣힉으로 있든
        //항상 똑같은 방향으로 이동하게 된다.

        //this.transform.forward
        //백터3에서 방향값을 가져오게 되면
        //어떠한 상황에도 변하지 않는 고정된 절대적인 방향이 되지만
        //특정한 게임오브젝트(대상)으로부터 방향을 가져오게 되면
        //해당 대상이 바라보는 방향을 기준으로 하여
        //앞뒤상하좌우가 결정이 된다.
        //어떠한 경우에도 변함없는 방향이 아닌
        //대상이 어디를 바라보느냐에 따라 그방향이 유동적으로 변하는
        //상대적인 방향이 된다.

        Destroy(this.gameObject, 3f);
        //Destroy함수에 매개변수로 대상 오브젝트와 시간을 주게 되면
        //해당 시간이 지나면 자동으로 삭제가 된다.

    }

   
    void Update()
    {
        
    }
    
    //대상의 collider가
    // 다른 대상과 부딪혔을때(enter)
    //닿고 있는 동안 계속(stay)
    //닿았던 것이 떨어질때(Exit)
    //자동으로 실행되는 함수
    private void OnCollisionEnter(Collision collision) 
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        //Destroy함수 : 매개변수로 전달받은 대상을
        //삭제해주는 함수
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }

    








    }

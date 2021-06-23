using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  BulletScript : MonoBehaviour
{
    float speed = 8f;
    Rigidbody bulletRigidbody;
    GameManager gm;
    
    //갱신할 Hp판
    //총알은 처음부터 게임화면에 존재하지 않기 때문에
    //게임화면에 존재하는 대상을 public변수로 입력받은채로
    //시작할 수 없다.
    //(총알이 다른 씬에서 생성될수도 있기 때문에)
    //따라서 에디터에서 대상을 넣어주는게 아닌
    //스크립트에서 능동적으로 해당 대상을 찾아서 가져올 수 있도록 해야한다.


    void Start()
    {
        GameObject target = GameObject.Find("gManager");
        GameObject other = GameObject.Find("Player");
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        
        bulletRigidbody = this.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = this.transform.forward * 3;
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

        Destroy(this.gameObject, 10f);
        //Destroy함수에 매개변수로 대상 오브젝트와 시간을 주게 되면
        //해당 시간이 지나면 자동으로 삭제가 된다.

        
        //GameObject.Find("대상의 이름")
        //해당 이름을 가진 게임오브젝트를 게임씬에서 찾아서
        //반환해주는 함수
        if (target != null)
        {
            //찾으려는 대상이 존재할때만 컴포넌트를 가져옴
            gm = target.GetComponent<GameManager>();
        }
        //Find함수는 지정한 이름을 가진 대상이 존재하지 않으면
        //null을 반환하기 때문에
        //대상이 존재할때만 코드가 동작하도록
        //조건문을 통해서 선별을 해준다.
    }


    void Update()
    {



    }

    //대상의 collider가
    // 다른 대상과 부딪혔을때(enter)
    //닿고 있는 동안 계속(stay)
    //닿았던 것이 떨어질때(Exit)
    //자동으로 실행되는 함수

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            player.hp -= 1;

           
            //유니티에서 기본적으로 제공되는 컴포넌트 뿐만 아니라
            //사용자가 만든 스크립트 역시 컴포넌트로 취급이 된다.
            //따라서 getComponent로 스크립트를 가져올 수 있다.

            //스크립트상에서 선언된 변수에 접근하려면
            //해당 스크립트를 가진 게임오브젝트에게서
            //getComponent로 해당 스크립트를 가져와야 접근할 수 있다.

            if (player.hp <= 0)
            {
                player.die();
                gm.gameOver();

            }


            //스크립트 상에서 특정 대상을 삭제하는 코드가 존재한다면
            //해당 코드는 반드시 가장 마지막에 동작시켜야 한다.
            //삭제될 대상으로부터 동작하는 코드가 존대한다면
            //해당 코드의 동작이 정상적으로 이루어지지 않을 수 있기 때문
            Destroy(this.gameObject);
        }
        //Destroy함수 : 매개변수로 전달받은 대상을
        //삭제해주는 함수

        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }









}

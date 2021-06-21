using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody; //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; //이동속력
    //변수명 앞에 public이 붙으면
    //유니티 에디터에서 해당 변수를 직접 눈으로 확인하고
    //수정할 수 있게 된다.
    //단, 보안에 있어서는 취약해 지기 때문에
    //[SerializeField]라는 명령어를 통해서
    //에디터에서는 보이지만 변수는 여전히 private으로
    //남도록 만들 수 있다.
    void Start()
    {
        //클래스의 생성자와 동일한 역할을 하는 함수
        //해당 스크립트를 컴포넌트로써 가지고 있는
        //게임오브젝트가 게임화면에 생성되면
        //자동으로 실행되는 함수

        playerRigidbody = this.GetComponent<Rigidbody>();
        //this(플레이어)로 부터 컴포넌트를 가져온다 (GetComponent)
        //어떤 컴포넌트냐면 <Rigidbody>이다.
        //가져온 Rigidbody 컴포넌트를 반환받아
        //playerRigidbody에 대입한다.

        //에디터에서 변수를 대입하는 것과
        //스크립트에서 변수를 가져오는 것은 그 결과가 차이가 없지만
        //차이점으로는 에디터에서 가져오는 것은
        //해당 대상이 처음부터 존재할때만 가져올 수 있고
        //스크립트로 가져올때는 대상이 나중에 생성되더라도
        //가져올수 있다.
    }


    void Update()
    {
        //업테이트 함수는 게임이 실행되는 동안
        //1프레임마다 자동으로 호출되는 함수.
        //그래서 게임을 플레이하면서 실시간으로
        //지속적으로 실행해야하는 코드들을 이곳에 작성한다.
        //ex)키보드,마우스 조작
        bool b = true;
        //C++부터 추가된 변수형
        //참, 거짓을 표현하는 변수
        //참 :true
        //거짓 : false
        moveAxis();
       

    }


    //강체에 힘을 가해서 움직이는 방법
    void moveForce()
    {
        if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.UpArrow))
        {
            //여러가지 키보드에 중복대응되게 하려면
            //or 연산자를 통해 조건을 묶어주면된다.

            playerRigidbody.AddForce(Vector3.forward * speed * Time.deltaTime);
            //AddForce; 리지드바디(강체)에게
            //힘을 가해서 결과적으로 강체가
            //이동하도록(움직이도록)만들어주는 함수
            //매개변수로 힘을 가항 방향을 입력받으며
            //방향은 x,y,z축 방향을 모두 포함해야 하기 때문에
            //Vector3라는 클래스형을 사용한다.
            //forward는(0,0,1)방향을 나타낸다.
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            playerRigidbody.AddForce(Vector3.back * speed * Time.deltaTime);
        }
        //상하,좌우는 각각 중복해서 같이 누르지 않기 때문에
        //상하를 if-else if로, 좌우를 if-else if로 묶어준다.
        //대각선 이동을 위해서 상하키중 하나와 좌우키중 하나를
        //누를수 있기때문에 전체를 else if로 묶을 필요는 없다.
        if (Input.GetKey(KeyCode.A) == true)
        {
            playerRigidbody.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) == true)
        {
            playerRigidbody.AddForce(Vector3.right * speed * Time.deltaTime);
        }
        //Input.GetKeyDown:키보드를 누르는 순간을 인식
        //Input.GetKeyUP:눌렀던 키보드를 떼는 순간을 인식
        //Input.GetKey:키보드를 누르고 있는 동안 계속 인식

        //AddForce 함수는 강체에 힘을 가한 결과로써
        //오브젝트가 움직이게 하는 함수이기 때문에
        //즉각적인 움직임의 피드백이 가해지지 않는다.
        //일정 수준 이상의 힘을 줘야 오브젝트가 움직이며
        //속도 역시 서서히 증가하면서 움직인다.
        //또한 더 이상 힘을 주지 않더라도
        //기존에 주었던 힘을 모두 소모하기 전까지는
        //계속해서 감속하면서 오브젝트가 움직이게 된다.

        //60프레임 동작하는 게임에서 1프레임에 필요한 시간은
        //1/60초,즉 0.016초 정도가 걸린다.
        //30프레임 동작하는 게임에서는 1프레임에 1/30.0.032초가 소모된다.

        //업데이트 함수를 사용할때 프레임의 차이에 의한
        //동작의 오차를 보정해주기 위해서 프레임이 동작하는데 걸린 시간을
        //수치값에 곱해서 보정해주면 된다.

        //변수값을 public이나 SerializeField를 통해서
        //에디터에서 편집이 가능하도록 만든 경우
        //변수값은 스크립트에서 초기화해준 값 ->에디터에서 수정한 값 ->Start에서 수정한 값
        //순서로 변수값이 덮어 씌워진다.
        //때문에 스크립트에서 값을 바꿧다고 해도
        //에디터에서 다시 값을 덮어씌우기 때문에
        //변수값의 초기화를 애초에 start에서 하거나
        //혹은 에디터에서 수정되는 과정을 없애기 위해
        //public이나 SerializeField를 지워주면 된다.

    }

    //강체의 속도를 직접 지정하는 방법
    void moveVelocity()
    {

        Vector3 myVelocity = Vector3.zero;
        //내가 누른 방향을 저장하는 변수
        //함수에 들어올때마다 새로 만들기 때문에
        //속도가 누적될 염려를 하지 않아도 되고
        //속도값을 즉시 사용하는게 아니라
        //이 변수에 각 방향을 모두 더한 후에
        //마지막으로 속도에 대입하기 때문에
        //대각선 이동에도 문제없이 대응할 수 있다.;


        if (Input.GetKey(KeyCode.W) == true)
        {
            myVelocity += Vector3.forward;
            //리지드바디에 힘을가하면(AddFoce)
            //가해진 힘에 의해서 속도가 증가한다.
            //힘을 가한 결과로써 속도가 증가하기 때문에
            //속도값을 우리가 임의로 정확하게 지정할 수 없다..

            //반면에 리지드 바디의 Velocity는 결과값인 속도를
            //나타내는 변수이기 때문에
            //이 속도값을 변경하면 중간과정 없이
            //즉시 이동이 가능해진다(가속,감속이 업삳.)
            //또한, 속도를 정확하게 조절할 수 있다.
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            myVelocity += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            myVelocity += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D) == true)
        {
            myVelocity += Vector3.right;
        }

        playerRigidbody.velocity = myVelocity * speed;
        //최종적으로 완성된 속도값을 리지드바디에 대입한다.
    }

    //좌표를 직접 변경해서 움직이는 방법
    void changePosition()
    {
        if (Input.GetKey(KeyCode.W) == true) 
        {
            this.transform.position += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S) == true) 
        {
            this.transform.position += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A) == true) 
        {
            this.transform.position += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D) == true) 
        {
            this.transform.position += Vector3.right;
        }

        //좌표를 직접 변경할때는
        //현재 좌표에서 누른 방향으로 이동해야 하기 때문에
        //대입이 아닌 좌표의 더하기가 되어야 한다.

        //좌표를 직접 변경하여 이동하는 방식의 경우
        //좌표값을 끊어서 변경하기 때문에
        //중간 과정이 없어 다소 움직임이 끊겨보일 수 있다.
        //(한번에 움직이는 거리를 짧게 만들면 어느정도 개선 가능)

        //좌표를 강제로 변경하기 때문에
        //설령 벽에 막혀있다 할지라도 벽을 뚫고 좌표를
        //변경하게 된다.
    }

    //좌표를 변경해서 움직이는 방법2
    void positionTranslate()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            this.transform.Translate(Vector3.forward); 
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            this.transform.Translate(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            this.transform.Translate(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D) == true)
        {
            this.transform.Translate(Vector3.right);

        }
        //좌표변경과 동일하게 좌표값을 바꾸는함수
        //다만 수식이 필요없이 현재 자신의 위치를 기준으로
        //좌표를 변경할 수 잇다.
    }

    //지정한 좌표로 이동시키는 방법
    void goToPosition() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(8, 1, 8), 0.1f);
        //Vector3.MoveTowards
        //목적지 좌표로 이동시키는 함수
        //매개변수로 시작지점,도착지점,시간당 움직일 거리
        //를 입력받는다.

        //캐릭터를 이동시키되, 방향이 기준이 아니라
        //목적지 좌표로 이동하는게 목표일 경우 사용하는 함수
    }

    //키보드 입력에 다중대응하는 방법
    void moveAxis()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal")*speed,
                                        0,
                                        Input.GetAxis("Vertical")*speed);

        //개발자 입장에서 특정 입력이 어떤 동작인지
        //키보드 값이나 입력된 값만 봐서는 이해하기 힘들기 때문에
        //특정 입력에 대해 별도로 이름을 붙여서
        //알아보기 편하도록 만들어 주는 것이 GetAxis 함수이다.
        //에디터에서 Edit-project setting-input manager를 통해
        //각 이름이 어떠한 입력을 받는지 확인할 수 있다.

        playerRigidbody.velocity = dir;
    }

    
    //총알에 부딪혔을때 플레이어를 소멸(비활성화)시키는 함수
    void die()
    {

        gameObject.SetActive(false);
        //대문자 GameObject는 유니티 클래스인 게임오브젝트를 나타내며
        //소문자 gameObject는 현재 이 스크립트 컴포넌트를 가지고 있는 대상
        //(==player)를 의마하게 된다.
    }


    private void OnTriggerEnter(Collider other)
    {//bullet2번과 충돌시(isTrigger)
        if (other.gameObject.tag == "Bullet")
            die();
    }

    private void OnCollisionEnter(Collision collision)
    {//bullet1번과 충돌시
        if (collision.gameObject.tag == "Bullet")
        {
            die();
        }
    }
}
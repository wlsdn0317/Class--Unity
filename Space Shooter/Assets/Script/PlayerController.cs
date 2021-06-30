using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject Laser; //플레이어가 발사할 미사일;

    float delay=1;//총알이 연속으로 발사되는 주기
    float pressTime;//발사키를 누르고 있는 시간

    public Camera mainCam;

    public int hp = 3;//플레이어 체력
    public GameObject damageimg;//피해 입었을때 보이는 이미지

    public int Life = 3;

    public Image lifeImg;//life 이미지
    
    void Start()
    {
        Laser = Resources.Load<GameObject>("Prefabs/myLaser");
        //스크립트를 통해서 레이저 프리팹을 폴더에서 가져왔다.
        
        pressTime = delay;
        //레이저의 첫발은 입력과 동시에 발사되도록
        //초기값을 딜레이와 같은값을 준다.
    }
        
    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal");//수평방향
        moveDir.y = Input.GetAxis("Vertical");//수직방향
        this.transform.position += moveDir * Time.deltaTime*3;

        if (Input.GetKey(KeyCode.Space))
        {
            pressTime += Time.deltaTime;
            if (pressTime >= delay)
            {
                pressTime -= delay;
                //스페이스바를 누르면 delay초마다 총알이 발사됨.
                Instantiate(Laser, this.transform.position, Quaternion.identity);
                //플레이어 위치에서 레이저를 발사
                
            }
        }   

        if (Input.GetKeyUp(KeyCode.Space))
        {
            pressTime = delay;
            //키보드를 때는 순간 딜레이를 초기화해서
            //즉시 총알이 발사되는 상태로 바꿔준다.
            //이렇게하면 키보드를 누르는 동안에는
            //딜레이에 맞게 총알이 주기적으로 발사되고
            //키보드를 연타하게 되면 딜레이와 관계없이
            //총알이 연속해서 발사되게 된다. 
        }



        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            //화면상의 마우스 좌표를 가져오고
            mousePos = mainCam.ScreenToWorldPoint(mousePos);
            //화면상의 좌표를 카메라를 기준으로 한 월드 좌표로 전환.
            RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, 100);
            //레이케스트 : 특정 좌표에서 레이저(Ray)를 쏘아서
            //해당 레이저에 부딪힌 대상의 정보를 가져올 수 있도록 만드는 
            //부딪힌 대상이 hit에 반환되며, 대상이 없다면 hit는 null이 된다.


            if (hit)
            {
                GameObject obj = Instantiate(Laser, this.transform.position, Quaternion.identity);
                Vector3 v = hit.point;
                //충돌위치는 2d좌표이기 때문에
                //3d좌표인 Vector3로 변경해서 사용한다.


                Vector3 dir = v - this.transform.position;
                dir.z = 0;
                dir = dir.normalized;
                //방향값을 구하고, 단위벡터로 만든 뒤
                obj.transform.up = dir;
                //레이저가 가진 이동방향값을  해당 값으로 변경한다.


            }
        }

    }

    public void damaged()
    {
        hp--;
        if(damageimg.activeSelf == false)
        {
            //피해 이미지가 꺼져있으면
            damageimg.SetActive(true);
            //이미지를 켜줌
        }
        if (hp < 0)
        {
            die();
        }

        damageimg.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>("Damage/playerShip1_damage" + (3 - hp));

    }

    public void die(){
        Life--;
        if (Life >= 0)
        {
            hp = 3;
        }
        else if (Life < 0)
        {
            Destroy(this.gameObject);
            return;//자기자신을 삭제했다면
            //코드가 종료되도록 리턴해준다.
        }
        lifeImg.sprite = Resources.Load<Sprite>("UI/numeral" + Life);
    }

}

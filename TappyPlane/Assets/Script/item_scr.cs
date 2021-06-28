using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_scr : MonoBehaviour
{
    public int bonus =0;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * 5;
        //아이템도 장애물처럼 오른쪽에서 왼쪽으로 움직이도록 만들어 준다.

        if(this.transform.position.x<= -8)
        {
            //아이템이 화면 밖으로 나가면
            Destroy(this.gameObject);
            //아이템 삭제
            //Destroy사용시 매개변수로this를 넣으면
            //해당 오브젝트가 아니라 스크립트(컴포넌트)만 삭제가 되고
            //게임오브젝트는 계속해서 남게 된다.
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Plane")
        {
            GameObject gmObj = GameObject.Find("GameManager");
            //게임에서 존재하는 매니저 오브젝트를 탐색

            if (gmObj != null)
            {
                //게임매니저가 존재할때
                GameManager gm = gmObj.GetComponent<GameManager>();
                //게임매니저에게서 매니저 스크립트를 가져와서
                gm.score += bonus;
                //매니저 스크립트의 점수를 증가
            }



            //플레이어가 많아지면 name보다 tag를 쓰는게 좋다.
            Destroy(this.gameObject);
        }
    }
}

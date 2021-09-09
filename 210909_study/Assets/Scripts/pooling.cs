using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pooling : MonoBehaviour
{
    //오브젝트 풀링(Object Pooling)
    //프로그램에서는 기본적으로 오브젝트의 생성과 삭제를
    //하는데 생각보다 많은 처리가 필요하다.
    //때문에 만약 틀정 오브젝트가 생성과 삭제를
    //빠른 주기로 반복한다면 cpu에 가해지는 부하가 많아져서
    //전체적인 게임 퍼포먼스가 떨어지게 된다.
    //그래서 오브젝트를 매번 삭제하고 새로 만드는 것이 아니라
    //삭제 대신 대상을 비활성화 시키고
    //생성 대신, 비활성화됐던 대상을 다시 가져와서
    //활성화시켜 재황용할 수 있도록 만드는 방식읋
    //오브젝트 풀링이라고 부른다.
    static private pooling inst = null;
    public GameObject bulletPref;   //풀링에서 생성하고
                                    //관리할 대상 오브젝트의 프리팹

    Queue<GameObject> bullets = new Queue<GameObject>();
                                    //풀링이 보관하고 있는 오브젝트들
                                    //사용되지 않았거나
                                    //사용이 끝난 오브젝트

    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    static public pooling Inst
    {
        get
        {
            if(inst == null)
            {
                return null;
            }
            else
            {
                return inst;
            }
        }
    }

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject b= Instantiate(bulletPref);
            bullets.Enqueue(b);
            //생성한 총알을 큐에 넣고
            b.SetActive(false);
            //아직 사용하지 않은 총알이기 때문에
            //active를 꺼준다.
            b.transform.SetParent(this.transform);
            //총알의 부모가 여기저기 파편화 되어 있으면 안되기 때문에
            //사용대기중인 총알의 부모는 풀링 객체가 된다.
        }   
    }
    public GameObject getBullet()
    {
        if (bullets.Count == 0)
        {
            //사용대기중인 총일이 없으면
            //==이미 모든 총알이 사용중이면
            //새로운 총알을 만들어서 전달한다.
            GameObject tmp = Instantiate(bulletPref);
            tmp.transform.SetParent(null);
            return tmp;
        }
        else
        {
            GameObject tmp = bullets.Dequeue();
            //사용대기 중인 총알을 꺼내서
            tmp.SetActive(true);
            //활성화시키고
            tmp.transform.SetParent(null); 
            return tmp;
            //총알을 함수를 부른곳으로 반환시켜 사용토록 한다.
        }
    }

    public void returnBullet(GameObject tmp)
    {
        //사용이 끝난 객체를 반환받는 함수
        tmp.SetActive(false);
        //객체를 비활성화 시키고
        bullets.Enqueue(tmp);
        //큐에 넣어주고
        tmp.transform.SetParent(this.transform);
        //부모를 다시 풀링으로 바꿔준다
    }


    void Update()
    {
        
    }
}

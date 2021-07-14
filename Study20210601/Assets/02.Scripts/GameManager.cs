using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("적 생성 정보")]
    public Transform[] points;
    public GameObject enemy;

    public float createTime = 2f; //생성 주기
    public int maxEnemy = 10; //최대 생성 갯수
    public bool isGameOver = false;

    //static 변수로 전역적으로 접근할 수 있도록 설정
    //다른 스크립트에서 instance라는 변수를 이용해서 쉽게 접근가능
    public static GameManager instance = null;
    //다만 중복되어 생성되지 않도록(게임 내에서 유일해야함)
    //아래 코드를 통하여 관리 해주어야함

    [Header("오브젝트 풀 정보")]
    public GameObject bulletPrefab;
    public int maxPool = 10;
    //List는 일반적인 배열과 달리 안의 내용물에 맞춰 길이가 변함
    public List<GameObject> bulletPool = new List<GameObject>();

    private void Awake()
    {
        //싱글턴이 존재 하지 않을 경우
        if(instance == null)
        {
            instance = this;//싱글턴 패턴으로 만들어줌
        }
        //instance에 할당된 클래스의 인스턴스가 다를경우
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        //씬이 변경되더라도 삭제하지 않고 유지함
        DontDestroyOnLoad(this.gameObject);
        //오브젝트 풀 생성
        CreatePooling();
    }

    void Start()
    {
        points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            //스폰 코루틴 함수 호출
            StartCoroutine(CreateEnemy());
        }
    }

    IEnumerator CreateEnemy()
    {
        //게임 종료 전까지 계속 수행됨
        while (!isGameOver)
        {
            //태그를 활용하여 Enemy의 수량 파악
            int enemyCount = (int)GameObject.FindGameObjectsWithTag("ENEMY").Length;
            
            //Enemy의 최대생성 개수보다 작을 때만 리스폰
            if(enemyCount < maxEnemy)
            {
                //적 생성 주기 시간만큼 대기
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);
                Instantiate(enemy, points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }
    }

    //오브젝트 풀 중에서 사용 가능한 총알 가져오기
    public GameObject GetBullet()
    {
        for(int i = 0; i < bulletPool.Count; i++)
        {
            //총알이 비활성화 되어있다면 = 사용전이라면
            if(bulletPool[i].activeSelf == false)
            {
                return bulletPool[i];
            }
        }
        return null;
    }
    
    //오브젝트 풀 생성 함수
    public void CreatePooling()
    {
        //하이어라키에서 Create Empty하는것과 동일
        //빈 오브젝트를 생성한 후 이름을 ObjectPools로 지정
        //생성된 총알(10발)을 자식으로 관리하기 위하여 코드로 생성
        GameObject objectPools = new GameObject("ObjectPools");

        //오브젝트 풀 채우기
        for(int i = 0; i < maxPool; i++)
        {
            //동적 생성과 동시에 위에서 생성한  ObjectPools의 자식으로 설정
            var obj = Instantiate<GameObject>(bulletPrefab, objectPools.transform);
            //Bullet_00, Bullet_01.....BUlet_09....10
            obj.name = "Bullet_" + i.ToString("00");
            obj.SetActive(false);//발사 전이므로 비활성화
            //리스트에 생성한 총알 주기
            bulletPool.Add(obj);
        }
    }

    void Update()
    {
        
    }
}

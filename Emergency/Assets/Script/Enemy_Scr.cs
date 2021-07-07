using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Scr : MonoBehaviour
{
    GameObject targetPos;
    Vector3 dir;//적의 이동 방향
    public int moveSpeed;
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private int scorePoint = 100; //적 처치시 획득 점수
    [SerializeField]
    private GameObject explsionPrefab;

    [SerializeField]
    private GameObject[] itemPrefabs;   //적이 죽었을 때 획득 가능한 아이템

    private Player_Scr playerController; //플레이어의 점수(Score) 정보에 접근하기 위해

    


    private void Awake()
    {
        //Tip. 현재 코드에서는 한번만 호출하기 때문에 OnDie()에서 바로 호출해도 되지만
        //오브젝트 풀링을 이용해 오브젝트를 재사용할 경우에는 최초 1번만 Find를 이용해
        //PlayerController의 정보를 저장해두고 사용하는 것이 연산에 효율 적이다.
        playerController = GameObject.Find("Player").GetComponent<Player_Scr>();
    }

    void Start()
    {
        targetPos = GameObject.Find("Player");
        dir = targetPos.transform.position - this.transform.position;
        //목표물로 가는 방향을 구해서 변수로 저장
        //스타트에 저장해서 똑같은 방향으로 진행하게끔
        //방향: 목표물 위치 - 현재위치
        dir.z = 0;
        dir = dir.normalized;

        
        
    }                         

    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * moveSpeed;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.transform.tag == "Player")
        {
            collision.GetComponent<Player_Hp>().TakeDamage(damage);
            OnDie();
        }
    }

    public void OnDie()
    {
        //플레이어의 점수를 scorePoint만큼 증가시킨다
        playerController.Score += scorePoint;

        Instantiate(explsionPrefab, transform.position, Quaternion.identity);

        //일정 확률로 아이템 생성
        SpawnItem();

        //적 오브젝트 제거
        Destroy(this.gameObject);
    }

    private void SpawnItem()
    {
        int spawnItem = Random.Range(0, 100);
        if(spawnItem < 10)
        {
            GameObject item01 =Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
            Destroy(item01,4.0f);
        }
        if (spawnItem >=15 && spawnItem < 30)
        {
            GameObject item02 =Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
            Destroy(item02, 4.0f);
        }
    }


}

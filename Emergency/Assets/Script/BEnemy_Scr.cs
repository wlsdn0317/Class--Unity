using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemy_Scr : MonoBehaviour
{
    GameObject target;
    Vector3 dir;
    public int moveSpeed;
    [SerializeField]
    private int damage = 1; //적 공격력

    [SerializeField]
    private int scorePoint = 100; //적 처치시 획득 점수

    [SerializeField]
    private GameObject explsionPrefab;
    private Player_Scr playerController; //플레이어의 점수(Score) 정보에 접근하기 위해

    private void Awake()
    {
        //Tip. 현재 코드에서는 한번만 호출하기 때문에 OnDie()에서 바로 호출해도 되지만
        //오브젝트 풀링을 이용해 오브젝트를 재사용할 경우에는 최초 1번만 Find를 이용해
        //PlayerController의 정보를 저장해두고 사용하는 것이 연산에 효율 적이다.
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Scr>();
    }


    void Start()
    {
        target = GameObject.Find("Player");
        dir = target.transform.position - this.transform.position;
        dir.z = 0;
        dir = dir.normalized;
    }


    void Update()
    {
        this.transform.forward = dir;
        this.transform.position += this.transform.forward * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //적 공격력만큼 플레이어 체력 감소
            collision.GetComponent<Player_Hp>().TakeDamage(damage);
            //적 사망함수 호출
            OnDie();
        }
    }

    public void OnDie()
    {
        //플레이어의 점수를 scorePoint만큼 증가시킨다
        playerController.Score += scorePoint;

        Instantiate(explsionPrefab, transform.position, Quaternion.identity);

        //적 오브젝트 제거
        Destroy(this.gameObject);
    }


}

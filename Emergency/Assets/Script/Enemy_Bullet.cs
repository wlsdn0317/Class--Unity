using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    public int moveSpeed = 1;
    GameObject target;
    Vector3 dir;

    void Start()
    {
        target = GameObject.Find("Player");
        dir = target.transform.position-this.transform.position;
        dir.z = 0;
        dir = dir.normalized;
    }

    void Update()
    {
        transform.forward = dir;
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //부딪힌 오브젝트 삭제(적)
            collision.GetComponent<Player_Hp>().TakeDamage(damage);
            //내오브젝트삭제
            Destroy(gameObject);
        }
    }

    public void OnDie()
    {
        
        //적 오브젝트 제거
        Destroy(this.gameObject);
    }
}

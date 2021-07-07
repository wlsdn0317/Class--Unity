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
            //�ε��� ������Ʈ ����(��)
            collision.GetComponent<Player_Hp>().TakeDamage(damage);
            //��������Ʈ����
            Destroy(gameObject);
        }
    }

    public void OnDie()
    {
        
        //�� ������Ʈ ����
        Destroy(this.gameObject);
    }
}

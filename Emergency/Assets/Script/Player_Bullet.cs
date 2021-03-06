using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //발사체에 부딪힌 오브젝트의 태그가 "Enemy"이면
        if (collision.CompareTag("Enemy"))
        {
            //부딪힌 오브젝트 삭제(적)
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
            //내오브젝트삭제
            Destroy(gameObject);
        }
        else if (collision.CompareTag("BEnemy"))
        {
            collision.GetComponent<BEnemyHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

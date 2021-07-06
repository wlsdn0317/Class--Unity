using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�߻�ü�� �ε��� ������Ʈ�� �±װ� "Enemy"�̸�
        if (collision.CompareTag("Enemy"))
        {
            //�ε��� ������Ʈ ����(��)
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
            //��������Ʈ����
            Destroy(gameObject);
        }
        else if (collision.CompareTag("BEnemy"))
        {
            collision.GetComponent<BEnemyHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

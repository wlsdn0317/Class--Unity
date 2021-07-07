using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { PowerUp =0,Boom,HP}


public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;
    private Movement2D movement2D;
    void Awake()
    {
        movement2D = GetComponent<Movement2D>();

        float x = Random.Range(-0.1f, 1.0f);

        movement2D.MoveTo(new Vector3(x, -1, 0));
    }

    void Update()
    {

    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //������ ȹ�� �� ȿ��
            Use(collision.gameObject);
            //������ ������Ʈ ����
            Destroy(gameObject);
        }  
        else if (collision.CompareTag("Invincivility"))
        {
            //������ ȹ�� �� ȿ��
            Use(collision.gameObject);
            //������ ������Ʈ ����
            Destroy(gameObject);
        }
    }

    public void Use(GameObject player)
    {
        switch (itemType)
        {
            case ItemType.PowerUp:
                player.GetComponent<Weapon>().AttackLevel++;
                break;
            case ItemType.Boom:
                player.GetComponent<Weapon>().BoomCount++;
                break;
            case ItemType.HP:
                player.GetComponent<Player_Hp>().CurrentHP += 2;
                break;
        }
    }
}

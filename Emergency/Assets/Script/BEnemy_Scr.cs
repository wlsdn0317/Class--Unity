using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemy_Scr : MonoBehaviour
{
    GameObject target;
    Vector3 dir;
    public int moveSpeed;
    [SerializeField]
    private int damage = 1; //�� ���ݷ�

    [SerializeField]
    private int scorePoint = 100; //�� óġ�� ȹ�� ����

    [SerializeField]
    private GameObject explsionPrefab;

    [SerializeField]
    private GameObject[] itemPrefabs;   //���� �׾��� �� ȹ�� ������ ������

    private Player_Scr playerController; //�÷��̾��� ����(Score) ������ �����ϱ� ����

    private void Awake()
    {
        //Tip. ���� �ڵ忡���� �ѹ��� ȣ���ϱ� ������ OnDie()���� �ٷ� ȣ���ص� ������
        //������Ʈ Ǯ���� �̿��� ������Ʈ�� ������ ��쿡�� ���� 1���� Find�� �̿���
        //PlayerController�� ������ �����صΰ� ����ϴ� ���� ���꿡 ȿ�� ���̴�.
        playerController = GameObject.Find("Player").GetComponent<Player_Scr>();
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
            //�� ���ݷ¸�ŭ �÷��̾� ü�� ����
            collision.GetComponent<Player_Hp>().TakeDamage(damage);
            //�� ����Լ� ȣ��
            OnDie();
        }
    }

    public void OnDie()
    {
        //�÷��̾��� ������ scorePoint��ŭ ������Ų��
        playerController.Score += scorePoint;

        Instantiate(explsionPrefab, transform.position, Quaternion.identity);
        SpawnItem();
        //�� ������Ʈ ����
        Destroy(this.gameObject);
    }
    private void SpawnItem()
    {
        int spawnItem = Random.Range(0, 100);
        if (spawnItem < 10)
        {
            GameObject item01 = Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
            Destroy(item01, 4.0f);
        }
        else if (spawnItem < 15)
        {
            GameObject item02 =Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
            Destroy(item02, 4.0f);
        }
        else if (spawnItem <20)
        {
            GameObject item03 = Instantiate(itemPrefabs[2], transform.position, Quaternion.identity);
            Destroy(item03, 4.0f);
        }
    }

}

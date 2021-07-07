using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Scr : MonoBehaviour
{
    GameObject targetPos;
    Vector3 dir;//���� �̵� ����
    public int moveSpeed;
    [SerializeField]
    private int damage = 1;

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
        targetPos = GameObject.Find("Player");
        dir = targetPos.transform.position - this.transform.position;
        //��ǥ���� ���� ������ ���ؼ� ������ ����
        //��ŸƮ�� �����ؼ� �Ȱ��� �������� �����ϰԲ�
        //����: ��ǥ�� ��ġ - ������ġ
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
        //�÷��̾��� ������ scorePoint��ŭ ������Ų��
        playerController.Score += scorePoint;

        Instantiate(explsionPrefab, transform.position, Quaternion.identity);

        //���� Ȯ���� ������ ����
        SpawnItem();

        //�� ������Ʈ ����
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

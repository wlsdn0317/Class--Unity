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
    private Player_Scr playerController; //�÷��̾��� ����(Score) ������ �����ϱ� ����

    private void Awake()
    {
        //Tip. ���� �ڵ忡���� �ѹ��� ȣ���ϱ� ������ OnDie()���� �ٷ� ȣ���ص� ������
        //������Ʈ Ǯ���� �̿��� ������Ʈ�� ������ ��쿡�� ���� 1���� Find�� �̿���
        //PlayerController�� ������ �����صΰ� ����ϴ� ���� ���꿡 ȿ�� ���̴�.
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

        //�� ������Ʈ ����
        Destroy(this.gameObject);
    }


}

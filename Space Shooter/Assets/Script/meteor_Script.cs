using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor_Script : MonoBehaviour
{

    GameObject targetPos;
    //�� ĳ���Ͱ� ��ǥ�� �ؾ��ϴ� ����� ��ġ == �÷��̾�

    Vector3 dir;//���� �̵� ����


    void Start()
    {
        targetPos = GameObject.Find("Player");
        //��ǥ���� ã�Ƽ� ������ ����
        dir = targetPos.transform.position - this.transform.position;
        //��ǥ���� ���� ������ ���ؼ� ������ ����
        //���� : ��ǥ����ġ - ������ġ
        dir.z = 0;
        dir = dir.normalized;

    }




    void Update()
    {
        this.transform.forward = dir;
        //�ش� ������Ʈ�� ���� ������ ����
        this.transform.position += this.transform.forward * Time.deltaTime;
        //�̵������� �ش� ������Ʈ�� �ٶ󺸸� ����(forward)���� �̵���Ŵ
        if (this.transform.position.y <= -6)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().damaged();
            Destroy(this.gameObject);
        }
    }

}

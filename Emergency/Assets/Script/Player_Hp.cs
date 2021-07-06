using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hp : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10; //�ִ� ü��
    private float currentHP; //���� ü��
    private SpriteRenderer spriteRenderer;
    private Player_Scr playerController;

    public float MaxHp => maxHP;    //maxHP ������ ������ �� �ִ� ������Ƽ (Get�� ����)
    public float CurrentHP => currentHP; //currentHP ������ ������ �� �ִ� ������Ƽ(Get�� ����)

    bool hittable;

    private void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        hittable = true;
        playerController = GetComponent<Player_Scr>();

    }

    public void TakeDamage(float damage)
    {
        if (hittable == true)
        {

            currentHP -= damage;

            hittable = false;

            
            StartCoroutine("HitColorAnimation");

            if (currentHP <= 0)
            {
                
                playerController.OnDie();
            }





        }
    }

    private IEnumerator HitColorAnimation()
    {
        for (int i = 0; i < 30; i++)
        {
            if (i % 2 == 0)
            {
                //�÷��̾��� ������ ����������
                spriteRenderer.color = Color.red;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
            //0.1�� ���� ���
            yield return new WaitForSeconds(0.1f);
            //�÷��̾��� ������ ���� ������ �Ͼ������
            //(���������� �Ͼ���� �ƴ� ��� ���� ���� ���� ����)
        }
        hittable = true;
    }


}

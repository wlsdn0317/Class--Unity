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
    public float CurrentHP  //currentHP ������ ������ �� �ִ� ������Ƽ(Get�� ����)
    {
        set => currentHP = Mathf.Clamp(value, 0, maxHP);
        get => currentHP;
    }
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
            gameObject.GetComponent<Weapon>().AttackLevel--;

            hittable = false;

            gameObject.tag = "Invincivility";
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

        gameObject.tag = "Player";
        hittable = true;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hp : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10; //최대 체력
    private float currentHP; //현재 체력
    private SpriteRenderer spriteRenderer;
    private Player_Scr playerController;

    public float MaxHp => maxHP;    //maxHP 변수에 접근할 수 있는 프로퍼티 (Get만 가능)
    public float CurrentHP  //currentHP 변수에 접근할 수 있는 프로퍼티(Get만 가능)
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
                //플레이어의 색상을 빨간색으로
                spriteRenderer.color = Color.red;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
            //0.1초 동안 대기
            yield return new WaitForSeconds(0.1f);
            //플레이어의 색상을 원래 색상인 하얀색으로
            //(원래색상이 하얀색이 아닐 경우 원래 색상 변수 선언)
        }

        gameObject.tag = "Player";
        hittable = true;
    }


}

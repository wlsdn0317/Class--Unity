using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemyHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 4;
    private float currentHP;
    private BEnemy_Scr benemy;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHP = maxHP;
        benemy = GetComponent<BEnemy_Scr>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        if (currentHP <= 0)
        {
            benemy.OnDie();

        }
    }

    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }

    void Update()
    {

    }
}

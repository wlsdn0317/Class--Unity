using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject  bulletPrefab; // 공격할 때 생성되는 발사체 프리팹
    [SerializeField]
    private float       attackRate = 1.0f;
    private int attackLevel = 1;
    private int maxAttackLevel = 3;

    [SerializeField]
    private GameObject boomPrefab;
    private int boomCount = 3;

    public int AttackLevel
    {
        set => attackLevel = Mathf.Clamp(value, 1, maxAttackLevel);
        get => attackLevel;
    }
    public int BoomCount
    {
        set => boomCount = Mathf.Max(0, value);
        get => boomCount;
    }

   

    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }
    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    public void StartBoom()
    {
        if (boomCount > 0)
        {
            boomCount--;
            Instantiate(boomPrefab, transform.position, Quaternion.identity);
            
        }
    }

    IEnumerator TryAttack()
    {
        while (true)
        {

            //발사체 오브젝트 생성
            //Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //공격 레벨에 따라 발사체 생성
            AttackByLevel();


            yield return new WaitForSeconds(attackRate);
        }
    }

    private void AttackByLevel()
    {
        GameObject cloneProjectile = null;

        switch (attackLevel)
        {
            case 1:         // Level 01 : 기존과 같이 발사체 1개 생성
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                break;
            case 2:         // Level 02 : 간격을 두고 전방으로 발사체 2개 생성
                Instantiate(bulletPrefab, transform.position+Vector3.left*0.2f, Quaternion.identity);
                Instantiate(bulletPrefab, transform.position+Vector3.right*0.2f, Quaternion.identity);
                break;
            case 3:         // Level 03 : 전방으로 발사체 1개, 좌우 대각선 방향으로 발사체 각 1개
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                //왼쪽 대각선 방향으로 발사 되는 발사체
                cloneProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));
                //오른쪽 대각선 방향으로 발사되는 발사체
                cloneProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                break;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject  bulletPrefab; // ������ �� �����Ǵ� �߻�ü ������
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

            //�߻�ü ������Ʈ ����
            //Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //���� ������ ���� �߻�ü ����
            AttackByLevel();


            yield return new WaitForSeconds(attackRate);
        }
    }

    private void AttackByLevel()
    {
        GameObject cloneProjectile = null;

        switch (attackLevel)
        {
            case 1:         // Level 01 : ������ ���� �߻�ü 1�� ����
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                break;
            case 2:         // Level 02 : ������ �ΰ� �������� �߻�ü 2�� ����
                Instantiate(bulletPrefab, transform.position+Vector3.left*0.2f, Quaternion.identity);
                Instantiate(bulletPrefab, transform.position+Vector3.right*0.2f, Quaternion.identity);
                break;
            case 3:         // Level 03 : �������� �߻�ü 1��, �¿� �밢�� �������� �߻�ü �� 1��
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                //���� �밢�� �������� �߻� �Ǵ� �߻�ü
                cloneProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));
                //������ �밢�� �������� �߻�Ǵ� �߻�ü
                cloneProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                break;
        }
    }


}

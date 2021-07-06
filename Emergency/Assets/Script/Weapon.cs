using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject  bulletPrefab; // ������ �� �����Ǵ� �߻�ü ������
    [SerializeField]
    private float       attackRate = 1.0f;

    [SerializeField]
    private GameObject boomPrefab;
    private int boomCount = 300;

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

           
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(attackRate);
        }
    }
}

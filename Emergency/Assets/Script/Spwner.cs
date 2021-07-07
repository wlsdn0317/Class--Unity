using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwner : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab; //ÃÑ¾Ë »ý¼º
    float B_Timer;
    float B_Delay;
    GameObject targetPos;

    void Start()
    {
        B_Timer = 0;
        targetPos = GameObject.Find("Player");
    }

    void Update()
    {
        if (targetPos != null)
        {
            B_Timer += Time.deltaTime;
            B_Delay = Random.Range(1.0f,2.0f );
            if (B_Timer >= B_Delay)
            {
                B_Timer -= B_Delay;
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}

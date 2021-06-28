using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMaker : MonoBehaviour
{
    public GameObject down_obs;
    //�������� ��ֹ� ������

    float obs_delay; //���� �ֱ�
    float obs_timer; //���� �ð�
    void Start()
    {
        obs_delay = 2;
        obs_timer = 0;
    }

    
    void Update()
    {
        obs_timer += Time.deltaTime;
        if (obs_timer >= obs_delay)
        {
            obs_timer -= obs_delay;

            float height = Random.Range(-2.0f, -1.5f);
            //�����Ǵ� ��ֹ��� y�� ��ġ�� �������� �����ȴ�.

            Instantiate(down_obs,new Vector3(8,height,8),Quaternion.identity);
            //Quaternion.identity : Vector2.zeroó��
            //                       0,0,0 ������ �ǹ��Ѵ�.
        }
    }
}

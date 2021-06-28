using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMaker : MonoBehaviour
{
    public GameObject down_obs;
    //생성해줄 장애물 프리팹

    float obs_delay; //생성 주기
    float obs_timer; //지난 시간
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
            //생성되는 장애물의 y축 위치는 랜덤으로 결정된다.

            Instantiate(down_obs,new Vector3(8,height,8),Quaternion.identity);
            //Quaternion.identity : Vector2.zero처럼
            //                       0,0,0 각도를 의미한다.
        }
    }
}

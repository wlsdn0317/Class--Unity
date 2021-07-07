using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float eDelay;
    float eTimer;
    public GameObject[] enemyPrefabs;
    GameObject targetPos;
    public GameObject[] spawner;
    int scoreTime;

    void Start()
    {

        eTimer = 0;
        targetPos = GameObject.Find("Player");
        scoreTime = 10000;
    }

    void Update()
    {

        if (targetPos != null)
        {
            int score = targetPos.GetComponent<Player_Scr>().Score; 
            eDelay = Random.Range(0.3f, 0.7f);
            eTimer += Time.deltaTime;
            if (eTimer >= eDelay)
            {
                eTimer -= eDelay;
                float Random_Line = Random.Range(-2.7f, 2.7f);
                if (score >= 0 && score < scoreTime/2)
                {
                    int r = Random.Range(0, 3);
                    Instantiate(enemyPrefabs[r], new Vector3(Random_Line, 6f, 0), Quaternion.identity);
                }
                else if(score >= scoreTime / 2)
                {
                    int r = Random.Range(0,5);
                    
                    Instantiate(enemyPrefabs[r], new Vector3(Random_Line, 6f, 0), Quaternion.identity);
                }
            }
            if (score >= scoreTime)
            {
                spawner[0].SetActive(true);
                if (score >= scoreTime * 2)
                {
                    spawner[1].SetActive(true);
                }
            }

        }

    }
}






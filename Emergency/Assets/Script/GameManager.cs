using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float eDelay;
    float eTimer;
    public GameObject[] enemyPrefabs;
    GameObject targetPos;

    
    
    void Start()
    {
        
        eTimer = 0;
        targetPos = GameObject.Find("Player");
            
    }

    void Update()
    {
        
        if (targetPos != null)
        {
            eDelay = Random.Range(0.3f, 0.7f);
            eTimer += Time.deltaTime;
            if (eTimer >= eDelay)
            {
                eTimer -= eDelay;
                int r = Random.Range(0, 5);
                float Random_Line = Random.Range(-2.7f,2.7f);
                
                Instantiate(enemyPrefabs[r], new Vector3(Random_Line,6f,0), Quaternion.identity);
                
            }
        }
    }

    

    
}

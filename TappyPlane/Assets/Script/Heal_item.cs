using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_item : MonoBehaviour
{
    float currentPosition_x;
    float currentPosition_y;
    float movespeed = 3.0f;
    void Start()
    {
        currentPosition_y = this.transform.position.y;
        currentPosition_x = this.transform.position.x;
    }

   
    void Update()
    {
      currentPosition_x -=  Time.deltaTime * 1.5f;

        currentPosition_y += Time.deltaTime * movespeed;
        if (currentPosition_y >= 2.2f)
        {
            movespeed *= -1;  //높이가 1.1이상이되면 밑으로 힘을가한다
        }
        else if(currentPosition_y <= -2.2f)
        {
            movespeed *= -1; //높이가 -1.1이하가 되면 위로 힘을 가한다.
        }
        this.transform.position = new Vector3(currentPosition_x, currentPosition_y, 0);
        if (currentPosition_x <= -8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name == "Plane"){
            PlayerScr sc = collision.GetComponent<PlayerScr>();
            
            if (sc.hp < 3)
            {
                sc.hp++;
                sc.hpImage[sc.hp-1].SetActive(true);
            }

            Destroy(this.gameObject);
        }
    }
}

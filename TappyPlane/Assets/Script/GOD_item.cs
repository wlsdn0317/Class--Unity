using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOD_item : MonoBehaviour
{
    float currposition_x;
    float currposition_y;
    float G_speed;
        
    void Start()
    {
        G_speed = 3f;
        currposition_x = transform.position.x;
        currposition_y = transform.position.y;
    }

    
    void Update()
    {
        currposition_x -= Time.deltaTime * 4f;
        currposition_y += Time.deltaTime * G_speed;
        if(currposition_y >= 2.0f)
        {
            G_speed *= -1;
        }
        else if(currposition_y<= -2.0f)
        {
            G_speed *= -1;
        }
        this.transform.position = new Vector3(currposition_x, currposition_y, 0);
        if (currposition_x <= -8)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Plane")
        {

            Destroy(this.gameObject);
        }
    }


     
}

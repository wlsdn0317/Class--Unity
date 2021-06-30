using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_Script : MonoBehaviour
{
    public int bonus = 0;
    public int speed;
    void Start()
    {
        speed = 1;
    }

    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime*speed;
        if (this.transform.position.y <= -6)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject gmObj = GameObject.Find("gameManager");

            if(gmObj != null)
            {
                gameManager gm = gmObj.GetComponent<gameManager>();
                gm.score += bonus;
            }

            Destroy(this.gameObject);
        }
    }
}

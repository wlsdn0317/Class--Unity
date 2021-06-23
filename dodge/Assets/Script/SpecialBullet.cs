using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    float speed = 8f;
    Rigidbody specialRigidbody;
    GameObject Player = GameObject.Find("Player");
    PlayerController Pctrl;
    
    void Start()
    {
        specialRigidbody = this.GetComponent<Rigidbody>();
        Pctrl = Player.GetComponent<PlayerController>();
        specialRigidbody.velocity = this.transform.forward * 10;

        Destroy(this.gameObject, 10f);
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plyer")
        {
            Pctrl.hp += 1;
            Destroy(this.gameObject);
        }
       
    }
}

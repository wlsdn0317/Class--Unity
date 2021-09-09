using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }
    float delayTime = 0;
    void Update()
    {
        this.transform.position += this.transform.forward * Time.deltaTime * 3;

        delayTime += Time.deltaTime;
        if (delayTime > 3f)
        {
            delayTime = 0;
            die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        die();
    }


    void die()
    {
        pooling.Inst.returnBullet(this.gameObject);
    }
}

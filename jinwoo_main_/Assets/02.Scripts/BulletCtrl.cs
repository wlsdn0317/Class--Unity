using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{

    public float damage = 20f;  //ÃÑ¾Ë °ø°Ý·Â
    public float speed = 1000f; //ÃÑ¾Ë ¼Óµµ
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

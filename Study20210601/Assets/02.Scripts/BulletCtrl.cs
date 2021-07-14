using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float damage = 20f; //총알 공격력
    public float speed = 1000f; //총알 속도

    Transform tr;
    Rigidbody rb;
    TrailRenderer trail;
    
    void Awake()

    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();

        
        //GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    private void OnEnable()//활성화 될 때
    {
        rb.AddForce(transform.forward * speed);
    }
    private void OnDisable()
    {
        //총알에 있는 기능들 전부 비활성화 및 초기화
        trail.Clear();
        tr.position = Vector3.zero;
        tr.rotation = Quaternion.identity;
        rb.Sleep();
    }

    void Update()
    {
        
    }
    
}

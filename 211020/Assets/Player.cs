using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 10;
    
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        this.transform.Translate(h, 0, v);
    }


    void Update()
    {
        
    }
}

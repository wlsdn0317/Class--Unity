using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fillimage : MonoBehaviour
{
    float time = 0;
    float speed = 0.2f;
    public Image img;
    public Image img2;

    bool isDone = false;
    void Start()
    {
        img.fillAmount = time;
    }

    void Update()
    {
        if (!isDone)
        {
            Add();
        }
        else
        {
            Minus();
        }
    }

    void Add()
    {
        img.fillClockwise = true;
        if (img.fillAmount == 1)
        {
            time = 1f;
            isDone = true;
            return;
        }
        time += Time.deltaTime * speed;
        img.fillAmount = time;
        img2.transform.rotation = Quaternion.Euler(0, 0, -time * 360 );
    }

    void Minus()
    {
        img.fillClockwise = false;
        if (img.fillAmount == 0)
        {
            time = 0f;
            isDone = false;
            return;
        }
        time -= Time.deltaTime * speed;
        img.fillAmount = time;
        img2.transform.rotation = Quaternion.Euler(0, 0, time * 360);
    }
        
        
}

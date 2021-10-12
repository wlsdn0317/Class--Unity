using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCtrl : MonoBehaviour
{
    public Slider slider;
    public GameObject menuPanel;
    public Text timerTxt;

    public float timer;
    public float maxTime;

    void Start()
    {
        timer = 15f;
        maxTime = 15f;
    }

    void Update()
    {
        timerTxt.text = timer.ToString();
        if (timer >= 0)
        {
            slider.value = timer/maxTime;
            timer -= Time.deltaTime;
        }
        else if(timer < 0)
        {
            menuPanel.SetActive(true);
            Time.timeScale = 0f;
            timer = 15f;
        }
    }
}

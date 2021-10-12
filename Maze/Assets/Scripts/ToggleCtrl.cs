using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCtrl : MonoBehaviour
{
    public Toggle toggle;
    public GameObject miniMap;

    void Start()
    {
        toggle.isOn = true;
    }

    void Update()
    {
        if (toggle.isOn)
        {
            miniMap.SetActive(true);
        }
        else
        {
            miniMap.SetActive(false);
        }
    }
}

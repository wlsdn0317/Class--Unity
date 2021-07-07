using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBoomCountViewer : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;
    private TextMeshProUGUI textBoomCount;

    void Awake()
    {
        textBoomCount = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textBoomCount.text = "x " + weapon.BoomCount;
    }
}

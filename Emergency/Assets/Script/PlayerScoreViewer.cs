using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreViewer : MonoBehaviour
{
    [SerializeField]
    private Player_Scr PlayerController;
    private TextMeshProUGUI textScore;

    void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textScore.text = "Score " + PlayerController.Score;
    }
}

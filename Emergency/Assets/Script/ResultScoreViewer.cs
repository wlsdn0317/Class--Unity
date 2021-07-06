using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScoreViewer : MonoBehaviour
{
    private TextMeshProUGUI textResultScore;

    private void Awake()
    {
        textResultScore = GetComponent<TextMeshProUGUI>();
        //Stage���� ������ ������ �ҷ��ͼ� score ������ ����
        int score = PlayerPrefs.GetInt("Score");
        //textResultScore UI�� ���� ����
        textResultScore.text = "Result Score" + score;
    }

    void Update()
    {
        
    }
}

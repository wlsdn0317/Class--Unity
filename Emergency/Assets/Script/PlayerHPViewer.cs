using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField]
    private Player_Hp player_HP;
    private Slider SliderHP;
    void Start()
    {
        SliderHP = GetComponent<Slider>();
    }

    /// <summary>
    /// tip. �� ��Ȯ�� ������δ� �̺�Ʈ�� �̿��� ü�� ������ �ٲ𶧸� UI ���� ����
    /// </summary>

    void Update()
    {
        //Slider UI�� ���� ü�� ������ ������Ʈ
        SliderHP.value = player_HP.CurrentHP / player_HP.MaxHp;
    }
}

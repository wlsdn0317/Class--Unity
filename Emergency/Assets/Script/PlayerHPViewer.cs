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
    /// tip. 더 정확한 방법으로는 이벤트를 이용해 체력 정보가 바뀔때만 UI 정보 갱신
    /// </summary>

    void Update()
    {
        //Slider UI에 현재 체력 정보를 업데이트
        SliderHP.value = player_HP.CurrentHP / player_HP.MaxHp;
    }
}

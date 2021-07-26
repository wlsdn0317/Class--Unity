using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //Slot 프리팸에 추가할 drop 스크립트
        //Slot의 자식이 0이라는 말은 비어있는지 확인하는 것
        if(transform.childCount == 0)
        {
            //드래그 해온 아이템의 부모를 드랍한 슬롯으로 변경해줌
            //아이탬을 끌어다 놓은 슬롯에다가 아이템 떨구기
            Drag.draggingItem.transform.SetParent(transform);
        }
    }
}

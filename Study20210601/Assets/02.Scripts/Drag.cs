using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler,IEndDragHandler
{
    Transform itemTr;
    Transform inventoryTr;

    Transform itemListTr;
    CanvasGroup canvasGroup;
    
    //드래그 중인 아이템이 무엇인지 명확히 하기 위한 변수
    //static은 공용 속성을 지니도록 만듦 ex)약수터 같은 느낌
    public static GameObject draggingItem = null;
    void Start()
    {
        itemTr = GetComponent<Transform>();
        inventoryTr = GameObject.Find("Inventory").GetComponent<Transform>();
        itemListTr = GameObject.Find("ItemList").GetComponent<Transform>();

        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //드래그가 발생할 때 아이템의 위치를 마우스 커서의 위치로 변경
        itemTr.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(inventoryTr);
        //드래그 중인 아이템의 정보를 저장
        draggingItem = this.gameObject;
        //드래그가 시작되면 다른 UI 이벤트를 받지 않도록 설정
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //드래그가 종료되면 가지고 있던 아이템 정보 비워줌
        draggingItem = null;
        //드래그가 종료되면 다른 UI 이벤트를 받도록 설정
        canvasGroup.blocksRaycasts = true;

        //슬롯에 드래그하지 않았을 경우에 원래의 ItemList로 이동
        if(itemTr.parent == inventoryTr)
        {
            itemTr.SetParent(itemListTr.transform);
        }
    }
}

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
    
    //�巡�� ���� �������� �������� ��Ȯ�� �ϱ� ���� ����
    //static�� ���� �Ӽ��� ���ϵ��� ���� ex)����� ���� ����
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
        //�巡�װ� �߻��� �� �������� ��ġ�� ���콺 Ŀ���� ��ġ�� ����
        itemTr.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(inventoryTr);
        //�巡�� ���� �������� ������ ����
        draggingItem = this.gameObject;
        //�巡�װ� ���۵Ǹ� �ٸ� UI �̺�Ʈ�� ���� �ʵ��� ����
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //�巡�װ� ����Ǹ� ������ �ִ� ������ ���� �����
        draggingItem = null;
        //�巡�װ� ����Ǹ� �ٸ� UI �̺�Ʈ�� �޵��� ����
        canvasGroup.blocksRaycasts = true;

        //���Կ� �巡������ �ʾ��� ��쿡 ������ ItemList�� �̵�
        if(itemTr.parent == inventoryTr)
        {
            itemTr.SetParent(itemListTr.transform);
        }
    }
}

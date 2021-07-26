using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //Slot �����Կ� �߰��� drop ��ũ��Ʈ
        //Slot�� �ڽ��� 0�̶�� ���� ����ִ��� Ȯ���ϴ� ��
        if(transform.childCount == 0)
        {
            //�巡�� �ؿ� �������� �θ� ����� �������� ��������
            //�������� ����� ���� ���Կ��ٰ� ������ ������
            Drag.draggingItem.transform.SetParent(transform);
        }
    }
}

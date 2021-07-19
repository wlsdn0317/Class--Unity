using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    Camera uiCamera;
    Canvas canvas;
    RectTransform rectParent;
    RectTransform rectHp;

    public Vector3 offset = Vector3.zero;
    public Transform targetTr;

    
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        uiCamera = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectHp = gameObject.GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        //WorldToScreenPoint : 3���� ����Ƽ �������� ��ǥ�� �����(ZD)��ǥ�� ��ȯ
        var screenPos = Camera.main.WorldToScreenPoint(targetTr.position + offset);

        //ī�޶��� ���� ������ ��ġ�� �� ��ǥ�� ����
        if (screenPos.z < 0f)
        {
            screenPos *= -1f;
        }
        var localPos = Vector2.zero;
        //ScreenPointToLocalPointInRectangle
        //��ũ��(2D)��ǥ�� RectTransform ���� ��ǥ�� ��ȯ
        //�Ķ����(�θ��� RectTransform,��ũ����ǥ,UI������ ī�޶�,OUT ��ȯ �Ϸ�� ��ǥ)
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, uiCamera, out localPos);
        //ü�¹��� ��ġ�� ���ؼ� ��ȯ�� RectTransform ��ǥ�� �����Ͽ� ��ġ����
        rectHp.localPosition = localPos;
    }
}

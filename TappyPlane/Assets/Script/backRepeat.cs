using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backRepeat : MonoBehaviour
{
    Material mat;//���׸���
    Vector2 mat_Offset;//���׸����� Offset��ġ�� ������ ����
    void Start()
    {
        mat = this.GetComponent<SpriteRenderer>().material;
        //������Ʈ�� ȭ�鿡�� �׷����� ����� ǥ�����ִ�
        //���׸����� �����´�.
    }

    void Update()
    {

        mat_Offset = mat.mainTextureOffset;
        //���׸����� ������ ���� ������ ����
        mat_Offset.x += Time.deltaTime * 2;
        //������ ��ġ�� x���� ����
        mat.mainTextureOffset = mat_Offset;
        //������ ��ġ�� �ٽ� �����¿� ����
    }
}

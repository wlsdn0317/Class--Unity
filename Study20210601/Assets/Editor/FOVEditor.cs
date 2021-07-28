using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



//Editor Ŭ������ �ν����ͳ� ������ ȭ�� ����
//�����Ӱ� �����ϰų� Ȯ���� �� �ֵ��� �ϱ� ���� Ŭ����
//���� ���� ����ڰ� Ŀ������ ������ ���ۿ� ����

//EnemyFOV ��ũ��Ʈ�� �����ϴ� Ŀ���� �����ʹ� ��� ���
[CustomEditor(typeof(EnemyFOV))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        //�����Ͱ� ������ ����� ����
        //EnemyFOV Ŭ���� ����
        EnemyFOV fov = (EnemyFOV)target;

        //���� ���� �������� ��ǥ�� ���(�þ߰��� 1/2)
        Vector3 fromAnglePos = fov.CirclePoint(-fov.viewAngle * 0.5f);

        //������ ������ ������� ����
        Handles.color = Color.white;

        //�ܰ����� �ִ� ���� �׸�
        Handles.DrawWireDisc(fov.transform.position //���� ��ǥ
                             , Vector3.up   //��� ����
                             , fov.viewRange); //���ǹ�����

        //��ä��(�þ߰��� ǥ��)
        // R G B Alpha
        Handles.color = new Color(1, 1, 1, 0.2f);

        Handles.DrawSolidArc(fov.transform.position //���� ��ǥ
                            , Vector3.up        //��� ����
                            , fromAnglePos       //��ä�� ���� ��ǥ(����)
                            , fov.viewAngle     //��ä���� ����
                            , fov.viewRange);    //��ä���� ������

        //�þ߰� �󺧸�
        Handles.Label(fov.transform.position +
                        fov.transform.forward * 2f,
                        fov.viewAngle.ToString());
    }
}

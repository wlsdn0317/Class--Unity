using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



//Editor 클래스는 인스펙터나 윈도우 화면 등을
//자유롭게 구성하거나 확장할 수 있도록 하기 위한 클래스
//쉽게 말해 사용자가 커스텀한 제작툴 제작에 사용됨

//EnemyFOV 스크립트를 보조하는 커스텀 에디터다 라고 명시
[CustomEditor(typeof(EnemyFOV))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        //에디터가 보조할 대상을 지정
        //EnemyFOV 클래스 참조
        EnemyFOV fov = (EnemyFOV)target;

        //원주 위에 시작점의 좌표를 계산(시야각의 1/2)
        Vector3 fromAnglePos = fov.CirclePoint(-fov.viewAngle * 0.5f);

        //원주의 색상을 흰색으로 지정
        Handles.color = Color.white;

        //외곽선만 있는 원을 그림
        Handles.DrawWireDisc(fov.transform.position //원점 좌표
                             , Vector3.up   //노멀 벡터
                             , fov.viewRange); //원의반지름

        //부채꼴(시야각을 표현)
        // R G B Alpha
        Handles.color = new Color(1, 1, 1, 0.2f);

        Handles.DrawSolidArc(fov.transform.position //원점 좌표
                            , Vector3.up        //노멀 벡터
                            , fromAnglePos       //부채꼴 시작 죄표(각도)
                            , fov.viewAngle     //부채꼴의 각도
                            , fov.viewRange);    //부채꼴의 반지름

        //시야각 라벨링
        Handles.Label(fov.transform.position +
                        fov.transform.forward * 2f,
                        fov.viewAngle.ToString());
    }
}

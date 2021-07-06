using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backRepeat : MonoBehaviour
{
    Material mat;//마테리얼
    Vector2 mat_Offset;//마테리얼의 Offset수치를 저장할 변수
    void Start()
    {
        mat = this.GetComponent<SpriteRenderer>().material;
        //오브젝트가 화면에서 그려지는 방식을 표현해주는
        //마테리얼을 가져온다.
    }

    void Update()
    {

        mat_Offset = mat.mainTextureOffset;
        //마테리얼의 오프셋 값을 변수에 저장
        mat_Offset.x += Time.deltaTime * 2;
        //오프셋 수치중 x값만 변경
        mat.mainTextureOffset = mat_Offset;
        //변경한 수치를 다시 오프셋에 대입
    }
}

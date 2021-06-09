using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)//collision을 통해서 충돌한 물체가 어떤 것 구별
    {
            //충돌이 발생한 놈들 중에서 BULLET 태그만 검출
        if (collision.collider.tag == "BULLET")//충돌한물체.콜라이더가져오기.테그
        {
            //충돌이 발생한 오브젝트 삭제
            Destroy(collision.gameObject);
           //collision.gameObject.SetActive(false);
        }
        
    }
}

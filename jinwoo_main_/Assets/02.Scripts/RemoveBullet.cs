using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{

    public GameObject sparkEffect;//스파크 프리팹
    private void OnCollisionEnter(Collision collision)//collision을 통해서 충돌한 물체가 어떤 것 구별
    {
            //충돌이 발생한 놈들 중에서 BULLET 태그만 검출
        if (collision.collider.tag == "BULLET")//충돌한물체.콜라이더가져오기.테그
        {
            //스파크 이펙트 함수 호출
            ShowEffect(collision);


            //충돌이 발생한 오브젝트 삭제
            Destroy(collision.gameObject);
           //collision.gameObject.SetActive(false);
        }
        
    }

    void ShowEffect(Collision coll)
    {
        //충돌 지점의 정보를 가지고옴.
        //충돌 시 발생한 최초의 위치 정보
        ContactPoint contact = coll.contacts[0];
        //FromToRotation(회전시키고자 하는 벡터, 타겟 벡터)
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
        //충돌이 난 후 이펙츠의 효과 방향(Z)을
        //법선벡터(총알이 날라온 방향 -Z)방향으로 돌려서 생성
        //Instantiate(스파크이펙트를, 컨텍한지점에서, rot방향으로 돌려서 생성)
        //총알이 발사된 위치로 이동(드럼통에서 조금 띄어서 총알자구 생성)
        Vector3 point = contact.point + (-contact.normal * 0.03f);
        GameObject spark = Instantiate(sparkEffect, point, rot);
        //동적생성된 이펙트의 부모로 드럼통을 설정
        spark.transform.SetParent(this.transform);
    }
}

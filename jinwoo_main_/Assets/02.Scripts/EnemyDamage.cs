using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    const string bulletTag = "BULLET";

    float hp = 100f; //체력
    GameObject bloodEffect; //혈흔 효과 변수

    // Start is called before the first frame update
    void Start()
    {
        //Load 함수는 예약폴더인 Resources 에서
        //데이터를 불러오는 함수임
        //Load<데이터유형>("파일의 경로");
        //최상위 경로는 Resources 폴더임 ex)C 드라이브
        //파일의 경로는 하위 폴더명 + 파일명까지 정확하게 풀경로를 명시
        bloodEffect = Resources.Load<GameObject>("Blood");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == bulletTag)
        {
            //혈흔 효과 함수 호출
            ShowBloodEffect(collision);
            //총알 삭제
            Destroy(collision.gameObject);
            hp -= collision.gameObject.GetComponent<BulletCtrl>().damage;
            //체력이 0 이하가 되면 적이 죽었다고 판단
            if(hp <= 0)
            {
                //상태 변환 해줌
                GetComponent<EnemyAI>().state = EnemyAI.State.DIE;
            }
        }
    }

    void ShowBloodEffect(Collision coll)
    {
        //충돌 위치 값 가져오기
        Vector3 pos = coll.contacts[0].point;
        //충돌 위치의 법선 벡터(총알이 날라온 방향)구하기
        Vector3 _normal = coll.contacts[0].normal;
        //총알이 날라온 방향값 계산
        Quaternion rot = Quaternion.FromToRotation(Vector3.back, _normal);
        //혈흔 효과 동적 생성
        GameObject blood = Instantiate<GameObject>(bloodEffect, pos, rot);
        //1초후 삭제
        Destroy(blood, 1f);
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}

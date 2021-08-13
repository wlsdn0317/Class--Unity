using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    const string bulletTag = "BULLET";

    float hp = 100f; //체력
    GameObject bloodEffect; //혈흔 효과 변수

    float initHp = 100f;//최기설정 체력
    public GameObject hpBarPrefab;
    public Vector3 hpBaroffset = new Vector3(0, 2.2f, 0);
    Canvas uiCanvas;    //부모가 될 캔버스 객체
    Image hpBarImage;   //생명력 수치

    void Start()
    {
        //Load 함수는 예약폴더인 Resources 에서
        //데이터를 불러오는 함수임
        //Load<데이터유형>("파일의 경로");
        //최상위 경로는 Resources 폴더임 ex) C 드라이브
        //파일의 경로는 하위 폴더명 + 파일명까지 정확하게 풀경로를 명시
        bloodEffect = Resources.Load<GameObject>("Blood");
        setHpBar();
    }

    void setHpBar()
    {
        uiCanvas = GameObject.Find("UI Canvas").GetComponent<Canvas>();
        GameObject hpBar = Instantiate(hpBarPrefab, uiCanvas.transform);
        hpBarImage = hpBar.GetComponentsInChildren<Image>()[1];

        var _hpBar = hpBar.GetComponent<EnemyHpBar>();
        //_hpBar가 추적해야할 대상으로 Enemy 지정
        _hpBar.targetTr = gameObject.transform;
        _hpBar.offset = hpBaroffset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == bulletTag)
        {
            //혈흔 효과 함수 호출
            ShowBloodEffect(collision);
            //총알 삭제
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);

            hp -= collision.gameObject.GetComponent<BulletCtrl>().damage;

            hpBarImage.fillAmount = hp / initHp;

            //체력이 0 이하가 되면 적이 죽었다고 판단
            if(hp <= 0)
            {
                //상태 변환 해줌
                GetComponent<EnemyAI>().state = EnemyAI.State.DIE;
                hpBarImage.GetComponentsInParent<Image>()[1].color = Color.clear;

                //싱글턴 패널을 활용하여 적이 죽었을 때 스코어 증가
                GameManager.instance.IncKillCount();
                //죽은 애니메이션 이후 남아있는 콜라이더 비활성화
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }

    void ShowBloodEffect(Collision coll)
    {
        //충돌 위치 값 가져오기
        Vector3 pos = coll.contacts[0].point;
        //충돌 위치의 법선 벡터(총알이 날라온 방향) 구하기
        Vector3 _normal = coll.contacts[0].normal;
        //총알이 날라온 방향값 계산
        Quaternion rot = Quaternion.FromToRotation(Vector3.back, _normal);
        //혈흔 효과 동적 생성
        GameObject blood = Instantiate(bloodEffect, pos, rot);
        //1초 후 삭제
        Destroy(blood, 1f);
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Fire : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;
    ParticleSystem muzzleFlash;

    PhotonView pv;
    //캐싱이라고 해서 미리 선점해두는거(예약)
    //이유는 성능향상
    bool isMouseClick => Input.GetMouseButtonDown(0);



    void Start()
    {
        pv = GetComponent<PhotonView>();
        muzzleFlash = firePos.Find("MuzzleFlash").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //내 캐릭터이면서 마우스 좌클릭
        if (pv.IsMine && isMouseClick) 
        {
            //공격 함수와 RPC함수 호출
            FireBullet();
            //RPC 함수 호출
            //RPC(함수명,타겟,옵션)
            pv.RPC("FireBullet", RpcTarget.Others, null);
        }
    }


    [PunRPC] //RPC 함수라는것을 명확하게 명시해주어야 동작함
    void FireBullet()
    {
        //총구의 화염효과가 실행중일 때는 화염효과 실행 안되도록
        //중복 실행 안되도록하는 구문
        if (!muzzleFlash.isPlaying)
        {
            muzzleFlash.Play(true);
        }
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
    }
}

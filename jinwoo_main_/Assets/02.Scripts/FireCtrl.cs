using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//struct = 구조체, 클래스 열화판으로 생각하면 편함
//클래스는 구조체 이후 등장한 개념
//그러나 지금에와서는 메모리 적재 형태의 차이만 있을뿐
//기능상의 큰 차이는 없음.

[System.Serializable]//직렬화 인스펙터에 표시

public struct PlayerSfx
{
    public AudioClip[] fire;
    public AudioClip[] reload;
}





public class FireCtrl : MonoBehaviour
{
    public enum WeaponType
    {
        RIFLE = 0,
        SHOTGUN        
    }
    public WeaponType currWeapon = WeaponType.RIFLE;

    public GameObject bullet;//총알 프리팹 사용하기 위한 변수
    public Transform firePos;//총알 발사 위치
    public ParticleSystem catridge;// 탄피 프리팹
    private ParticleSystem muzzleFlash;//총구 화염 파티클

    AudioSource _audio;
    public PlayerSfx playerSfx;//오디오 클립 저장 변수

    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
    }
    //
    // Update is called once per frame
    void Update()
    {
        //0이면 좌클릭 1이면 우클릭
        //GetMouseButtonDown 함수는 눌렀을 때 1번만 동작
        if (Input.GetMouseButtonDown(0))
        {
            //공격함수 호출
            Fire();
        }
    }

    void Fire()
    {
        //Instantiate(동적생성할 오브젝트, 위치, 방향);
        //사용되지 않는 객체(Object)를 활성화 해주는 함수
        Instantiate(bullet, firePos.position, firePos.rotation);
        catridge.Play();//탄피 파티클 재생
        muzzleFlash.Play();//총구 화염 파티클 재생

        FireSfx();//공격시 사운드 발생   
    }

    void FireSfx()
    {
        //현재 선택된 무기의 넘버에 맞는 사운드를 선택해서 가지고옴
        var _sfx = playerSfx.fire[(int)currWeapon];
        //PlayOneShot(재생 음원, 볼륨 크기)
        //볼륨 크기는 0~1 사이의 값
        _audio.PlayOneShot(_sfx, 1f);
    }
}

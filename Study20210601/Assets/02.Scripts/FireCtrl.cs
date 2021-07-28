using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    public GameObject bullet; //총알 프리팹 사용하기 위한 변수
    public Transform firePos; //총알 발사 위치
    public ParticleSystem catridge; //탄피 프리팹
    private ParticleSystem muzzleFlash;//총구 화염 파티클

    AudioSource _audio;
    public PlayerSfx playerSfx;//오디오 클립 저장 변수

    Shake shake;

    public Image magazineImg;
    public Text magazineText;

    public int maxBullet = 10; //최대 총알 수
    public int remainingBullet = 10; //남은 총알 수

    public float reloadTime = 2f;
    bool isReloading = false;

    public Sprite[] weaponIcons;//변경할 무기 이미지
    public Image weaponImage;//교체할 무기 이미지 UI

    //자동 공격을 위한 변수 선언
    int enemyLayer;
    int obstacleLayer;
    int layerMask; //여러 레이어를 병합하여 사용할 레이어 마스크

    bool isFire = false;
    float nextFire;
    public float fireRate = 0.1f;

    public void OnChangeWeapon()
    {
        currWeapon++;
        currWeapon = (WeaponType)((int)currWeapon % 2);
        weaponImage.sprite = weaponIcons[(int)currWeapon];
    }
    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
        shake = GameObject.Find("CameraRig").GetComponent<Shake>();
        //레이어의 이름을 통하여 레이어값 미리 설정
        enemyLayer = LayerMask.NameToLayer("ENEMY");
        obstacleLayer = LayerMask.NameToLayer("OBSTACLE");
        //100 | 001 = 101
        //or연산은 둘 다 0이 아닌 경우에 1로 처리함
        layerMask = 1 << enemyLayer | 1 << obstacleLayer;
    }

    void Update()
    {

        Debug.DrawLine(firePos.position, firePos.forward * 20f, Color.green);
        //IsPointerOverGameObject 함수는 UI가 클릭되면
        //True값을 반환하는 놈
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //자동공격
        RaycastHit hit;
        if (Physics.Raycast(firePos.position,firePos.forward,out hit,30f,layerMask))
        {
            //감지한 LayerMask 중에서 태그가 ENEMY인 경우만 공격
            
                isFire = (hit.collider.CompareTag("ENEMY"));
        }
        else
        {
            isFire = false;
        }
        if(!isReloading && isFire)
        {
            if(Time.time > nextFire)
            {
                remainingBullet--;
                Fire();
                if(remainingBullet == 0)
                {
                    StartCoroutine(Reloading());
                }
                nextFire = Time.time + fireRate;
            }
        }

        //0이면 좌클릭 1이면 우클릭
        //GetMouseButtonDown 함수는 눌렀을 때 1번만 동작
        if (!isReloading && Input.GetMouseButtonDown(0))
        {
            remainingBullet--;

            //공격함수 호출
            Fire();

            if (remainingBullet == 0)
            {
                //재장전 코루틴 함수 호출
                StartCoroutine(Reloading());
            }
        }
    }

    void Fire()
    {
        //shake 스크립트 내부의 ShakeCamera 코루틴 함수 호출
        //매개변수 값을 생략했으므로 ShakeCamera 함수에 설정된
        //기본값으로 동작함
        StartCoroutine(shake.ShakeCamera());
        //Instantiate(동적생성할 오브젝트, 위치, 방향);
        //사용되지 않는 객체(Object)를 활성화 해주는 함수
        //Instantiate(bullet, firePos.position, firePos.rotation);

        //오브젝트 풀에서 총알 뽑아오기
        var _bullet = GameManager.instance.GetBullet();
        if(_bullet != null)
        {
            _bullet.transform.position = firePos.position;
            _bullet.transform.rotation = firePos.rotation;
            _bullet.SetActive(true);
        }

        catridge.Play(); //탄피 파티클 재생
        muzzleFlash.Play();//총구 화염 파티클 재생

        FireSfx(); //공격시 사운드 발생

        magazineImg.fillAmount = (float)remainingBullet / (float)maxBullet;
        UpdateBulletText();
    }

    IEnumerator Reloading()
    {
        isReloading = true;
        _audio.PlayOneShot(playerSfx.reload[(int)currWeapon], 1f);

        //무기가 가지고 있는 재장전 사운드 길이 + 0.3초 만큼 대기 시간 부여
        float audioLen = playerSfx.reload[(int)currWeapon].length + 0.3f;
        yield return new WaitForSeconds(audioLen);

        isReloading = false;
        magazineImg.fillAmount = 1f;
        remainingBullet = maxBullet;

        //재장전 함수 호출
        UpdateBulletText();
    }

    void UpdateBulletText()
    {
        magazineText.text = string.Format("<color=#00ff00>{0}</color>/{1}", 
                                                                        remainingBullet, maxBullet);
    }

    void FireSfx()
    {
        //현재 선택된 무기의 넘버에 맞는 사운드를 선택해서 가지고옴
        var _sfx = playerSfx.fire[(int)currWeapon];
        //PlayOneShot(재생 음원, 볼륨 크기)
        //볼륨 크기는 0 ~ 1 사이의 값
        _audio.PlayOneShot(_sfx, 1f);
    }

    
}

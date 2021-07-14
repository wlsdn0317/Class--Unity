using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//struct = ����ü, Ŭ���� ��ȭ������ �����ϸ� ����
//Ŭ������ ����ü ���� ������ ����
//�׷��� ���ݿ��ͼ��� �޸� ���� ������ ���̸� ������
//��ɻ��� ū ���̴� ����.

[System.Serializable]//����ȭ �ν����Ϳ� ǥ��
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

    public GameObject bullet; //�Ѿ� ������ ����ϱ� ���� ����
    public Transform firePos; //�Ѿ� �߻� ��ġ
    public ParticleSystem catridge; //ź�� ������
    private ParticleSystem muzzleFlash;//�ѱ� ȭ�� ��ƼŬ

    AudioSource _audio;
    public PlayerSfx playerSfx;//����� Ŭ�� ���� ����

    Shake shake;

    public Image magazineImg;
    public Text magazineText;

    public int maxBullet = 10; //�ִ� �Ѿ� ��
    public int remainingBullet = 10; //���� �Ѿ� ��

    public float reloadTime = 2f;
    bool isReloading = false;

    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
        shake = GameObject.Find("CameraRig").GetComponent<Shake>();
    }

    void Update()
    {
        //0�̸� ��Ŭ�� 1�̸� ��Ŭ��
        //GetMouseButtonDown �Լ��� ������ �� 1���� ����
        if (!isReloading && Input.GetMouseButtonDown(0))
        {
            remainingBullet--;

            //�����Լ� ȣ��
            Fire();

            if (remainingBullet == 0)
            {
                //������ �ڷ�ƾ �Լ� ȣ��
                StartCoroutine(Reloading());
            }
        }
    }

    void Fire()
    {
        //shake ��ũ��Ʈ ������ ShakeCamera �ڷ�ƾ �Լ� ȣ��
        //�Ű����� ���� ���������Ƿ� ShakeCamera �Լ��� ������
        //�⺻������ ������
        StartCoroutine(shake.ShakeCamera());
        //Instantiate(���������� ������Ʈ, ��ġ, ����);
        //������ �ʴ� ��ü(Object)�� Ȱ��ȭ ���ִ� �Լ�
        //Instantiate(bullet, firePos.position, firePos.rotation);

        //������Ʈ Ǯ���� �Ѿ� �̾ƿ���
        var _bullet = GameManager.instance.GetBullet();
        if(_bullet != null)
        {
            _bullet.transform.position = firePos.position;
            _bullet.transform.rotation = firePos.rotation;
            _bullet.SetActive(true);
        }

        catridge.Play(); //ź�� ��ƼŬ ���
        muzzleFlash.Play();//�ѱ� ȭ�� ��ƼŬ ���

        FireSfx(); //���ݽ� ���� �߻�

        magazineImg.fillAmount = (float)remainingBullet / (float)maxBullet;
        UpdateBulletText();
    }

    IEnumerator Reloading()
    {
        isReloading = true;
        _audio.PlayOneShot(playerSfx.reload[(int)currWeapon], 1f);

        //���Ⱑ ������ �ִ� ������ ���� ���� + 0.3�� ��ŭ ��� �ð� �ο�
        float audioLen = playerSfx.reload[(int)currWeapon].length + 0.3f;
        yield return new WaitForSeconds(audioLen);

        isReloading = false;
        magazineImg.fillAmount = 1f;
        remainingBullet = maxBullet;

        //������ �Լ� ȣ��
        UpdateBulletText();
    }

    void UpdateBulletText()
    {
        magazineText.text = string.Format("<color=#00ff00>{0}</color>/{1}", 
                                                                        remainingBullet, maxBullet);
    }

    void FireSfx()
    {
        //���� ���õ� ������ �ѹ��� �´� ���带 �����ؼ� ��������
        var _sfx = playerSfx.fire[(int)currWeapon];
        //PlayOneShot(��� ����, ���� ũ��)
        //���� ũ��� 0 ~ 1 ������ ��
        _audio.PlayOneShot(_sfx, 1f);
    }

    
}
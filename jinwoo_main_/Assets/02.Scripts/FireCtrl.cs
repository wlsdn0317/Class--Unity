using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public GameObject bullet;//�Ѿ� ������ ����ϱ� ���� ����
    public Transform firePos;//�Ѿ� �߻� ��ġ
    public ParticleSystem catridge;// ź�� ������
    private ParticleSystem muzzleFlash;//�ѱ� ȭ�� ��ƼŬ

    AudioSource _audio;
    public PlayerSfx playerSfx;//����� Ŭ�� ���� ����

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
        //0�̸� ��Ŭ�� 1�̸� ��Ŭ��
        //GetMouseButtonDown �Լ��� ������ �� 1���� ����
        if (Input.GetMouseButtonDown(0))
        {
            //�����Լ� ȣ��
            Fire();
        }
    }

    void Fire()
    {
        //Instantiate(���������� ������Ʈ, ��ġ, ����);
        //������ �ʴ� ��ü(Object)�� Ȱ��ȭ ���ִ� �Լ�
        Instantiate(bullet, firePos.position, firePos.rotation);
        catridge.Play();//ź�� ��ƼŬ ���
        muzzleFlash.Play();//�ѱ� ȭ�� ��ƼŬ ���

        FireSfx();//���ݽ� ���� �߻�   
    }

    void FireSfx()
    {
        //���� ���õ� ������ �ѹ��� �´� ���带 �����ؼ� �������
        var _sfx = playerSfx.fire[(int)currWeapon];
        //PlayOneShot(��� ����, ���� ũ��)
        //���� ũ��� 0~1 ������ ��
        _audio.PlayOneShot(_sfx, 1f);
    }
}

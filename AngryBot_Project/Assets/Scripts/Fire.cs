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
    //ĳ���̶�� �ؼ� �̸� �����صδ°�(����)
    //������ �������
    bool isMouseClick => Input.GetMouseButtonDown(0);



    void Start()
    {
        pv = GetComponent<PhotonView>();
        muzzleFlash = firePos.Find("MuzzleFlash").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //�� ĳ�����̸鼭 ���콺 ��Ŭ��
        if (pv.IsMine && isMouseClick) 
        {
            //���� �Լ��� RPC�Լ� ȣ��
            FireBullet();
            //RPC �Լ� ȣ��
            //RPC(�Լ���,Ÿ��,�ɼ�)
            pv.RPC("FireBullet", RpcTarget.Others, null);
        }
    }


    [PunRPC] //RPC �Լ���°��� ��Ȯ�ϰ� ������־�� ������
    void FireBullet()
    {
        //�ѱ��� ȭ��ȿ���� �������� ���� ȭ��ȿ�� ���� �ȵǵ���
        //�ߺ� ���� �ȵǵ����ϴ� ����
        if (!muzzleFlash.isPlaying)
        {
            muzzleFlash.Play(true);
        }
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
    }
}

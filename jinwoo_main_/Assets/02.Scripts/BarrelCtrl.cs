using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect; //���� ����Ʈ ������ ����
    int hitCount = 0; //�Ѿ� �´� Ƚ��
    Rigidbody rb;

    public Mesh[] meshes; // ����� ����ϴ� �Ž�;
    MeshFilter meshFilter;// �Ž��� �������� �޽�����;

    public Texture[] texures; //�����⸦ ����ϴ� �ؽ�ó
    MeshRenderer _renderer; //�ؽ�ó�� �������� �޽� ������

    public float expRadius = 10f; //���� �ݰ�

    AudioSource _audio;
    public AudioClip expSfx;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshFilter = GetComponent<MeshFilter>();
        _renderer = GetComponent<MeshRenderer>();
        int idx = Random.Range(0, texures.Length);
        _renderer.material.mainTexture = texures[idx];

        _audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BULLET"))
        {
            hitCount++; //�Ѿ��̶� �浹�ϸ� �浹 Ƚ�� ����
            if(hitCount == 3)
            {
                ExpBarrel();//���� ȿ�� �Լ� ȣ��
            }
        }
    }
    void ExpBarrel()
    {   
        //���������� �Ǵ� ���� effect��� ��ü(����) �̸��� �ο�����
        //���� effect��� ��ü���� ���ؼ� ���� ����
        GameObject effect = Instantiate(expEffect, transform.position, Quaternion.identity);
        //���� ���� �ð��� �ο�, 2���� ���� ����Ʈ ����
        Destroy(effect,2f);
        //rb.mass = 1f;
        //rb.AddForce(Vector3.up * 500f);
        IndirectDamage(transform.position);


        //��ϵ� �޽� �߿��� �ϳ��� �����ϱ� ���Ͽ� ������ ���ڸ� ����
        int idx = Random.Range(0, meshes.Length);
        //���� �ε����� �ش��ϴ� �޽��� �����ؼ� �޽����Ϳ� ����
        meshFilter.sharedMesh = meshes[idx];

        _audio.PlayOneShot(expSfx, 1f);
    }

    void IndirectDamage(Vector3 pos)
    {
        //OverlapSphere �޼ҵ�� ������ ���� ���ؼ�
        //�����ȿ� �ִ� ��� ������Ʈ�� ��� �����ؼ� �������.
        Collider[] colls = Physics.OverlapSphere(pos,expRadius, 1 << 8); //pos =���� ����, expRadius = ���� �ݰ�, 1<<8 = ������ �� ���̾� (256)

        //����� ������Ʈ�� ���������� �ϳ��� �����ϵ��� ��
        //1�� �����ϴ� for ���� ������
        foreach(var coll in colls)
        {
            var _rb = coll.GetComponent<Rigidbody>();
            _rb.mass = 1;
            //�������� ���߷��� �ƴ϶�
            //���� �Ʒ��� ���߷��� �ֱ� ���ؼ� �����
            //AddExplosionForce(Ⱦ(����) ���߷�, ���� ����, ���� �ݰ�, ��(����))
            _rb.AddExplosionForce(600f, pos, expRadius, 500f);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

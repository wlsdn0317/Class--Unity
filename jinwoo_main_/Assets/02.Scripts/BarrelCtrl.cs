using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect; //폭발 이펙트 프리팹 변수
    int hitCount = 0; //총알 맞는 횟수
    Rigidbody rb;

    public Mesh[] meshes; // 모양을 담당하는 매쉬;
    MeshFilter meshFilter;// 매쉬를 적용해줄 메쉬필터;

    public Texture[] texures; //껍데기를 담당하는 텍스처
    MeshRenderer _renderer; //텍스처를 적용해줄 메쉬 렌더러

    public float expRadius = 10f; //폭발 반경

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshFilter = GetComponent<MeshFilter>();
        _renderer = GetComponent<MeshRenderer>();
        int idx = Random.Range(0, texures.Length);
        _renderer.material.mainTexture = texures[idx];
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BULLET"))
        {
            hitCount++; //총알이랑 충돌하면 충돌 횟수 증가
            if(hitCount == 3)
            {
                ExpBarrel();//폭발 효과 함수 호출
            }
        }
    }
    void ExpBarrel()
    {   
        //동적생성이 되는 순간 effect라는 객체(변수) 이름을 부여해줌
        //이후 effect라는 객체명을 통해서 제어 가능
        GameObject effect = Instantiate(expEffect, transform.position, Quaternion.identity);
        //삭제 지연 시간을 부여, 2초후 폭발 이펙트 삭제
        Destroy(effect,2f);
        //rb.mass = 1f;
        //rb.AddForce(Vector3.up * 500f);
        IndirectDamage(transform.position);


        //등록된 메쉬 중에서 하나를 선택하기 위하여 랜덤한 숫자를 뽑음
        int idx = Random.Range(0, meshes.Length);
        //뽑은 인덱스에 해당하는 메쉬를 선택해서 메쉬필터에 적용
        meshFilter.sharedMesh = meshes[idx];
    }

    void IndirectDamage(Vector3 pos)
    {
        //OverlapSphere 메소드는 지정된 값에 의해서
        //범위안에 있는 대상 오브젝트를 모두 검출해서 가지고옴.
        Collider[] colls = Physics.OverlapSphere(pos,expRadius, 1 << 8); //pos =폭발 원점, expRadius = 폭발 반경, 1<<8 = 영향을 줄 레이어 (256)

        //검출된 오브젝트를 순차적으로 하나씩 선택하도록 함
        //1씩 증가하는 for 문과 동일함
        foreach(var coll in colls)
        {
            var _rb = coll.GetComponent<Rigidbody>();
            _rb.mass = 1;
            //직선적인 폭발력이 아니라
            //위로 아래로 폭발력을 주기 위해서 사용함
            //AddExplosionForce(횡(가로) 폭발력, 폭발 관점, 폭발 반경, 종(세로))
            _rb.AddExplosionForce(600f, pos, expRadius, 500f);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

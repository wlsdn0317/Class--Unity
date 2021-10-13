using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //사망후 투명처리위한 MesheRenderer
    Renderer[] renderers;

    int iniHp = 100;
    public int currHp = 100;

    Animator anim;
    CharacterController cc;

    readonly int hashDie = Animator.StringToHash("Die");
    readonly int hashRespawn = Animator.StringToHash("Respawn");

    void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        currHp = iniHp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(currHp > 0 && collision.collider.CompareTag("BULLET"))
        {
            currHp -= 20;
            if(currHp <= 0)
            {
                //플레이어 다이 코루틴 호출
                StartCoroutine(PlayerDie());
            }
        }
    }

    IEnumerator PlayerDie()
    {
        cc.enabled = false;
        anim.SetBool(hashRespawn, false);
        anim.SetTrigger(hashDie);

        yield return new WaitForSeconds(3f);

        anim.SetBool(hashRespawn, true);
        //투명처리 함수 호출
        SetPlayerVisible(false);
        yield return new WaitForSeconds(1.5f);

        //리스폰 후에 초기화
        currHp = 100;
        //캐릭터 다시 보이도록 하는 함수 호출
        SetPlayerVisible(true);
        cc.enabled = true;
    }

    void SetPlayerVisible(bool isVisible)
    {
        for(int i = 0; i < renderers.Length; i++)
        {
            //파라메터 값으로 껏다가 켰다가 하기
            renderers[i].enabled = isVisible;
        }
    }
}

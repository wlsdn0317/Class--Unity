using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //����� ����ó������ MesheRenderer
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
                //�÷��̾� ���� �ڷ�ƾ ȣ��
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
        //����ó�� �Լ� ȣ��
        SetPlayerVisible(false);
        yield return new WaitForSeconds(1.5f);

        //������ �Ŀ� �ʱ�ȭ
        currHp = 100;
        //ĳ���� �ٽ� ���̵��� �ϴ� �Լ� ȣ��
        SetPlayerVisible(true);
        cc.enabled = true;
    }

    void SetPlayerVisible(bool isVisible)
    {
        for(int i = 0; i < renderers.Length; i++)
        {
            //�Ķ���� ������ ���ٰ� �״ٰ� �ϱ�
            renderers[i].enabled = isVisible;
        }
    }
}

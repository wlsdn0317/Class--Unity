using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;
   
    private float boomDelay = 0.5f;
    private Animator animator;
    


    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine("MoveToCenter");
    }

   private IEnumerator MoveToCenter()
    {
        Vector3 startPositon = transform.position;
        Vector3 endPosition = Vector3.zero;
        float current = 0;
        float percent = 0;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / boomDelay;

            //boomDelay에 설정된 시간동안 startPosition부터 endPositon까지 이동
            //curve에 설정된 그래프처럼 처음엔 빠르게 이동하고, 목적지에 다다를 수록 천천히 이동
            transform.position = Vector3.Lerp(startPositon, endPosition, curve.Evaluate(percent));

            yield return null;
        }
        //이동이 완료된 후 애니메이션 변경
        animator.SetTrigger("onBoom");

    }
    public void OnBoom()
    {
        //현재 게임 내에서 "Enemy" 태그를 가진 모든 오브젝트 정보를 가져온다.
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] benemys = GameObject.FindGameObjectsWithTag("BEnemy");

        //모든적 파괴
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].GetComponent<Enemy_Scr>().OnDie();
        }
        for (int i = 0; i < benemys.Length; i++)
        {
            benemys[i].GetComponent<BEnemy_Scr>().OnDie();
        }

        Destroy(this.gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;

    private float boomDelay = 0.5f;
    private Animator animator;



    void Awake()
    {
        animator = GetComponent<Animator>();

        StartCoroutine("MoveToCenter");
    }

    private void Update()
    {


    }

    private IEnumerator MoveToCenter()
    {
        Vector3 startPositon = transform.position;
        Vector3 endPosition = Vector3.up;
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / boomDelay;

            //boomDelay�� ������ �ð����� startPosition���� endPositon���� �̵�
            //curve�� ������ �׷���ó�� ó���� ������ �̵��ϰ�, �������� �ٴٸ� ���� õõ�� �̵�
            transform.position = Vector3.Lerp(startPositon, endPosition, curve.Evaluate(percent));

            yield return null;
        }
        //�̵��� �Ϸ�� �� �ִϸ��̼� ����
        animator.SetTrigger("onBoom");

    }
    public void OnBoom()
    {

        //���� ���� ������ "Enemy" �±׸� ���� ��� ������Ʈ ������ �����´�.
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] benemys = GameObject.FindGameObjectsWithTag("BEnemy");
        GameObject[] bullts = GameObject.FindGameObjectsWithTag("Bullet");
        //����� �ı�
        for (int i = 0; i < enemys.Length; ++i)
        {
            enemys[i].GetComponent<Enemy_Scr>().OnDie();

        }
        for (int i = 0; i < benemys.Length; ++i)
        {
            benemys[i].GetComponent<BEnemy_Scr>().OnDie();
            
        }
        for(int i = 0; i < bullts.Length; ++i)
        {
            bullts[i].GetComponent<Enemy_Bullet>().OnDie();
        }


        Destroy(this.gameObject);
    }

}

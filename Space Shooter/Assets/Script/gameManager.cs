using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    float eDelay;//���ʹ� ����������
    float dTimer;//���ʹ� ���� �� ���� �ð�
    public GameObject[] enemyPrefab;
    GameObject targetPos;

    public float score; //������ �����ϴ� ����
    public Text ScoreBoard;//������ ȭ�� �� ǥ�����ִ� �ؽ�Ʈ �ڽ�
    int digit_score = 0;//�Ǽ��� ����Ǵ� ��������
                        //������ ������ �������ֱ� ���� ����

    public Image image100000;
    public Image image10000;
    public Image image1000;
    public Image image100;
    public Image image10;
    public Image image1;

    public GameObject[] meteorbigs;
    float mDelay;
    float mTimer;



    void Start()
    {
        eDelay = 2;
        dTimer = 0;
        targetPos = GameObject.Find("Player");
        score = 0;

        mDelay = 4;
        mTimer = 0;

    }

    void Update()
    {
        if (targetPos != null)
        {
            dTimer += Time.deltaTime;
            mTimer += Time.deltaTime;
            if (dTimer >= eDelay)
            {
                dTimer -= eDelay;
                int r = Random.Range(0, 4);
                float enemySpawnRand = Random.Range(-8, 8);
                Instantiate(enemyPrefab[r], new Vector3(enemySpawnRand, 6, 0), Quaternion.identity);
                //������ x��ǥ ��ġ���� ���ʹ̸� �����Ѵ�.

            }
            if (mTimer >= mDelay)
            {
                mTimer -= mDelay;
                int r = Random.Range(0, 4);
                float meteorSpawnRand = Random.Range(-8, 8);
                Instantiate(meteorbigs[r], new Vector3(meteorSpawnRand, 6, 0), Quaternion.identity);
            }
        }

        score += Time.deltaTime; //�÷��� Ÿ�Ӹ�ŭ ������ �������ش�.
        digit_score = (int)score;

        int n100000 = digit_score / 100000;
        int n10000 = (digit_score % 100000) / 10000;
        int n1000 = (digit_score % 10000) / 1000;         //1000�� �ڸ� ����
        int n100 = (digit_score % 1000) / 100;  //100�� �ڸ� ����
        int n10 = (digit_score % 100) / 10;     //10�� �ڸ� ����
        int n1 = digit_score % 10;              //1�� �ڸ� ����

        string fileName = "UI/numeral";
        image100000.sprite = Resources.Load<Sprite>(fileName + n100000);
        image10000.sprite = Resources.Load<Sprite>(fileName + n10000);
        image1000.sprite = Resources.Load<Sprite>(fileName + n1000);
        image100.sprite = Resources.Load<Sprite>(fileName + n100);
        image10.sprite = Resources.Load<Sprite>(fileName + n10);
        image1.sprite = Resources.Load<Sprite>(fileName + n1);

    }
}

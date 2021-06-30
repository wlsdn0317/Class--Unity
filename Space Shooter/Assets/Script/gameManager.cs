using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    float eDelay;//에너미 생성딜레이
    float dTimer;//에너미 생성 후 지난 시간
    public GameObject[] enemyPrefab;
    GameObject targetPos;

    public float score; //점수를 저장하는 변수
    public Text ScoreBoard;//점수를 화면 에 표시해주는 텍스트 박스
    int digit_score = 0;//실수로 저장되는 점수값을
                        //정수로 별도로 저장해주기 위한 변수

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
                //랜덤한 x좌표 위치에서 에너미를 생성한다.

            }
            if (mTimer >= mDelay)
            {
                mTimer -= mDelay;
                int r = Random.Range(0, 4);
                float meteorSpawnRand = Random.Range(-8, 8);
                Instantiate(meteorbigs[r], new Vector3(meteorSpawnRand, 6, 0), Quaternion.identity);
            }
        }

        score += Time.deltaTime; //플레이 타임만큼 점수를 가산해준다.
        digit_score = (int)score;

        int n100000 = digit_score / 100000;
        int n10000 = (digit_score % 100000) / 10000;
        int n1000 = (digit_score % 10000) / 1000;         //1000의 자리 숫자
        int n100 = (digit_score % 1000) / 100;  //100의 자리 숫자
        int n10 = (digit_score % 100) / 10;     //10의 자리 숫자
        int n1 = digit_score % 10;              //1의 자리 숫자

        string fileName = "UI/numeral";
        image100000.sprite = Resources.Load<Sprite>(fileName + n100000);
        image10000.sprite = Resources.Load<Sprite>(fileName + n10000);
        image1000.sprite = Resources.Load<Sprite>(fileName + n1000);
        image100.sprite = Resources.Load<Sprite>(fileName + n100);
        image10.sprite = Resources.Load<Sprite>(fileName + n10);
        image1.sprite = Resources.Load<Sprite>(fileName + n1);

    }
}

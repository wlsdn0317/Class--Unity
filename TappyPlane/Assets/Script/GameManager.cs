using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject gameOverImage;
    //게임오버댓을때 화면에 보여줄 게임 오버 이미지
    bool isGameOver;
    //게임오버 유무를 알려주는 함수
    
    public float score;
    //점수를 저장하는 변수
    public Text ScoreBoard;
    //점수를 화면 에 표시해주는 텍스트 박스

    int digit_score = 0;//실수로 저장되는 점수값을
                        //정수로 별도로 저장해주기 위한 변수

    public Image image1000;
    public Image image100;
    public Image image10;
    public Image image1;

    void Start()
    {
        
        isGameOver = false;
        score = 0;

    }

   public void gameOverFunc()
    {

        //게임오버됬을때 실행시켜줄 함수
        Time.timeScale = 0;
        //Time.timeScale : 게임상에서 흐르는 시간의 배율을 조절하는 함수
        //1보다 크게 주면 게임상의 시간이 빠르게 흐르며
        //1보다 작게 주면 게임상의 시잔이 느리게 흐른다.

        gameOverImage.SetActive(true);
        isGameOver = true;

    }

    void Update()
    {
        if (isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                //타임스케일은 게임 프로그램 전체에 적용되기 때문에
                //다른 씬으로 전환하더라도 계속 유지가 된다.
                //따라서 게임이 재시작된다면
                //타임스케ㅐ일을 다시 원래대로 바꿔줘야 한다.

                //타임스케일은 시간의 흐름을 멈추는거지
                //게임 전체를 멈추는게 아니다.
                //시간과 관계없는 코드들은
                //(업데이트문에서 deltaTime이 곱해지지 않은 수치들)
                //정상적으로 동작 한다.
                SceneManager.LoadScene("GameScene");
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        score += Time.deltaTime;
        //플레이타임만큼 점수를 가산해준다.
        ScoreBoard.text = "Score:" + (int)score;
        //점수값을 int형으로 바꿔서 점수판에 표시시킨다.

        
        digit_score = (int)score;

        int n1000 = digit_score / 1000;         //1000의 자리 숫자
        int n100 = (digit_score % 1000) / 100;  //100의 자리 숫자
        int n10 = (digit_score % 100) / 10;     //10의 자리 숫자
        int n1 = digit_score % 10;              //1의 자리 숫자

        string fileName = "Tappy Plane/PNG/Numbers/number";
        image1000.sprite = Resources.Load<Sprite>(fileName+n1000);
        image100.sprite = Resources.Load<Sprite>(fileName+n100);
        image10.sprite = Resources.Load<Sprite>(fileName+n10);
        image1.sprite = Resources.Load<Sprite>(fileName+n1);
        //파일명이 규칙성을 가지고 있다는 점을 이용하여
        //불러올 파일명을 직접 조합해서(만들어서) 불러오고 있다.

        RectTransform rect = (RectTransform)image1000.transform;
        rect.sizeDelta = new Vector2(50, 60);
        rect = (RectTransform)image100.transform;
        rect.sizeDelta = new Vector2(50, 60);
        rect = (RectTransform)image10.transform;
        rect.sizeDelta = new Vector2(50, 60);
        rect = (RectTransform)image1.transform;
        rect.sizeDelta = new Vector2(50, 60);

        //SetNativeSize(); 이미지파일의 원본크기에 맞게
        //게임오브젝트의 크기를 변경시켜주는 함수
        //(에디터의 버튼과 동일한 기능)

        int i = 50;
        string str = "image" + i;
        //숫자를 4자리로 표현하고자 하는 경우;
        //== image0050

        str = string.Format("image{0:D4}",i);
        //c언어의 printf처럼 서식문자를 이용하여
        //문자열을 만들 수 있다.
        //D자릿수는 정수를 표현할 때
        //빈자릿수를 0으로 채워서 자릿수를 맞춰준다.
        Debug.Log(str);

        str = string.Format("score{0:f2}",score);
        Debug.Log(str);
        //실수의 자릿수를 제한할때는
        //F자릿수를 적어주면 된다.


    }
}

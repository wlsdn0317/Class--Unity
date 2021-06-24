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
   

    void Start()
    {
        
        isGameOver = false;
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
    }
}

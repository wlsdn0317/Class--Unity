using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//유니티 게임씬을 관리해주는 클래스
using UnityEngine.UI;
//유니티 내에서 UI관련 스크립트를 사용할 수 있도록 해주는 클래스


public class GameManager : MonoBehaviour
{
    //닷지에서 게임매니저의 역할
    //게임오버 유무를 표현(GameOverText를 화면에 노출할지 말지 관리)
    //점수를 계산(플레이어의 생존시간을 카운트)
    //UI를 갱신(증가하는 점수를 ui로 실제로 볼 수 있도록 내용물 갱신)
    //게임오버시에 게임을 처음부터 다시 시작

    public GameObject gameOverText; //껏다켰다 해줄 게임오버 텍스트
    float scoreTime;//플레이어의 점수값을 저장하는 변수
    public Text TimeText; //갱신해줄 점수판
    bool isOver; //게임오버 유무를 나타내는 변수
    public Text HpText;//플레이어의 체력을 표시해줄 text
    public GameObject player;
    //게임씬에 존재하는 플레이어를 해당 변수에 저장한다.
  

    void Start()
    {
        scoreTime = 0;
        isOver = false;
        



    }
    public void gameOver()
    {
        //게임오버 텍스트가 화면에 나와야 한다.
        //isOver를 true로 바꿔줘야 한다.

        gameOverText.SetActive(true);
        isOver = true;

        if (scoreTime > PlayerPrefs.GetFloat("highScore"))
        {
            //저장된 데이터를 가져올때는 Get-함수를 사용하며
            //가져올 데이터의 key값(이름)만 적어주면 된다.

            PlayerPrefs.SetFloat("highScore", scoreTime);
            //PlayerPrefs : 유니티가 실행되는 동안
            //발생한 데이터 일부를 영구적으로 저장해주는 클래스
            //SetFloat, SetlInt,SetString를 통해
            //지정된 자료형의 데이터를 저장할 수 있다.
            //데이터를 저장할때는 저장된 데이터를 구분할 수 있도록
            //key값(이름)을 함께 작성해야한다.
            //PlayerPrefs,SetFloat("데이터 이름",실제 저장할 데이터)

            PlayerPrefs.Save();
            //Set - 함수는 데이터를 '작성'만 하고
            //저장을 별도로 해줘야 정상적으로 데이터가
            //디바이스에 저장이 된다.
        }

        gameOverText.GetComponent<Text>().text = "Press R to Restart\nBest Time:" + (int)PlayerPrefs.GetFloat("highScore");


    }


    void Update()
    {
        if (isOver == false)
        {//게임오버가 되지 않았을때만
            scoreTime += Time.deltaTime;
            //점수를 증가시킨다.
            TimeText.text = "점수:" + (int)scoreTime;
            //텍스트 컴포넌트의 화면에 표시되는 글자 내용은
            //텍스트 컴포넌트의 text변수에 따라 바뀌기 때문에
            //표기되는 점수를 변경해주려면
            //TimeText.text 값을 변경해주면 된다.


            //scoreTime변수가 int가 아닌 이유
            //scoreTime은 플레이한 시간을 저장하는 변수이고
            //시간값은 정수가 아닌 실수 단위로 흐르기 때문에
            //만약, scoreTime이 int형이면
            //update에서는 scoreTime에 소수점 이하를 계속 더하게 되고
            //scoreTime은 ing형이기 때문에 소수점을 더해봤자
            //값이 증가하지 않고 날아가게 된다.

            
            



        }
        else
        {
            //게임오버가 되었을 경우

            if (Input.GetKeyDown(KeyCode.R))
            {
                //키보드 R키를 누르면
                //게임이 처음부터 재시장되도록 한다.

                SceneManager.LoadScene("SampleScene");
                //지정한 게임씬을 불러오는 함수
                //동일한 씬을 부르면 해당 씬이 재시작 된다.

                //씬을 로드하게 되면 화면이 눈에 띄게 어두워질건데
                //이는 게임씬에 광원(lighting)과 관련된 설정이
                //별도로 되어있지 않기 때문에
                //따라서 광원 설정을 따로 해주면 문제가 해결된다.

                //우측 하단의 전구모양 아이콘 클릭
                //->Lighting Setting에서 New Lighting Settings를 클릭하여
                //  새로운 광원 설정을 생성하고
                //->하단의 Auto Generate를 활성화하여
                //  씬이 자동으로 광원을 생성하도록 설정한다

            }

            else if (Input.GetKeyDown(KeyCode.X))
            {
                Application.Quit();
                //프로그램을 종료시키는 함수
                //유니티 에디터에서는 에디터를 종료시킬수 없기 때문에
                //정상적으로 동작하지 않는 코드.
                //게임을 빌드해서 독립 프로그램으로 생성해줘야
                //실행되는 코드이다.
            }

        }

        //플레이어 체력 출력
        PlayerController pc = player.GetComponent<PlayerController>();
        //player는 플레이어 게임 오브젝트이기 때문에
        //체력값을 가지고 있는 컴포넌트인 PlayerController를
        //Player 게임오브젝트로부터 가져와야 한다.

        HpText.text = "HP:" + pc.hp;

    }
}

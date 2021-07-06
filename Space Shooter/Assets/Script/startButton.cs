using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void pressedStartButton()
    {
        SceneManager.LoadScene(0);
        //로드씬 함수는 씬의 이름을 지정해서 불러올 수도 있지만
        //빌드세팅의 씬의 번호를 지정해서 불러올 수 도 있다.
    }


}

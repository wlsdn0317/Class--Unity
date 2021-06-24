using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject gameOverImage;
    //���ӿ��������� ȭ�鿡 ������ ���� ���� �̹���
    bool isGameOver;
    //���ӿ��� ������ �˷��ִ� �Լ�
   

    void Start()
    {
        
        isGameOver = false;
    }

   public void gameOverFunc()
    {

        //���ӿ��������� ��������� �Լ�
        Time.timeScale = 0;
        //Time.timeScale : ���ӻ󿡼� �帣�� �ð��� ������ �����ϴ� �Լ�
        //1���� ũ�� �ָ� ���ӻ��� �ð��� ������ �帣��
        //1���� �۰� �ָ� ���ӻ��� ������ ������ �帥��.

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
                //Ÿ�ӽ������� ���� ���α׷� ��ü�� ����Ǳ� ������
                //�ٸ� ������ ��ȯ�ϴ��� ��� ������ �ȴ�.
                //���� ������ ����۵ȴٸ�
                //Ÿ�ӽ��ɤ����� �ٽ� ������� �ٲ���� �Ѵ�.

                //Ÿ�ӽ������� �ð��� �帧�� ���ߴ°���
                //���� ��ü�� ���ߴ°� �ƴϴ�.
                //�ð��� ������� �ڵ����
                //(������Ʈ������ deltaTime�� �������� ���� ��ġ��)
                //���������� ���� �Ѵ�.
                SceneManager.LoadScene("GameScene");
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}

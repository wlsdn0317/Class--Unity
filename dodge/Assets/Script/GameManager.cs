using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//����Ƽ ���Ӿ��� �������ִ� Ŭ����
using UnityEngine.UI;
//����Ƽ ������ UI���� ��ũ��Ʈ�� ����� �� �ֵ��� ���ִ� Ŭ����


public class GameManager : MonoBehaviour
{
    //�������� ���ӸŴ����� ����
    //���ӿ��� ������ ǥ��(GameOverText�� ȭ�鿡 �������� ���� ����)
    //������ ���(�÷��̾��� �����ð��� ī��Ʈ)
    //UI�� ����(�����ϴ� ������ ui�� ������ �� �� �ֵ��� ���빰 ����)
    //���ӿ����ÿ� ������ ó������ �ٽ� ����

    public GameObject gameOverText; //�����״� ���� ���ӿ��� �ؽ�Ʈ
    float scoreTime;//�÷��̾��� �������� �����ϴ� ����
    public Text TimeText; //�������� ������
    bool isOver; //���ӿ��� ������ ��Ÿ���� ����
    public Text HpText;//�÷��̾��� ü���� ǥ������ text
    public GameObject player;
    //���Ӿ��� �����ϴ� �÷��̾ �ش� ������ �����Ѵ�.
  

    void Start()
    {
        scoreTime = 0;
        isOver = false;
        



    }
    public void gameOver()
    {
        //���ӿ��� �ؽ�Ʈ�� ȭ�鿡 ���;� �Ѵ�.
        //isOver�� true�� �ٲ���� �Ѵ�.

        gameOverText.SetActive(true);
        isOver = true;

        if (scoreTime > PlayerPrefs.GetFloat("highScore"))
        {
            //����� �����͸� �����ö��� Get-�Լ��� ����ϸ�
            //������ �������� key��(�̸�)�� �����ָ� �ȴ�.

            PlayerPrefs.SetFloat("highScore", scoreTime);
            //PlayerPrefs : ����Ƽ�� ����Ǵ� ����
            //�߻��� ������ �Ϻθ� ���������� �������ִ� Ŭ����
            //SetFloat, SetlInt,SetString�� ����
            //������ �ڷ����� �����͸� ������ �� �ִ�.
            //�����͸� �����Ҷ��� ����� �����͸� ������ �� �ֵ���
            //key��(�̸�)�� �Բ� �ۼ��ؾ��Ѵ�.
            //PlayerPrefs,SetFloat("������ �̸�",���� ������ ������)

            PlayerPrefs.Save();
            //Set - �Լ��� �����͸� '�ۼ�'�� �ϰ�
            //������ ������ ����� ���������� �����Ͱ�
            //����̽��� ������ �ȴ�.
        }

        gameOverText.GetComponent<Text>().text = "Press R to Restart\nBest Time:" + (int)PlayerPrefs.GetFloat("highScore");


    }


    void Update()
    {
        if (isOver == false)
        {//���ӿ����� ���� �ʾ�������
            scoreTime += Time.deltaTime;
            //������ ������Ų��.
            TimeText.text = "����:" + (int)scoreTime;
            //�ؽ�Ʈ ������Ʈ�� ȭ�鿡 ǥ�õǴ� ���� ������
            //�ؽ�Ʈ ������Ʈ�� text������ ���� �ٲ�� ������
            //ǥ��Ǵ� ������ �������ַ���
            //TimeText.text ���� �������ָ� �ȴ�.


            //scoreTime������ int�� �ƴ� ����
            //scoreTime�� �÷����� �ð��� �����ϴ� �����̰�
            //�ð����� ������ �ƴ� �Ǽ� ������ �帣�� ������
            //����, scoreTime�� int���̸�
            //update������ scoreTime�� �Ҽ��� ���ϸ� ��� ���ϰ� �ǰ�
            //scoreTime�� ing���̱� ������ �Ҽ����� ���غ���
            //���� �������� �ʰ� ���ư��� �ȴ�.

            
            



        }
        else
        {
            //���ӿ����� �Ǿ��� ���

            if (Input.GetKeyDown(KeyCode.R))
            {
                //Ű���� RŰ�� ������
                //������ ó������ �����ǵ��� �Ѵ�.

                SceneManager.LoadScene("SampleScene");
                //������ ���Ӿ��� �ҷ����� �Լ�
                //������ ���� �θ��� �ش� ���� ����� �ȴ�.

                //���� �ε��ϰ� �Ǹ� ȭ���� ���� ��� ��ο����ǵ�
                //�̴� ���Ӿ��� ����(lighting)�� ���õ� ������
                //������ �Ǿ����� �ʱ� ������
                //���� ���� ������ ���� ���ָ� ������ �ذ�ȴ�.

                //���� �ϴ��� ������� ������ Ŭ��
                //->Lighting Setting���� New Lighting Settings�� Ŭ���Ͽ�
                //  ���ο� ���� ������ �����ϰ�
                //->�ϴ��� Auto Generate�� Ȱ��ȭ�Ͽ�
                //  ���� �ڵ����� ������ �����ϵ��� �����Ѵ�

            }

            else if (Input.GetKeyDown(KeyCode.X))
            {
                Application.Quit();
                //���α׷��� �����Ű�� �Լ�
                //����Ƽ �����Ϳ����� �����͸� �����ų�� ���� ������
                //���������� �������� �ʴ� �ڵ�.
                //������ �����ؼ� ���� ���α׷����� ���������
                //����Ǵ� �ڵ��̴�.
            }

        }

        //�÷��̾� ü�� ���
        PlayerController pc = player.GetComponent<PlayerController>();
        //player�� �÷��̾� ���� ������Ʈ�̱� ������
        //ü�°��� ������ �ִ� ������Ʈ�� PlayerController��
        //Player ���ӿ�����Ʈ�κ��� �����;� �Ѵ�.

        HpText.text = "HP:" + pc.hp;

    }
}

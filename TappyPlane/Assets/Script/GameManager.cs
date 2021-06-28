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
    
    public float score;
    //������ �����ϴ� ����
    public Text ScoreBoard;
    //������ ȭ�� �� ǥ�����ִ� �ؽ�Ʈ �ڽ�

    int digit_score = 0;//�Ǽ��� ����Ǵ� ��������
                        //������ ������ �������ֱ� ���� ����

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

        score += Time.deltaTime;
        //�÷���Ÿ�Ӹ�ŭ ������ �������ش�.
        ScoreBoard.text = "Score:" + (int)score;
        //�������� int������ �ٲ㼭 �����ǿ� ǥ�ý�Ų��.

        
        digit_score = (int)score;

        int n1000 = digit_score / 1000;         //1000�� �ڸ� ����
        int n100 = (digit_score % 1000) / 100;  //100�� �ڸ� ����
        int n10 = (digit_score % 100) / 10;     //10�� �ڸ� ����
        int n1 = digit_score % 10;              //1�� �ڸ� ����

        string fileName = "Tappy Plane/PNG/Numbers/number";
        image1000.sprite = Resources.Load<Sprite>(fileName+n1000);
        image100.sprite = Resources.Load<Sprite>(fileName+n100);
        image10.sprite = Resources.Load<Sprite>(fileName+n10);
        image1.sprite = Resources.Load<Sprite>(fileName+n1);
        //���ϸ��� ��Ģ���� ������ �ִٴ� ���� �̿��Ͽ�
        //�ҷ��� ���ϸ��� ���� �����ؼ�(����) �ҷ����� �ִ�.

        RectTransform rect = (RectTransform)image1000.transform;
        rect.sizeDelta = new Vector2(50, 60);
        rect = (RectTransform)image100.transform;
        rect.sizeDelta = new Vector2(50, 60);
        rect = (RectTransform)image10.transform;
        rect.sizeDelta = new Vector2(50, 60);
        rect = (RectTransform)image1.transform;
        rect.sizeDelta = new Vector2(50, 60);

        //SetNativeSize(); �̹��������� ����ũ�⿡ �°�
        //���ӿ�����Ʈ�� ũ�⸦ ��������ִ� �Լ�
        //(�������� ��ư�� ������ ���)

        int i = 50;
        string str = "image" + i;
        //���ڸ� 4�ڸ��� ǥ���ϰ��� �ϴ� ���;
        //== image0050

        str = string.Format("image{0:D4}",i);
        //c����� printfó�� ���Ĺ��ڸ� �̿��Ͽ�
        //���ڿ��� ���� �� �ִ�.
        //D�ڸ����� ������ ǥ���� ��
        //���ڸ����� 0���� ä���� �ڸ����� �����ش�.
        Debug.Log(str);

        str = string.Format("score{0:f2}",score);
        Debug.Log(str);
        //�Ǽ��� �ڸ����� �����Ҷ���
        //F�ڸ����� �����ָ� �ȴ�.


    }
}

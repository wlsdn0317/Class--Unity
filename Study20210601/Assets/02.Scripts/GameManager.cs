using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("�� ���� ����")]
    public Transform[] points;
    public GameObject enemy;

    public float createTime = 2f; //���� �ֱ�
    public int maxEnemy = 10; //�ִ� ���� ����
    public bool isGameOver = false;

    //static ������ ���������� ������ �� �ֵ��� ����
    //�ٸ� ��ũ��Ʈ���� instance��� ������ �̿��ؼ� ���� ���ٰ���
    public static GameManager instance = null;
    //�ٸ� �ߺ��Ǿ� �������� �ʵ���(���� ������ �����ؾ���)
    //�Ʒ� �ڵ带 ���Ͽ� ���� ���־����

    [Header("������Ʈ Ǯ ����")]
    public GameObject bulletPrefab;
    public int maxPool = 10;
    //List�� �Ϲ����� �迭�� �޸� ���� ���빰�� ���� ���̰� ����
    public List<GameObject> bulletPool = new List<GameObject>();

    bool isPaused;

    public CanvasGroup inventoryCG;

    [Header("������ ����")]
    public Text killCountTxt;
    public int killCount;
    void LoadGameData()
    {
        //PlayerPrefs�� set/ get ����� ����
        // Ű/�� <<<������ �����͸� �����ϰ� �������
        //Ű�� ����ڰ� ��������, �� ��° �Ķ���ͷ� ������ ������
        //�ݴ�� �����͸� ������ �� ������ Ű�� �����͸� ������ ��
        killCount = PlayerPrefs.GetInt("KILL_COUNT", 0);
        killCountTxt.text = "KILL " + killCount.ToString("0000");
    }
    public void OnInventoryOpen(bool isOpened)
    {
        //isOpened ���� ���� ��� 1�ƴϸ� 0 ���� ������
        inventoryCG.alpha = (isOpened) ? 1f : 0f;
        //interactable ��ȣ�ۿ� - �����ΰ�
        //blocksRaycasts - ���°�
        inventoryCG.interactable = isOpened;
        inventoryCG.blocksRaycasts = isOpened;
    }
    public void OnPauseClick()
    {
        //bool ���� ������ �� �Ʒ��� ���� ��뵵 ����
        isPaused = !isPaused;

        //���� ������ >> ���ǽ� ? �� : ����
        //timeScale�� 1�� ���� 1���� ������ �������ٰ� 0�̵Ǹ� �Ͻ�����
        //1���� Ŀ���� ��� ��������� 4��� �̻� �������
        Time.timeScale = (isPaused) ? 0f : 1f;

        var PlayerObj = GameObject.FindGameObjectWithTag("PLAYER");
        //MonoBehaviour�� ���� ������ �÷��̾ �߰���
        //��� ��ũ��Ʈ�� �������� ���ؼ�
        var scripts = PlayerObj.GetComponents<MonoBehaviour>();
        foreach(var script in scripts)
        {
            //��ũ��Ʈ ���δ� ��Ȱ��ȭ �Ǵ� Ȱ��ȭ �ϵ���
            script.enabled = !isPaused;
        }

        var canvasGroup = GameObject.Find("Panel-Weapon").GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = !isPaused;
    }


    private void Awake()
    {
        //�̱����� ���� ���� ���� ���
        if(instance == null)
        {
            instance = this;//�̱��� �������� �������
        }
        //instance�� �Ҵ�� Ŭ������ �ν��Ͻ��� �ٸ����
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        //���� ����Ǵ��� �������� �ʰ� ������
        DontDestroyOnLoad(this.gameObject);

        LoadGameData(); //���� ������ �� ����� ���ھ� �ҷ�����

        //������Ʈ Ǯ ����
        CreatePooling();
    }

    public void IncKillCount()
    {
        killCount++;
        killCountTxt.text = "KILL " + killCount.ToString("0000");
        PlayerPrefs.SetInt("KILL_COUNT", killCount);
    }

    void Start()
    {
        points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            //���� �ڷ�ƾ �Լ� ȣ��
            StartCoroutine(CreateEnemy());
        }
    }

    IEnumerator CreateEnemy()
    {
        //���� ���� ������ ��� �����
        while (!isGameOver)
        {
            //�±׸� Ȱ���Ͽ� Enemy�� ���� �ľ�
            int enemyCount = (int)GameObject.FindGameObjectsWithTag("ENEMY").Length;
            
            //Enemy�� �ִ���� �������� ���� ���� ������
            if(enemyCount < maxEnemy)
            {
                //�� ���� �ֱ� �ð���ŭ ���
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);
                Instantiate(enemy, points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }
    }

    //������Ʈ Ǯ �߿��� ��� ������ �Ѿ� ��������
    public GameObject GetBullet()
    {
        for(int i = 0; i < bulletPool.Count; i++)
        {
            //�Ѿ��� ��Ȱ��ȭ �Ǿ��ִٸ� = ������̶��
            if(bulletPool[i].activeSelf == false)
            {
                return bulletPool[i];
            }
        }
        return null;
    }
    
    //������Ʈ Ǯ ���� �Լ�
    public void CreatePooling()
    {
        //���̾��Ű���� Create Empty�ϴ°Ͱ� ����
        //�� ������Ʈ�� ������ �� �̸��� ObjectPools�� ����
        //������ �Ѿ�(10��)�� �ڽ����� �����ϱ� ���Ͽ� �ڵ�� ����
        GameObject objectPools = new GameObject("ObjectPools");

        //������Ʈ Ǯ ä���
        for(int i = 0; i < maxPool; i++)
        {
            //���� ������ ���ÿ� ������ ������  ObjectPools�� �ڽ����� ����
            var obj = Instantiate<GameObject>(bulletPrefab, objectPools.transform);
            //Bullet_00, Bullet_01.....BUlet_09....10
            obj.name = "Bullet_" + i.ToString("00");
            obj.SetActive(false);//�߻� ���̹Ƿ� ��Ȱ��ȭ
            //����Ʈ�� ������ �Ѿ� �ֱ�
            bulletPool.Add(obj);
        }
    }

    void Update()
    {
        
    }
}

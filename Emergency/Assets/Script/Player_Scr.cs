using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Scr : MonoBehaviour
{
    [SerializeField]
    private string       nextSceneName;
    [SerializeField]
    private StageData    stageData;
    [SerializeField]
    private KeyCode      keycodeAttack = KeyCode.Space;
    [SerializeField]
    private KeyCode keycodeBoom = KeyCode.Z;
    private Weapon       weapon;

    private int          score;
    public int           Score
    {
        //score ���� ������ ���� �ʵ���
        set => score = Mathf.Max(0, value);
        get => score;
    }

    bool hitaable;       //�÷��̾ ������ �� �ִ� ��������
    
    public int moveSpeed = 3;

    void Start()
    {
        hitaable = true;
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal");//�������
        moveDir.y = Input.GetAxis("Vertical");//��������
        this.transform.position += moveDir * Time.deltaTime * moveSpeed;

        //���� ���� ����
        if (Input.GetKeyDown(keycodeAttack))
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(keycodeAttack))
        {
            weapon.StopFiring();
        }

        if (Input.GetKeyDown(keycodeBoom))
        {
            weapon.StartBoom();
        }
    
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                        Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
            }

    public void call_Hit()
    {
        StartCoroutine(isHit());
    }


    IEnumerator isHit()
    {
        if(hitaable == true)
        {
            
            hitaable = false;

            for(int i = 0; i < 30; i++)
            {
                if(i%2 == 0)
                {
                    this.GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().enabled = true;
                }
                yield return new WaitForSeconds(0.1f);
            }
            hitaable = true;
        }
        else
        {
            yield return null;
        }


    }

    public void OnDie()
    {
        //����̽��� ȹ���� ���� score ����
        PlayerPrefs.SetInt("Score", score);
        //�÷��̾ ��� �� nextSceneName ������ �̵�
        SceneManager.LoadScene(nextSceneName);
    }
}

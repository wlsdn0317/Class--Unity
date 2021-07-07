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
        //score 값이 음수가 되지 않도록
        set => score = Mathf.Max(0, value);
        get => score;
    }

    bool hitaable;       //플레이어를 공격할 수 있는 상태인지
    
    public int moveSpeed = 3;

    void Start()
    {
        hitaable = true;
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal");//수평방향
        moveDir.y = Input.GetAxis("Vertical");//수직방향
        this.transform.position += moveDir * Time.deltaTime * moveSpeed;

        //공격 시작 종료
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
        //디바이스에 획득한 점수 score 저장
        PlayerPrefs.SetInt("Score", score);
        //플레이어가 사망 시 nextSceneName 씬으로 이동
        SceneManager.LoadScene(nextSceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject Laser; //�÷��̾ �߻��� �̻���;

    float delay=1;//�Ѿ��� �������� �߻�Ǵ� �ֱ�
    float pressTime;//�߻�Ű�� ������ �ִ� �ð�

    public Camera mainCam;

    public int hp = 3;//�÷��̾� ü��
    public GameObject damageimg;//���� �Ծ����� ���̴� �̹���

    public int Life = 3;

    public Image lifeImg;//life �̹���
    
    void Start()
    {
        Laser = Resources.Load<GameObject>("Prefabs/myLaser");
        //��ũ��Ʈ�� ���ؼ� ������ �������� �������� �����Դ�.
        
        pressTime = delay;
        //�������� ù���� �Է°� ���ÿ� �߻�ǵ���
        //�ʱⰪ�� �����̿� �������� �ش�.
    }
        
    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal");//�������
        moveDir.y = Input.GetAxis("Vertical");//��������
        this.transform.position += moveDir * Time.deltaTime*3;

        if (Input.GetKey(KeyCode.Space))
        {
            pressTime += Time.deltaTime;
            if (pressTime >= delay)
            {
                pressTime -= delay;
                //�����̽��ٸ� ������ delay�ʸ��� �Ѿ��� �߻��.
                Instantiate(Laser, this.transform.position, Quaternion.identity);
                //�÷��̾� ��ġ���� �������� �߻�
                
            }
        }   

        if (Input.GetKeyUp(KeyCode.Space))
        {
            pressTime = delay;
            //Ű���带 ���� ���� �����̸� �ʱ�ȭ�ؼ�
            //��� �Ѿ��� �߻�Ǵ� ���·� �ٲ��ش�.
            //�̷����ϸ� Ű���带 ������ ���ȿ���
            //�����̿� �°� �Ѿ��� �ֱ������� �߻�ǰ�
            //Ű���带 ��Ÿ�ϰ� �Ǹ� �����̿� �������
            //�Ѿ��� �����ؼ� �߻�ǰ� �ȴ�. 
        }



        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            //ȭ����� ���콺 ��ǥ�� ��������
            mousePos = mainCam.ScreenToWorldPoint(mousePos);
            //ȭ����� ��ǥ�� ī�޶� �������� �� ���� ��ǥ�� ��ȯ.
            RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, 100);
            //�����ɽ�Ʈ : Ư�� ��ǥ���� ������(Ray)�� ��Ƽ�
            //�ش� �������� �ε��� ����� ������ ������ �� �ֵ��� ����� 
            //�ε��� ����� hit�� ��ȯ�Ǹ�, ����� ���ٸ� hit�� null�� �ȴ�.


            if (hit)
            {
                GameObject obj = Instantiate(Laser, this.transform.position, Quaternion.identity);
                Vector3 v = hit.point;
                //�浹��ġ�� 2d��ǥ�̱� ������
                //3d��ǥ�� Vector3�� �����ؼ� ����Ѵ�.


                Vector3 dir = v - this.transform.position;
                dir.z = 0;
                dir = dir.normalized;
                //���Ⱚ�� ���ϰ�, �������ͷ� ���� ��
                obj.transform.up = dir;
                //�������� ���� �̵����Ⱚ��  �ش� ������ �����Ѵ�.


            }
        }

    }

    public void damaged()
    {
        hp--;
        if(damageimg.activeSelf == false)
        {
            //���� �̹����� ����������
            damageimg.SetActive(true);
            //�̹����� ����
        }
        if (hp < 0)
        {
            die();
        }

        damageimg.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>("Damage/playerShip1_damage" + (3 - hp));

    }

    public void die(){
        Life--;
        if (Life >= 0)
        {
            hp = 3;
        }
        else if (Life < 0)
        {
            Destroy(this.gameObject);
            return;//�ڱ��ڽ��� �����ߴٸ�
            //�ڵ尡 ����ǵ��� �������ش�.
        }
        lifeImg.sprite = Resources.Load<Sprite>("UI/numeral" + Life);
    }

}

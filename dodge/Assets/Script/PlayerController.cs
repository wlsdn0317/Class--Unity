using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody; //�̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f; //�̵��ӷ�
    //������ �տ� public�� ������
    //����Ƽ �����Ϳ��� �ش� ������ ���� ������ Ȯ���ϰ�
    //������ �� �ְ� �ȴ�.
    //��, ���ȿ� �־�� ����� ���� ������
    //[SerializeField]��� ��ɾ ���ؼ�
    //�����Ϳ����� �������� ������ ������ private����
    //������ ���� �� �ִ�.
    void Start()
    {
        //Ŭ������ �����ڿ� ������ ������ �ϴ� �Լ�
        //�ش� ��ũ��Ʈ�� ������Ʈ�ν� ������ �ִ�
        //���ӿ�����Ʈ�� ����ȭ�鿡 �����Ǹ�
        //�ڵ����� ����Ǵ� �Լ�

        playerRigidbody = this.GetComponent<Rigidbody>();
        //this(�÷��̾�)�� ���� ������Ʈ�� �����´� (GetComponent)
        //� ������Ʈ�ĸ� <Rigidbody>�̴�.
        //������ Rigidbody ������Ʈ�� ��ȯ�޾�
        //playerRigidbody�� �����Ѵ�.

        //�����Ϳ��� ������ �����ϴ� �Ͱ�
        //��ũ��Ʈ���� ������ �������� ���� �� ����� ���̰� ������
        //���������δ� �����Ϳ��� �������� ����
        //�ش� ����� ó������ �����Ҷ��� ������ �� �ְ�
        //��ũ��Ʈ�� �����ö��� ����� ���߿� �����Ǵ���
        //�����ü� �ִ�.
    }


    void Update()
    {
        //������Ʈ �Լ��� ������ ����Ǵ� ����
        //1�����Ӹ��� �ڵ����� ȣ��Ǵ� �Լ�.
        //�׷��� ������ �÷����ϸ鼭 �ǽð�����
        //���������� �����ؾ��ϴ� �ڵ���� �̰��� �ۼ��Ѵ�.
        //ex)Ű����,���콺 ����
        bool b = true;
        //C++���� �߰��� ������
        //��, ������ ǥ���ϴ� ����
        //�� :true
        //���� : false
        moveAxis();
       

    }


    //��ü�� ���� ���ؼ� �����̴� ���
    void moveForce()
    {
        if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.UpArrow))
        {
            //�������� Ű���忡 �ߺ������ǰ� �Ϸ���
            //or �����ڸ� ���� ������ �����ָ�ȴ�.

            playerRigidbody.AddForce(Vector3.forward * speed * Time.deltaTime);
            //AddForce; ������ٵ�(��ü)����
            //���� ���ؼ� ��������� ��ü��
            //�̵��ϵ���(�����̵���)������ִ� �Լ�
            //�Ű������� ���� ���� ������ �Է¹�����
            //������ x,y,z�� ������ ��� �����ؾ� �ϱ� ������
            //Vector3��� Ŭ�������� ����Ѵ�.
            //forward��(0,0,1)������ ��Ÿ����.
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            playerRigidbody.AddForce(Vector3.back * speed * Time.deltaTime);
        }
        //����,�¿�� ���� �ߺ��ؼ� ���� ������ �ʱ� ������
        //���ϸ� if-else if��, �¿츦 if-else if�� �����ش�.
        //�밢�� �̵��� ���ؼ� ����Ű�� �ϳ��� �¿�Ű�� �ϳ���
        //������ �ֱ⶧���� ��ü�� else if�� ���� �ʿ�� ����.
        if (Input.GetKey(KeyCode.A) == true)
        {
            playerRigidbody.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) == true)
        {
            playerRigidbody.AddForce(Vector3.right * speed * Time.deltaTime);
        }
        //Input.GetKeyDown:Ű���带 ������ ������ �ν�
        //Input.GetKeyUP:������ Ű���带 ���� ������ �ν�
        //Input.GetKey:Ű���带 ������ �ִ� ���� ��� �ν�

        //AddForce �Լ��� ��ü�� ���� ���� ����ν�
        //������Ʈ�� �����̰� �ϴ� �Լ��̱� ������
        //�ﰢ���� �������� �ǵ���� �������� �ʴ´�.
        //���� ���� �̻��� ���� ��� ������Ʈ�� �����̸�
        //�ӵ� ���� ������ �����ϸ鼭 �����δ�.
        //���� �� �̻� ���� ���� �ʴ���
        //������ �־��� ���� ��� �Ҹ��ϱ� ��������
        //����ؼ� �����ϸ鼭 ������Ʈ�� �����̰� �ȴ�.

        //60������ �����ϴ� ���ӿ��� 1�����ӿ� �ʿ��� �ð���
        //1/60��,�� 0.016�� ������ �ɸ���.
        //30������ �����ϴ� ���ӿ����� 1�����ӿ� 1/30.0.032�ʰ� �Ҹ�ȴ�.

        //������Ʈ �Լ��� ����Ҷ� �������� ���̿� ����
        //������ ������ �������ֱ� ���ؼ� �������� �����ϴµ� �ɸ� �ð���
        //��ġ���� ���ؼ� �������ָ� �ȴ�.

        //�������� public�̳� SerializeField�� ���ؼ�
        //�����Ϳ��� ������ �����ϵ��� ���� ���
        //�������� ��ũ��Ʈ���� �ʱ�ȭ���� �� ->�����Ϳ��� ������ �� ->Start���� ������ ��
        //������ �������� ���� ��������.
        //������ ��ũ��Ʈ���� ���� �مf�ٰ� �ص�
        //�����Ϳ��� �ٽ� ���� ������ ������
        //�������� �ʱ�ȭ�� ���ʿ� start���� �ϰų�
        //Ȥ�� �����Ϳ��� �����Ǵ� ������ ���ֱ� ����
        //public�̳� SerializeField�� �����ָ� �ȴ�.

    }

    //��ü�� �ӵ��� ���� �����ϴ� ���
    void moveVelocity()
    {

        Vector3 myVelocity = Vector3.zero;
        //���� ���� ������ �����ϴ� ����
        //�Լ��� ���ö����� ���� ����� ������
        //�ӵ��� ������ ������ ���� �ʾƵ� �ǰ�
        //�ӵ����� ��� ����ϴ°� �ƴ϶�
        //�� ������ �� ������ ��� ���� �Ŀ�
        //���������� �ӵ��� �����ϱ� ������
        //�밢�� �̵����� �������� ������ �� �ִ�.;


        if (Input.GetKey(KeyCode.W) == true)
        {
            myVelocity += Vector3.forward;
            //������ٵ� �������ϸ�(AddFoce)
            //������ ���� ���ؼ� �ӵ��� �����Ѵ�.
            //���� ���� ����ν� �ӵ��� �����ϱ� ������
            //�ӵ����� �츮�� ���Ƿ� ��Ȯ�ϰ� ������ �� ����..

            //�ݸ鿡 ������ �ٵ��� Velocity�� ������� �ӵ���
            //��Ÿ���� �����̱� ������
            //�� �ӵ����� �����ϸ� �߰����� ����
            //��� �̵��� ����������(����,������ ����.)
            //����, �ӵ��� ��Ȯ�ϰ� ������ �� �ִ�.
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            myVelocity += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            myVelocity += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D) == true)
        {
            myVelocity += Vector3.right;
        }

        playerRigidbody.velocity = myVelocity * speed;
        //���������� �ϼ��� �ӵ����� ������ٵ� �����Ѵ�.
    }

    //��ǥ�� ���� �����ؼ� �����̴� ���
    void changePosition()
    {
        if (Input.GetKey(KeyCode.W) == true) 
        {
            this.transform.position += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S) == true) 
        {
            this.transform.position += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A) == true) 
        {
            this.transform.position += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D) == true) 
        {
            this.transform.position += Vector3.right;
        }

        //��ǥ�� ���� �����Ҷ���
        //���� ��ǥ���� ���� �������� �̵��ؾ� �ϱ� ������
        //������ �ƴ� ��ǥ�� ���ϱⰡ �Ǿ�� �Ѵ�.

        //��ǥ�� ���� �����Ͽ� �̵��ϴ� ����� ���
        //��ǥ���� ��� �����ϱ� ������
        //�߰� ������ ���� �ټ� �������� ���ܺ��� �� �ִ�.
        //(�ѹ��� �����̴� �Ÿ��� ª�� ����� ������� ���� ����)

        //��ǥ�� ������ �����ϱ� ������
        //���� ���� �����ִ� ������ ���� �հ� ��ǥ��
        //�����ϰ� �ȴ�.
    }

    //��ǥ�� �����ؼ� �����̴� ���2
    void positionTranslate()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            this.transform.Translate(Vector3.forward); 
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            this.transform.Translate(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            this.transform.Translate(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D) == true)
        {
            this.transform.Translate(Vector3.right);

        }
        //��ǥ����� �����ϰ� ��ǥ���� �ٲٴ��Լ�
        //�ٸ� ������ �ʿ���� ���� �ڽ��� ��ġ�� ��������
        //��ǥ�� ������ �� �մ�.
    }

    //������ ��ǥ�� �̵���Ű�� ���
    void goToPosition() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(8, 1, 8), 0.1f);
        //Vector3.MoveTowards
        //������ ��ǥ�� �̵���Ű�� �Լ�
        //�Ű������� ��������,��������,�ð��� ������ �Ÿ�
        //�� �Է¹޴´�.

        //ĳ���͸� �̵���Ű��, ������ ������ �ƴ϶�
        //������ ��ǥ�� �̵��ϴ°� ��ǥ�� ��� ����ϴ� �Լ�
    }

    //Ű���� �Է¿� ���ߴ����ϴ� ���
    void moveAxis()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal")*speed,
                                        0,
                                        Input.GetAxis("Vertical")*speed);

        //������ ���忡�� Ư�� �Է��� � ��������
        //Ű���� ���̳� �Էµ� ���� ������ �����ϱ� ����� ������
        //Ư�� �Է¿� ���� ������ �̸��� �ٿ���
        //�˾ƺ��� ���ϵ��� ����� �ִ� ���� GetAxis �Լ��̴�.
        //�����Ϳ��� Edit-project setting-input manager�� ����
        //�� �̸��� ��� �Է��� �޴��� Ȯ���� �� �ִ�.

        playerRigidbody.velocity = dir;
    }

    
    //�Ѿ˿� �ε������� �÷��̾ �Ҹ�(��Ȱ��ȭ)��Ű�� �Լ�
    void die()
    {

        gameObject.SetActive(false);
        //�빮�� GameObject�� ����Ƽ Ŭ������ ���ӿ�����Ʈ�� ��Ÿ����
        //�ҹ��� gameObject�� ���� �� ��ũ��Ʈ ������Ʈ�� ������ �ִ� ���
        //(==player)�� �Ǹ��ϰ� �ȴ�.
    }


    private void OnTriggerEnter(Collider other)
    {//bullet2���� �浹��(isTrigger)
        if (other.gameObject.tag == "Bullet")
            die();
    }

    private void OnCollisionEnter(Collision collision)
    {//bullet1���� �浹��
        if (collision.gameObject.tag == "Bullet")
        {
            die();
        }
    }
}